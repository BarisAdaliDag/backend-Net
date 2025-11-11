using _39_Api_FirstApp.Models;
using _39_Api_FirstApp.Models.Route;
using _39_Api_FirstApp.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace _39_Api_FirstApp.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]

    //HTTP CONTEXT KUllanimi internetten bak
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Employee>> GetEmployees()
        {
            if (EmployeeData.Employees.Count < 0)
            {
                return NotFound("Not Found User");
            }
            return Ok(EmployeeData.Employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployee([FromRoute] int id)
        {
            var employee = EmployeeData.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null)
            {
                return NotFound("Not Found User");
            }
            return Ok(employee);

        }
        [HttpGet("gender/{gender}/city/{city}")]
        public ActionResult<List<Employee>> GetEmployeeGenderAndCity(string gender, string city)
        {
            var filteredEmployee = EmployeeData.Employees.Where(e => e.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
            e.City.Equals(gender, StringComparison.OrdinalIgnoreCase));

            if (filteredEmployee.Any())
            {
                return NotFound($"Not Femployees with gender{gender} with city {city}");
            }
            return Ok(filteredEmployee);

        }

        [HttpGet("search")]
        public ActionResult<List<Employee>> SearchEmployees([FromQuery] EmployeeSearch searchCriteria)
        {
            var filteredEmployees = EmployeeData.Employees.AsEnumerable();

            // Cinsiyete göre filtre
            if (!string.IsNullOrWhiteSpace(searchCriteria.Gender))
            {
                filteredEmployees = filteredEmployees
                    .Where(e => e.Gender.Equals(searchCriteria.Gender, StringComparison.OrdinalIgnoreCase));
            }

            // Departmana göre filtre
            if (!string.IsNullOrWhiteSpace(searchCriteria.Department))
            {
                filteredEmployees = filteredEmployees
                    .Where(e => e.Department.Equals(searchCriteria.Department, StringComparison.OrdinalIgnoreCase));
            }

            // Şehre göre filtre
            if (!string.IsNullOrWhiteSpace(searchCriteria.City))
            {
                filteredEmployees = filteredEmployees
                    .Where(e => e.City.Equals(searchCriteria.City, StringComparison.OrdinalIgnoreCase));
            }

            // Sonuç listesi
            var filteredList = filteredEmployees.ToList();

            // Hiç filtre uygulanmadıysa (hepsi boşsa), tüm liste dön
            if (string.IsNullOrWhiteSpace(searchCriteria.Gender) &&
                string.IsNullOrWhiteSpace(searchCriteria.Department) &&
                string.IsNullOrWhiteSpace(searchCriteria.City))
            {
                return Ok(EmployeeData.Employees);
            }

            // Filtre sonucunda eşleşme yoksa NotFound dön
            if (!filteredList.Any())
            {
                return NotFound("Arama kriterlerine uygun çalışan bulunamadı.");
            }

            return Ok(filteredList);
        }

        [HttpGet("pageList")]
        public ActionResult<List<Employee>> PaginationEmployee([FromQuery] int page = 1)
        {
            if (EmployeeData.Employees.Count == 0)
            {
                return NotFound("No employees found.");
            }

            const int pageSize = 5; // her sayfada 5 çalışan
            var totalCount = EmployeeData.Employees.Count;
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            // Sayfa numarası aralık dışında ise hata mesajı döndür
            if (page < 1 || page > totalPages)
            {
                return BadRequest($"Sayfa numarası 1 ile {totalPages} arasında olmalıdır.");
            }

            var pagedData = EmployeeData.Employees
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            // Sayfa bilgilerini response içine ekleyelim
            var response = new
            {
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalCount = totalCount,
                Data = pagedData
            };

            return Ok(response);
        }





    }
}
