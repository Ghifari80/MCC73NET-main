using API.Contexts;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace API.Repository.Data
{
    public class EducationRepositories : GeneralRepository<Education, int>
    {
        public EducationRepositories(MyContext context) : base(context)
        {
        }
    }
}
