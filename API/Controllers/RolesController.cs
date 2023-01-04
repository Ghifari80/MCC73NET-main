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
//[Authorize(Roles = "Admin")]
public class RolesController : BaseController<Role, int>
{
    public RolesController(MyContext context) : base(context)
    {
    }
    /*private RoleRepositories _repositories;
    public RolesController(RoleRepositories repositories)
    {
        _repositories = repositories;
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        try
        {
            var result = _repositories.Get();
            return result == null
            ? Ok(new { statuscode = 404, message = "Data Not Found!!" })
            : Ok(new { statuscode = 200, message = "Succes", data = result });
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 501, message = $"Check Property : {e.Message}" });
        }
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult GetById(int id)
    {
        try
        {
            var result = _repositories.Get(id);
            return result == null
            ? Ok(new { statusCode = 404, message = "Data Not Found!!" })
            : Ok(new { statusCode = 200, message = "Success", data = result });
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 501, message = $"Check Property :{e.Message}" });
        }
    }

    [HttpPost]
    public ActionResult Insert(Role role)
    {
        try
        {
            var result = _repositories.Insert(role);
            return result == 0
            ? Ok(new { statusCode = 404, message = "Data Not Found!!" })
            : Ok(new { statusCode = 200, message = "Success" });
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 501, message = $"Check Property :{e.Message}" });
        }
    }

    [HttpPut]
    public ActionResult Update(Role roles)
    {
        *//*try
        {
            var result = _repositories.Get(roles.Id);
            return result == null
            ? Ok(new { statusCode = 200, message = "Data Not Found!!" })
            : Ok(new { statusCode = 200, message = "Success" });
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 500, message = $"Check Property :{e.Message}" });
        }*//*
        _repositories.Update(roles);
        return Ok(new { message = "Data Berhasil Di Ubah" });
    }

    [HttpDelete]
    public ActionResult Delete(int id)
    {
        try
        {
            var result = _repositories.Delete(id);
            return result == 0
            ? Ok(new { statusCode = 404, message = $"Id With Id. {id} Not Found" })
            : Ok(new { statusCode = 200, message = "Data Berhasil Di hapus" });
        }
        catch
        {
            return BadRequest(new { statusCode = 501, message = "Problem!!" });
        }
    }*/

}
