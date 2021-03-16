using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Vjezba.Web.Mock;

namespace Vjezba.Web.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet]
        public IActionResult Index(string query)
        {           

            MockClientRepository.Instance.All();

            List<Client> clientList = new List<Client>();

            foreach (var client in MockClientRepository.Instance.All())
            {
                clientList.Add(client);
            }

            if (query == null)
            {
                return View(clientList);
            }
            else
            {
                var editedClientList = clientList.Where(x => x.FirstName.Contains(query.ToString())).ToList();

                if (editedClientList != null)
                {
                    return View(editedClientList);
                }

                return View(clientList);
            }
            
        }

        public IActionResult Details(int id)
        {
            MockClientRepository.Instance.All();

            Client client = MockClientRepository.Instance.FindByID(id);

            if (client !=null)
            {
                return View(client);
            }
            else
            {
                return View();
            }

        }


    }
}
