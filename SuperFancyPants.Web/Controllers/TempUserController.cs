using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperFancyPants.Web.Data;
using SuperFancyPants.Web.Domain;

namespace SuperFancyPants.Web.Controllers
{
    public class TempUserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<UserAccount> _userManager;

        public TempUserController(ApplicationDbContext context, UserManager<UserAccount> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                //return RedirectToAction("Contact", "Home");
                return new UnauthorizedResult();
            }

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);
            var userSkills = await _context.SkillToUserAccounts
                                            .Where(x => x.UserAccountId == userId)
                                            .Select(x => x.SkillId)
                                            .ToListAsync();

            var skillOfUser = await _context.SkillToUserAccounts
                                            .Where(x => x.UserAccountId == userId)
                                            .Select(x => x.Skill)
                                            .ToListAsync();



            ViewData["SkillIds"] = new MultiSelectList(_context.Skills, "Id", "Name");
            return View(new UserViewModel
            {
                FirstName = user.FirstName,
                SkillIds = userSkills
            });
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserViewModel model)
        {
            // save firstname
            // Skills
            //  Remove unselected
            //  Add selected

            if (ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);
                if (userId == null)
                {
                    //return RedirectToAction("Contact", "Home");
                    return new UnauthorizedResult();
                }

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
                return RedirectToAction("Index", "Todo");
            }

            ViewData["SkillIds"] = new MultiSelectList(_context.Skills, "Id", "Name");
            return View(model);
        }
    }

    public class UserViewModel
    {
        [Required]
        public string FirstName { get; set; }
        public IList<int> SkillIds { get; set; }
    }
}