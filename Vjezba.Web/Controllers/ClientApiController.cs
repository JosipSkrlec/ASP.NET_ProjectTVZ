using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Vjezba.DAL;

namespace Vjezba.Web.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientApiController : Controller
    {
        private ClientManagerDbContext _dbContext;

        public ClientApiController(ClientManagerDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public IActionResult Get()
        {
            var ClientCollection = this._dbContext.Clients
                .Select(p=> new ClientDTO() {
                ID = p.ID,
                FullName = p.FullName,
                Adress = p.Address,
                City = new CityDTO()
                {
                    ID = p.City.ID,
                    Name = p.City.Name
                },
                Email = p.Email                
                }            
                
                ).ToList();


            return Ok(ClientCollection);
        }

    }

    public class ClientDTO
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
        public CityDTO City { get; set; }
        public string Email { get; set; }
    }

    public class CityDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }



}
