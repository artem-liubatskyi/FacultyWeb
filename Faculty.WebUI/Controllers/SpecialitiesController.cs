using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Faculty.Data;
using Faculty.Data.Models;

namespace Test2.Controllers
{
    public class SpecialitiesController : Controller
    {
        private readonly ISpecialityService _specialityService;

        public SpecialitiesController(ISpecialityService specialityService)
        {
            _specialityService = specialityService;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _specialityService.GetAll());
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var speciality = await _specialityService.GetById((int)id);

            if (speciality == null)
            {
                return NotFound();
            }

            return View(speciality);
        }
    }
}
