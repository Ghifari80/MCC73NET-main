using API.Contexts;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repository.Data
{
    public class ProfilingRepositories : GeneralRepository<Profiling, string>
    {
        public ProfilingRepositories(MyContext context) : base(context)
        {
        }
    }
}
