using API.Base;
using API.Contexts;
using API.Models;
using API.Repository.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class AccountsController : BaseController<Account, string>
{
    public MyContext myContext;
    private AccountRepositories _repo;
    private IConfiguration _con;

    public AccountsController(MyContext context, AccountRepositories repo, IConfiguration con) : base(context)
    {
        myContext = context;
        _repo = repo;
        _con = con;
    }

    /* private AccountRepositories _repositories;
private IConfiguration _con;
public AccountsController(AccountRepositories repo, IConfiguration con)
{
    _repositories = repo;
    _con = con;
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
public ActionResult Insert(Account account)
{
    try
    {
        var result = _repositories.Insert(account);
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
public ActionResult Update(Account accounts)
{
    *//*try
    {
        var result = _repositories.Get(accounts.NIK);
        return result == null
        ? Ok(new { statusCode = 200, message = "Data Not Found!!" })
        : Ok(new { statusCode = 200, message = "Success" });
    }
    catch (Exception e)
    {
        return BadRequest(new { statusCode = 500, message = $"Check Property :{e.Message}" });
    }*//*
    _repositories.Update(accounts);
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
    catch (Exception e)
    {
        return BadRequest(new { statusCode = 501, message = $"Problem : {e.Message} !!" });
    }
}*/

    [AllowAnonymous]
    [HttpPost]
    [Route("Register")]
    public ActionResult Register(RegisterVM register)
    {
        var cekEmailPhone = _repo.CekEmailPhone(register);
        if (cekEmailPhone.Count() == 0)
        {
            try
            {
                var result = _repo.Register(register);
                return result == 0
                    ? Ok(new { statusCode = 404, message = "Register Failed!" })
                    : Ok(new { statusCode = 200, message = "Register Succesfully!" });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest(new { statusCode = 501, message = $"Problem : {e.Message}" });
            }
        }
        else
        {
            return Ok(new { statusCode = 404, message = "Email/No hp Sudah Terdaftar!!" });
        }

    }

    /*[HttpGet]
    [Route("Login")]
    public ActionResult Login(string email, string password)
    {
        var result1 = _repositories.CekAccount(email);
        if (result1.Count() == 0)
        {
            return Ok(new {statuscode = 403, message = "Account Tidak Terdaftar" });
        }
        else
        {
            try
            {
                var result = _repositories.Login(email, password);
                return result.Count() == 0
                ? Ok(new { statusCode = 403, message = "Password Salah!!" })
                : Ok(new { statusCode = 200, message = "Login Success", data = result });
            }
            catch (Exception e)
            {
                return BadRequest(new { statusCode = 501, message = $"Problem :{e.Message}" });
            }
        }
    }*/
    [AllowAnonymous]
    [HttpPost]
    [Route("Login")]
    public ActionResult Login(LoginVM loginVM)
    {
        try
        {
            var result = _repo.Login(loginVM);
            switch (result)
            {
                case 0:
                    return Ok(new { statusCode = 200, message = "Account Not Found!" });
                case 1:
                    return Ok(new { statusCode = 200, message = "Wrong Password!" });
                default:
                    // bikin method untuk mendapatkan role-nya user yang login
                    var roles = _repo.UserRoles(loginVM.Email);

                    var claims = new List<Claim>()
                    {
                        new Claim("email", loginVM.Email),
                        //new Claim(ClaimTypes.Email, loginVM.Email)
                    };

                    foreach (var item in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, item));
                    }

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_con["JWT:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _con["JWT:Issuer"],
                        _con["JWT:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signIn
                        );

                    var generateToken = new JwtSecurityTokenHandler().WriteToken(token);
                    claims.Add(new Claim("Token Security", generateToken.ToString()));

                    return Ok(new { statusCode = 200, message = "Login Success!", data = generateToken, Roles = roles });
            }
        }
        catch (Exception e)
        {
            return BadRequest(new { statusCode = 500, message = $"Something Wrong! : {e.Message}" });
        }

    }
}
