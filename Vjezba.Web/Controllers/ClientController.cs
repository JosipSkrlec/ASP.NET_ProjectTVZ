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

        public IActionResult Index(string query = null)
        {
            var clientQuery = MockClientRepository.Instance.All();

            if (!string.IsNullOrWhiteSpace(query))
                clientQuery = clientQuery.Where(p => p.FullName.ToLower().Contains(query));

            ViewBag.ActiveTab = 5;

            return View(clientQuery.ToList());
        }

        [HttpPost]
        public ActionResult Index(string queryName, string queryAddress)
        {
            var clientQuery = MockClientRepository.Instance.All();

            //Primjer iterativnog građenja upita - dodaje se "where clause" samo u slučaju da je parametar doista proslijeđen.
            //To rezultira optimalnijim stablom izraza koje se kvalitetnije potencijalno prevodi u SQL
            if (!string.IsNullOrWhiteSpace(queryName))
                clientQuery = clientQuery.Where(p => p.FullName.ToLower().Contains(queryName));

            if (!string.IsNullOrWhiteSpace(queryAddress))
                clientQuery = clientQuery.Where(p => p.Address.ToLower().Contains(queryAddress));

            ViewBag.ActiveTab = 2;

            var model = clientQuery.ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult AdvancedSearch(ClientFilterModel filter)
        {
            var clientQuery = MockClientRepository.Instance.All();

            //Primjer iterativnog građenja upita - dodaje se "where clause" samo u slučaju da je parametar doista proslijeđen.
            //To rezultira optimalnijim stablom izraza koje se kvalitetnije potencijalno prevodi u SQL
            if (!string.IsNullOrWhiteSpace(filter.FullName))
                clientQuery = clientQuery.Where(p => p.FullName.ToLower().Contains(filter.FullName.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Address))
                clientQuery = clientQuery.Where(p => p.Address.ToLower().Contains(filter.Address.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Email))
                clientQuery = clientQuery.Where(p => p.Email.ToLower().Contains(filter.Email.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.City))
                clientQuery = clientQuery.Where(p => p.City != null && p.City.Name.ToLower().Contains(filter.City.ToLower()));

            ViewBag.ActiveTab = 3;

            var model = clientQuery.ToList();
            return View("Index", model);
        }


        public IActionResult Details(int? id = null)
        {
            var model = id != null ? MockClientRepository.Instance.FindByID(id.Value) : null;
            return View(model);
        }

        // Zadatak 6.4
        public IActionResult Create()
        {           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Client clientInfo)
        {
            Client client = new Client();

            MockClientRepository.Instance.All();

            client.ID = clientInfo.ID;

            client.FirstName = clientInfo.FirstName;

            client.LastName = clientInfo.LastName;

            client.Address = clientInfo.Address;

            client.City.Name = "Zagreb";
            client.City.ID= 200;

            client.Email = clientInfo.Email;

            client.Gender = clientInfo.Gender;

            client.PhoneNumber = clientInfo.PhoneNumber;



            MockClientRepository.Instance.InsertOrUpdate(client);

            return View();
        }


    }
}

// TMP

//[HttpPost]
//public IActionResult AdvancedSearch(ClientFilterModel model)
//{
//    ViewBag.TabIndicator = 3;

//    string _dioNazivaKlijenta = model.DioNazivaKlijenta;
//    string _dioEmaila = model.DioEmaila;
//    string _dioAdrese = model.DioAdrese;
//    string _dioNazivaGrada = model.DioNazivaGrada;

//    MockClientRepository.Instance.All();

//    List<Client> clientList = new List<Client>();

//    foreach (var client in MockClientRepository.Instance.All())
//    {
//        clientList.Add(client);
//    }


//    if (_dioNazivaKlijenta != null)
//    {
//        var queryTmp = clientList.Where(x => x.FirstName.Contains(_dioNazivaKlijenta.ToString())).ToList();
//        clientList = queryTmp;
//    }
//    if (_dioEmaila != null)
//    {
//        var queryTmp = clientList.Where(x => x.Email.Contains(_dioEmaila.ToString())).ToList();
//        clientList = queryTmp;
//    }
//    if (_dioAdrese != null)
//    {
//        var queryTmp = clientList.Where(x => x.Address.Contains(_dioAdrese.ToString())).ToList();
//        clientList = queryTmp;
//    }
//    if (_dioNazivaGrada != null)
//    {

//        var queryTmp = clientList.Where(x => x.City is not null && x.City.Name.Contains(_dioNazivaGrada.ToString())).ToList();
//        clientList = queryTmp;

//    }

//    if (clientList != null)
//    {
//        return View("Index",clientList);
//    }

//    return View("Index", clientList);

//}


//[HttpGet]
//public IActionResult Index(string query)
//{
//    ViewBag.TabIndicator = 1;

//    MockClientRepository.Instance.All();

//    List<Client> clientList = new List<Client>();

//    foreach (var client in MockClientRepository.Instance.All())
//    {
//        clientList.Add(client);
//    }

//    if (query != null)
//    {
//        var queryTmp = clientList.Where(x => x.FirstName.Contains(query.ToString())).ToList();
//        clientList = queryTmp;
//    }

//    if (clientList != null)
//    {
//        return View(clientList);
//    }

//    return View(clientList);

//}


//[HttpPost]
//public IActionResult Index(string queryName, string queryAdress)
//{
//    ViewBag.TabIndicator = 2;

//    MockClientRepository.Instance.All();

//    List<Client> clientList = new List<Client>();

//    foreach (var client in MockClientRepository.Instance.All())
//    {
//        clientList.Add(client);
//    }

//    if (queryName != null)
//    {
//        var queryTmp = clientList.Where(x => x.FirstName.Contains(queryName.ToString())).ToList();
//        clientList = queryTmp;
//    }
//    if (queryAdress != null)
//    {
//        var queryTmp = clientList.Where(x => x.Address.Contains(queryAdress.ToString())).ToList();
//        clientList = queryTmp;
//    }

//    if (clientList != null)
//    {
//        return View(clientList.ToList());
//    }

//    return View(clientList.ToList());
//}

//public IActionResult Details(int id)
//{
//    MockClientRepository.Instance.All();

//    Client client = MockClientRepository.Instance.FindByID(id);

//    if (client != null)
//    {
//        return View(client);
//    }
//    else
//    {
//        return View();
//    }

//}