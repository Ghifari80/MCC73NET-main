using API.Contexts;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace API.Repository.Data
{
    public class RoleRepositories : GeneralRepository<Role, int>
    {
        public RoleRepositories(MyContext context) : base(context)
        {
        }
    }
}
