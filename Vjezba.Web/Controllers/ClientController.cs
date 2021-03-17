using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Vjezba.Web.Mock;
using Vjezba.Web.Models;

namespace Vjezba.Web.Controllers
{
    public class ClientController : Controller
    {
        // <tab class="..... @(ViewBag.ActiveTab == 1 ? "active" : "")"> ...
        [HttpGet]
        public IActionResult Index(string query)
        {

            MockClientRepository.Instance.All();

            List<Client> clientList = new List<Client>();

            foreach (var client in MockClientRepository.Instance.All())
            {
                clientList.Add(client);
            }

            if (query != null)
            {
                var queryTmp = clientList.Where(x => x.FirstName.Contains(query.ToString())).ToList();
                clientList = queryTmp;
            }

            if (clientList != null)
            {
                return View(clientList);
            }

            return View(clientList);

        }

        [HttpPost]
        public IActionResult Index(string queryName, string queryAdress)
        {
            MockClientRepository.Instance.All();

            List<Client> clientList = new List<Client>();

            foreach (var client in MockClientRepository.Instance.All())
            {
                clientList.Add(client);
            }

            if (queryName != null)
            {
                var queryTmp = clientList.Where(x => x.FirstName.Contains(queryName.ToString())).ToList();
                clientList = queryTmp;
            }
            if (queryAdress != null)
            {
                var queryTmp = clientList.Where(x => x.Address.Contains(queryName.ToString())).ToList();
                clientList = queryTmp;
            }

            if (clientList != null)
            {
                return View(clientList);
            }
      
            return View(clientList);
        }

        [HttpPost]
        public IActionResult AdvancedSearch(ClientFilterModel model)
        {
            string _dioNazivaKlijenta = model.DioNazivaKlijenta;
            string _dioEmaila = model.DioEmaila;
            string _dioAdrese = model.DioAdrese;
            string _dioNazivaGrada = model.DioNazivaGrada;

            MockClientRepository.Instance.All();

            List<Client> clientList = new List<Client>();

            foreach (var client in MockClientRepository.Instance.All())
            {
                clientList.Add(client);
            }


            if (_dioNazivaKlijenta != null)
            {
                var queryTmp = clientList.Where(x => x.FirstName.Contains(_dioNazivaKlijenta.ToString())).ToList();
                clientList = queryTmp;
            }
            if (_dioEmaila != null)
            {
                var queryTmp = clientList.Where(x => x.Email.Contains(_dioEmaila.ToString())).ToList();
                clientList = queryTmp;
            }
            if (_dioAdrese != null)
            {
                var queryTmp = clientList.Where(x => x.Address.Contains(_dioAdrese.ToString())).ToList();
                clientList = queryTmp;
            }
            if (_dioNazivaGrada != null)
            {
 
                    var queryTmp = clientList.Where(x => (string)x.City.Name.i .Contains(_dioNazivaGrada.ToString())).ToList();
                    clientList = queryTmp;
                
            }

            if (clientList != null)
            {
                return View("Index",clientList);
            }

            return View("Index", clientList);

        }



        public IActionResult Details(int id)
        {
            MockClientRepository.Instance.All();

            Client client = MockClientRepository.Instance.FindByID(id);

            if (client != null)
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
