using API.Contexts;
using API.Handlers;
using API.Models;
using API.Repository.Interface;
using API.ViewModels;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace API.Repository.Data
{
    public class AccountRepositories : GeneralRepository<Account, string>
    {
        public AccountRepositories(MyContext context) : base(context)
        {
        }
        public IEnumerable<RegisterVM> CekEmailPhone(RegisterVM registerVM)
        {
            var result = (from e in _context.Employees
                          where e.Email == registerVM.Email || e.Phone == registerVM.Phone
                          select new RegisterVM
                          {
                              Email = e.Email,
                              Phone = e.Phone
                          });
            return result;
        }

        public int Register(RegisterVM registerVM)
        {

            Employee em = new Employee();
            Account ac = new Account();
            Profiling p = new Profiling();
            Education ed = new Education();
            University u = new University();
            AccountRole ar = new AccountRole();

            u.Name = registerVM.UniversityName;

            _context.Universities.Add(u);
            var result = _context.SaveChanges();

            ed.UniversityId = u.Id;
            ed.GPA = registerVM.GPA;
            ed.Degree = registerVM.Degree;

            _context.Educations.Add(ed);
            result = _context.SaveChanges();

            em.NIK = registerVM.NIK;
            em.FirstName = registerVM.FirstName;
            em.LastName = registerVM.LastName;
            em.Phone = registerVM.Phone;
            em.Gender = registerVM.Gender;
            em.BirthDate = registerVM.Birthdate;
            em.Salary = registerVM.Salary;
            em.Email = registerVM.Email;

            _context.Employees.Add(em);
            result = _context.SaveChanges();

            ac.NIK = registerVM.NIK;
            ac.Password = Hashing.HashPassword(registerVM.Password);

            _context.Accounts.Add(ac);
            result = _context.SaveChanges();

            p.NIK = registerVM.NIK;
            p.EducationId = ed.Id;

            _context.Profilings.Add(p);
            result = _context.SaveChanges();

            ar.AccountNIK = registerVM.NIK;
            ar.RoleId = 1;
            _context.AccountRoles.Add(ar);
            _context.SaveChanges();

            return result;

        }

        public IEnumerable<LoginVM> CekAccount(string email)
        {
            var result = (from e in _context.Employees
                          join a in _context.Accounts on e.NIK equals a.NIK
                          where e.Email == email
                          select new LoginVM
                          {
                              Email = e.Email
                          });
            return result;
        } 

        /*public IEnumerable<LoginVM> Login(string email, string password)
        {
            var result = (from e in _employees join a in _accounts on e.NIK equals a.NIK
                          where e.Email == email && a.Password == password select new LoginVM
                          {
                              NIK = e.NIK,
                              Fullname = $"{e.FirstName} {e.LastName}",
                              Email = e.Email,
                              Password = a.Password
                          });
            return result;
        }*/
        public int Login(LoginVM login)
        {
            var result = _context.Accounts.Join(_context.Employees, a => a.NIK, e => e.NIK, (a, e) =>
            new LoginVM
            {
                Email = e.Email,
                Password = a.Password
            }).SingleOrDefault(c => c.Email == login.Email);

            if (result == null)
            {
                return 0; // Email Tidak Terdaftar
            }
            if (Hashing.ValidatePassword(login.Password, result.Password) == false)
            {
                return 1; // Password Salah
            }
            return 2; // Email dan Password Benar
        }

        public List<string> UserRoles(string email)
        {
            // {"Employee", "Manager"}
            // {"Employee"}
            var result = (from e in _context.Employees
                          join ac in _context.AccountRoles on e.NIK equals ac.AccountNIK
                          join r in _context.Roles on ac.RoleId equals r.Id
                          where e.Email == email
                          select r.Name );

            return new List<string>(result);
        }
        private string GenerateNIK()
        {
            var empCount = _context.Employees.OrderByDescending(e => e.NIK).FirstOrDefault();

            if (empCount == null)
            {
                return "x11111";
            }
            string NIK = empCount.NIK.Substring(1, 5);
            return Convert.ToString("x" + Convert.ToInt32(NIK) + 1);
        }
    }
}