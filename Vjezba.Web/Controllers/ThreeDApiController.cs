using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Vjezba.DAL;
using Vjezba.Model;

namespace Vjezba.Web.Controllers
{
    //[Authorize]
    //[ApiController]
    //[Route("api")]
    //public class ThreeDApiController : BaseController
    //{
    //    private ThreeDModelDbContext _dbContext;

    //    public ThreeDApiController(ThreeDModelDbContext dbContext, UserManager<AppUser> userManager) : base(userManager)
    //    {
    //        this._dbContext = dbContext;
    //    }

    //    [AllowAnonymous]
    //    [Route("Client")]
    //    public IActionResult Get()
    //    {
    //        var clients = _dbContext.Clients.ToList();
    //        List<ClientDTO> clientsDTO = new List<ClientDTO>();
    //        foreach (var c in clients)
    //        {
    //            clientsDTO.Add(GetClientDTO(c));
    //        }

    //        return Ok(clientsDTO);
    //    }

    //    [Authorize]
    //    [Route("Client/{id}")]
    //    public IActionResult Get(int id)
    //    {
    //        var client = _dbContext.Clients.Find(id);
    //        return Ok(GetClientDTO(client));
    //    }

        
    //    [Route("pretraga/{q}")]
    //    public IActionResult Get(String q)
    //    {
    //        var clientQuery = this._dbContext.Clients.Include(p => p.City).AsQueryable();


    //        if (!string.IsNullOrWhiteSpace(q))
    //            clientQuery = clientQuery.Where(p => (p.FirstName + " " + p.LastName).ToLower().Contains(q.ToLower()));

    //        var clients = clientQuery.ToList();
    //        List<ClientDTO> clientsDTO = new List<ClientDTO>();
    //        foreach(var c in clients)
    //        {
    //            clientsDTO.Add(GetClientDTO(c));
    //        }

    //        return Ok(clientsDTO);
    //    }

    //    [Authorize(Roles = "Manager,Admin")]
    //    [Route("Client/{id}")]
    //    [HttpPut]
    //    public IActionResult Put(int id, [FromBody] Client model)
    //    {
    //        if (model == null)
    //        {
    //            return BadRequest();
    //        }
    //        if(_dbContext.Clients.Find(id) == null)
    //        {
    //            return NotFound();
    //        }
    //        Client client = this._dbContext.Clients.Find(id);
    //        model.UpdatedBy = UserId;
    //        client = model;
    //        _dbContext.SaveChanges();
            
    //        return Ok();
    //    }

    //    [Authorize(Roles = "Manager,Admin")]
    //    [Route("Client")]
    //    [HttpPost]
    //    public IActionResult Post([FromBody] Client model)
    //    {
    //        if (model == null)
    //        {
    //            return BadRequest();
    //        }
    //        model.CreatedBy = UserId;
    //        _dbContext.Clients.Add(model);
    //        _dbContext.SaveChanges();
    //        return Ok();
    //    }

    //    [Authorize(Roles = "Admin")]
    //    [HttpDelete]
    //    public IActionResult Delete(int id)
    //    {
    //        if (_dbContext.Clients.Find(id) == null)
    //        {
    //            return NotFound();
    //        }
    //        _dbContext.Clients.Remove(_dbContext.Clients.Find(id));
    //        _dbContext.SaveChanges();
    //        return Ok();
    //    }

    //    private ClientDTO GetClientDTO(Client client)
    //    {
    //        ClientDTO dto = new ClientDTO()
    //        {
    //            ID = client.ID,
    //            FullName = client.FullName,
    //            Address = client.Address,
    //            Email = client.Email
    //        };

    //        City city = _dbContext.Cities.Find(client.CityID);
    //        dto.City = new CityDTO()
    //        {
    //            ID = city.ID,
    //            Name = city.Name
    //        };
    //        return dto;
    //    }

    //    [Authorize]
    //    [HttpPost("Client/UploadAttachment/{id}")]
    //    public IActionResult UploadAttachment(int id, IFormFile file)
    //    {

    //        if (_dbContext.Clients.Find(id) == null)
    //        {
    //            return NotFound();
    //        }

    //        String filePath = saveFile(file);

    //        Client client = _dbContext.Clients.Find(id);
    //        OBJAttachment attachment = new OBJAttachment();
    //        attachment.OBJFilePath = filePath;
    //        if (client.Attachments == null)
    //        {
    //            client.Attachments = new List<OBJAttachment>();
    //        }
    //        client.Attachments.Add(attachment);
    //        _dbContext.SaveChanges();

    //        return Json(new { success = true });
    //    }

    //    private string saveFile(IFormFile file)
    //    {
    //        string uploads = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "uploads");
    //        System.IO.Directory.CreateDirectory(uploads);
    //        if (file.Length > 0)
    //        {
    //            string filePath = Path.Combine(uploads, file.FileName);
    //            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
    //            {
    //                file.CopyTo(fileStream);
    //            }
    //            return filePath;
    //        }
    //        return null;
    //    }
    //}


    //public class ClientDTO
    //{
    //    public int ID { get; set; }
    //    public String FullName { get; set; }
    //    public String Address { get; set; }
    //    public CityDTO City { get; set; }
    //    public String Email { get; set; }

    //}

    //public class CityDTO
    //{
    //    public int ID { get; set; }
    //    public String Name { get; set; }
    //}
}
