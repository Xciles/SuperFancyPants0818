using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuperFancyPants.Web.Business;
using SuperFancyPants.Web.Domain;

namespace SuperFancyPants.Web.Controllers
{
    public class TempUserController : Controller
    {
        private readonly UserManager<UserAccount> _userManager;
        private readonly IUserSkills _userSkills;

        public TempUserController(UserManager<UserAccount> userManager, IUserSkills userSkills)
        {
            _userManager = userManager;
            _userSkills = userSkills;
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

            var model = await _userSkills.GetIndexModel(userId);
            ViewData["SkillIds"] = new MultiSelectList(await _userSkills.GetAllSkills(), "Id", "Name");
            return View(model);
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
                
                await _userSkills.UpdateUserSkills(userId, model);
                return RedirectToAction("Index", "Todo");
            }

            ViewData["SkillIds"] = new MultiSelectList(await _userSkills.GetAllSkills(), "Id", "Name");
            return View(model);
        }
    }

    public class UserViewModel
    {
        [Required(ErrorMessage = "Hey joh vul een FirstName in")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Skills")]
        public IList<int> SkillIds { get; set; }
    }
}