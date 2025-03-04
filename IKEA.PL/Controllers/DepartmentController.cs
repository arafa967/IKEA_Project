using IKEA.BLL.Models.Department;
using IKEA.BLL.Serveise;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<CreatedDepartmentDto> _logger;
        private readonly IWebHostEnvironment _environment;

        public DepartmentController(IDepartmentService departmentService ,ILogger<CreatedDepartmentDto> logger, IWebHostEnvironment environment)
        {
            _departmentService = departmentService;
            _logger = logger;
            _environment = environment;
        }
        #region Index
        //BaseYlr/Department/Index
        [HttpGet]
        public IActionResult Index()
        {
            var department = _departmentService.GetAllDeparment();
            return View(department);
        }
        #endregion
        #region Create
        #region Get
        [HttpGet]
        //Base/Department/Create
        public IActionResult Creaete()
        {
            return View();
        }
        #endregion
        #region Post
        [HttpPost]
        public IActionResult Create(CreatedDepartmentDto department)
        {
            if (!ModelState.IsValid)//Server Side Validation
            {
                return View(department);
            }
            var message = string.Empty;
            try
            {
                var result = _departmentService.CreateDepartment(department);
                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    message = "Department Is Not Ceated";
                    ModelState.AddModelError(string.Empty, message);
                    return View(department);

                }
            }
            catch (Exception ex)
            {
                // 1- Log Exception
                _logger.LogError(ex, ex.Message);
                //2- Set frindly Message
                if (_environment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(department);
                }
                else
                {
                    message = "Department Is Not Ceated";
                    return View("Error",message);
                }
                
            }

        }
        #endregion
        #endregion

    }
}
