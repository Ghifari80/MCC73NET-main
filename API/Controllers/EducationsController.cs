using API.Base;
using API.Contexts;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Manager")]
public class EducationsController : BaseController<Education, int>
{
    public EducationsController(MyContext context) : base(context)
    {
    }
}
