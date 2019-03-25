using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Faculty.Data;

namespace Test2.Controllers
{
    public class TeachersController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        
        public async Task<IActionResult> Index()
        {
            return View(await _teacherService.GetAll());
        }
    
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _teacherService.GetById(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }
    }
}
