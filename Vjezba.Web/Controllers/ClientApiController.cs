using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Vjezba.DAL;
using Vjezba.Model;

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

        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var client = this._dbContext.Clients.Where(p=>p.ID == id).Select(p => new ClientDTO()
            {
                ID = p.ID,
                FullName = p.FullName,
                Adress = p.Address,
                City = new CityDTO()
                {
                    ID = p.City.ID,
                    Name = p.City.Name
                },
                Email = p.Email
            }).FirstOrDefault();

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [Route("pretraga/{q}")]
        public IActionResult Get(string q)
        {
            var clients = this._dbContext.Clients.Where(p => p.FirstName.Contains(q)).Select(p => new ClientDTO()
            {
                ID = p.ID,
                FullName = p.FullName,
                Adress = p.Address,
                City = new CityDTO()
                {
                    ID = p.City.ID,
                    Name = p.City.Name
                },
                Email = p.Email
            }).ToList();

            if (clients == null)
            {
                return NotFound();
            }

            return Ok(clients);
        }

        [HttpPost]
        public IActionResult Post(Client client)
        {
            if (string.IsNullOrWhiteSpace(client.FirstName))
            {
                return BadRequest();
            }

            this._dbContext.Add(
                new Client()
                {        
                    FirstName = client.FullName,
                    LastName = client.LastName,
                    Address = client.Address,
                    Email = client.Email,
                    PhoneNumber = client.PhoneNumber,
                    City = new City()
                    {
                        ID = client.City.ID,
                        Name = client.City.Name,
                    },
                });

            this._dbContext.SaveChanges();

            return Ok();

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
