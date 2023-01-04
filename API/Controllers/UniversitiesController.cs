using API.Base;
using API.Contexts;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Manager")]
public class UniversitiesController : BaseController<University, int>
{
    public UniversitiesController(MyContext context) : base(context)
    {
    }
}
