using API.Contexts;
using API.Models;
using API.Repository.Interface;
using API.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace API.Repository.Data
{
    public class EmployeeRepositories : GeneralRepository<Employee, string>
    {
        public EmployeeRepositories(MyContext context) : base(context)
        {
        }

        public IEnumerable<MasterEmployeeDataVM> MasterEmployees()
        {
            var result = (from e in _context.Employees
                          join p in _context.Profilings on e.NIK equals p.NIK
                          join ed in _context.Educations on p.EducationId equals ed.Id
                          join u in _context.Universities on ed.UniversityId equals u.Id
                          select new MasterEmployeeDataVM
                          {
                              NIK = e.NIK,
                              FullName = $"{e.FirstName} {e.LastName}",
                              Phone = e.Phone,
                              Gender = e.Gender.ToString(),
                              Email = e.Email,
                              BirthDate = e.BirthDate,
                              Salary = e.Salary,
                              EducationId = p.EducationId,
                              GPA = ed.GPA,
                              Degree = ed.Degree,
                              UniversityName = u.Name
                          }).ToList();
            return result;
        }  
    }
}
