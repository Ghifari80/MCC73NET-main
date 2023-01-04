using API.Contexts;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace API.Repository.Data
{
    public class AccountRoleRepositories : GeneralRepository<AccountRole, int>
    {
        public AccountRoleRepositories(MyContext context) : base(context)
        {
        }
    }
}
