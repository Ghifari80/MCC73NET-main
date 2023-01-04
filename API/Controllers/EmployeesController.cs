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
[Authorize]
public class EmployeesController : BaseController<Employee, string>
{
    public MyContext myContext;
    public EmployeesController(MyContext context) : base(context)
    {
        myContext = context;
    }

    /*private EmployeeRepositories _repositories;
    public EmployeesController(EmployeeRepositories repositories)
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
    [Route("{nik}")]
    public ActionResult GetById(string nik)
    {
        try
        {
            var result = _repositories.Get(nik);
            return result == null
            ? Ok(new { statusCode = 404, message = "Data Not Found!!" })
            : Ok(new { statusCode = 200, message = "Success", data = result });
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 501, message = $"Check Property :{e.Message}" });
        }
    }*/

    //[Authorize(Roles = "Manager, Admin
    [HttpGet]
    [Route("MasterEmployees")]
    [AllowAnonymous]
    public ActionResult GetMaster()
    {
        try
        {
            var result = myContext.Employees;
            return result == null
            ? Ok(new { statusCode = 404, message = "Data Not Found!!" })
            : Ok(new { statusCode = 200, message = "Success", data = result });
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 501, message = $"Check Property :{e.Message}" });
        }
    }

    /*[HttpPost]
    public ActionResult Insert(Employee employee)
    {
        try
        {
            var result = _repositories.Insert(employee);
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
    public ActionResult Update(Employee employees)
    {
        try
        {
            var result = _repositories.Update(employees);
            //var update = _repositories.Update(employees);
            return result == null
            ? Ok(new { statusCode = 200, message = "Data Gagal Di Ubah!!" })
            : Ok(new { data = _repositories.Update(employees), statusCode = 200, message = "Success" });
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 500, message = $"Check Property :{e.Message}" });
        }
        if (_repositories.Get(employees.NIK) == null)
        {
            return Ok(new { message = "Data Gagal DI ubah" });
        }
        _repositories.Update(employees);
        return Ok(new { message = "Data Berhasil Di Ubah" });
    }

    [HttpDelete]
    public ActionResult Delete(string nik)
    {
        try
        {
            var result = _repositories.Delete(nik);
            return result == 0
            ? Ok(new { statusCode = 404, message = $"Nik With {nik} Not Found" })
            : Ok(new { statusCode = 200, message = "Data Berhasil Di hapus" });
        }
        catch
        {
            return BadRequest(new { statusCode = 501, message = "Problem!!" });
        }
    }*/
}
