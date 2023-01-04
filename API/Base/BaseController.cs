using API.Contexts;
using API.Models;
using API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Base;

[Route("api/[controller]")]
[ApiController]
public class BaseController<Entity, T> : ControllerBase where Entity : class
{
    private MyContext _context;
    public BaseController(MyContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        try
        {
            var result = _context.Set<Entity>();
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
            var result = _context.Set<Entity>().FindAsync(id);
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
    public ActionResult Insert(Entity entity)
    {
        try
        {
            var result = _context.Add(entity);
            return result == null
            ? Ok(new { statusCode = 404, message = "Data Not Found!!" })
            : Ok(new { statusCode = 200, message = "Success" });
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 501, message = $"Check Property :{e.Message}" });
        }
    }

    [HttpPut]
    public ActionResult Update(Entity entity)
    {
        try
        {
            var result = _context.Update(entity);
            return result == null
            ? Ok(new { statusCode = 200, message = "Data Not Found!!" })
            : Ok(new { statusCode = 200, message = "Success" });
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 500, message = $"Check Property :{e.Message}" });
        }
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
        try
        {
            var result = _context.Remove(id);
            return result == null
            ? Ok(new { statusCode = 404, message = $"Data With Id. {id} Not Found" })
            : Ok(new { statusCode = 200, message = "Data Berhasil Di hapus" });
        }
        catch
        {
            return BadRequest(new { statusCode = 501, message = "Problem!!" });
        }
    }

}
