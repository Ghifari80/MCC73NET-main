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
public class ProfilingsController : BaseController<Profiling, string>
{
    /* private ProfilingRepositories _repositories;
     public ProfilingsController(ProfilingRepositories repositories)
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
     }

     [HttpPost]
     public ActionResult Insert(Profiling profiling)
     {
         try
         {
             var result = _repositories.Insert(profiling);
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
     public ActionResult Update(Profiling profiling)
     {
         *//*try
         {
             var result = _repositories.Get(profiling.NIK);
             return result == null
             ? Ok(new { statusCode = 200, message = "Data Not Found!!" })
             : Ok(new { statusCode = 200, message = "Success" });
         }
         catch (Exception e)
         {
             return BadRequest(new { statusCode = 500, message = $"Check Property :{e.Message}" });
         }*//*
         _repositories.Update(profiling);
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
    public ProfilingsController(MyContext context) : base(context)
    {
    }
}
