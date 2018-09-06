using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperFancyPants.Web.Controllers;
using SuperFancyPants.Web.Data;
using SuperFancyPants.Web.Domain;

namespace SuperFancyPants.Web.Business
{
    public interface IUserSkills
    {
        Task<UserViewModel> GetIndexModel(string userId);
        Task<IList<Skill>> GetAllSkills();
        Task UpdateUserSkills(string userId, UserViewModel model);
    }

    public class UserSkills : IUserSkills
    {
        private readonly ApplicationDbContext _context;

        public UserSkills(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserViewModel> GetIndexModel(string userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var userSkills = await _context.SkillToUserAccounts
                .Where(x => x.UserAccountId == userId)
                .Select(x => x.SkillId)
                .ToListAsync();

            var skillOfUser = await _context.SkillToUserAccounts
                .Where(x => x.UserAccountId == userId)
                .Select(x => x.Skill)
                .ToListAsync();

            return new UserViewModel
            {
                FirstName = user.FirstName,
                SkillIds = userSkills
            };
        }

        public async Task<IList<Skill>> GetAllSkills()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task UpdateUserSkills(string userId, UserViewModel model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            user.FirstName = model.FirstName;

            if (model.SkillIds != null)
            {
                var skillToUserAccounts = await _context.SkillToUserAccounts
                    .Where(x => x.UserAccountId == userId)
                    .ToListAsync();

                //_context.SkillToUserAccounts.RemoveRange(skillToUserAccounts.Where(x => !model.SkillIds.Contains(x.SkillId)));
                //var skillToAdd = model.SkillIds.Except(skillToUserAccounts.Select(x => x.SkillId));

                foreach (var skillId in model.SkillIds)
                {
                    _context.SkillToUserAccounts.Add(new SkillToUserAccount
                    {
                        UserAccountId = userId,
                        SkillId = skillId
                    });
                }

                //foreach (var skillToUserAccount in skillToUserAccounts)
                //{
                //    if (!model.SkillIds.Contains(skillToUserAccount.SkillId))
                //    {
                //        _context.SkillToUserAccounts.Remove(skillToUserAccount);
                //    }
                //}

                //foreach (var skillId in model.SkillIds)
                //{
                //    if (!skillToUserAccounts.Select(x => x.SkillId).Contains(skillId))
                //    {

                //    }
                //}
            }

            await _context.SaveChangesAsync();
        }
    }
}
