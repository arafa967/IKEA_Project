using IKEA.BLL.Models.Department;
using IKEA.BLL.Serveise;
using IKEA.PL.Models.Departments;
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
        #region Details
        [HttpGet] // Dapertment /Details/id
        public IActionResult Details(int? id)
        {
            if(id is null)
            {
                return BadRequest();//400

            }
            var department  = _departmentService .GetDepartmentById(id.Value);
            if(department is null)
            {
                return NotFound(); //404
            }
            return View(department);    
        }
        #endregion
        #region Edit
        #region Get
        [HttpGet] // Department/Edit/id?
        public IActionResult Edit(int? id)
        {
            if (id is null)
            {
                return BadRequest(); //400
            }
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null)
            {
                return NotFound(); //404
            }
            return View( new DepartmentEditViewModel()
            {
                Code = department.Code,
                Name = department.Name,
                Description= department.Description,
                CreatedDate = department.CreatedDate
            });
        }
        #endregion
        #region Post
        [HttpPost]
        public IActionResult Edit([FromRoute] int  id ,DepartmentEditViewModel departmentVM)
        {
            if (!ModelState.IsValid)
            {
                return View(departmentVM);

            }var message = string.Empty;
            try
            {
                var updatedDepartment = new UpdatedDeparmentDTO()
                {
                    Id = id,
                    Code = departmentVM.Code,
                    Name = departmentVM.Name,
                    Description = departmentVM.Description,
                    CreatedDate = departmentVM.CreatedDate,
                };
                var updated = _departmentService.UpdateDeparment(updatedDepartment) > 0;
                if (updated)
                {
                    return RedirectToAction(nameof(Index));

                }
                message = "Sorry , An Error Ocuurd While Updated the Department ";

            }
            catch (Exception ex)
            {
                //1- Log Exception
                _logger .LogError(ex, ex.Message);
                //2- Set Message
                message =_environment.IsDevelopment()? ex.Message :  "Sorry , An Error Ocuured While Upating The Department ";

            }
            ModelState.AddModelError(string.Empty, message);
            return View(departmentVM);
        }
        #endregion
        #endregion
        #region Delete
        #region Get
        [HttpGet]
        public IActionResult Delete(int? id) 
        {
            if(id is null)
            {
                return BadRequest();
            }
            var department  = _departmentService.GetDepartmentById(id.Value);
            if(department is null)
            {
                return NotFound();
            }
            return View(department);

        }
        #endregion
        #region Post
        [HttpPost]
        public IActionResult Delete (int id)
        {
            var message = string.Empty;
            try
            {
                var delete = _departmentService.DeleteDepartment(id);
                if (delete)
                {
                    return RedirectToAction(nameof(Index));
                }
                message = "Sorry , An Get Error Ocuured During Deleting the Department";

            }
            catch(Exception ex)
            { 
                //1-Log Exception 
                _logger.LogError(ex, ex.Message);
                //2- Set Message 
                message = _environment.IsDevelopment()? ex.Message : "Sorry , An Get Error Ocuured During Deleting the Department";
            }
            return RedirectToAction(nameof(Index));
        }
         
        #endregion
        #endregion
    }
}
