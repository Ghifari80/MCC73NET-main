using API.Contexts;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace API.Repository.Data;

public class UniversityRepositories : GeneralRepository<University, int>
{
    public UniversityRepositories(MyContext context) : base(context)
    {
    }
}
