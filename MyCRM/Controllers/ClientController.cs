using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCRM.Data;
using MyCRM.Models;
using MyCRM.ViewModels;

namespace MyCRM.Controllers
{
    public class ClientController : Controller
    {
        private ApplicationDbContext context;
        private UserManager<ApplicationUser> _userManager;

        public ClientController(ApplicationDbContext dbcontext, UserManager<ApplicationUser> userManager)
        {
            context = dbcontext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {

            ApplicationUser currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                IList<ClientForm> clients = context.Client.ToList();

                return View(clients);
            }
            else if (currentUser == null)
            {
                return Redirect("/Home/Index");
            }
            return Redirect("/Home/Index");
        }

        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Add(ClientFormViewModel clientFormViewModel)
        {
            if (ModelState.IsValid)
            {
                ClientForm newClient = new ClientForm
                {
                    FirstName = clientFormViewModel.FirstName,
                    LastName = clientFormViewModel.LastName,
                    CompanyName = clientFormViewModel.CompanyName,
                    Email = clientFormViewModel.Email,
                    PhoneNumber = clientFormViewModel.PhoneNumber,
                    Message = clientFormViewModel.Message
                };

                context.Client.Add(newClient);
                context.SaveChanges();

                return Redirect("/Home/Index");
            }
            return View(clientFormViewModel);
        }

        public IActionResult Clients(int id)
        {
            var clients = context.Client.Find(id);

            return View(clients);
        }

        [HttpPost]
        public IActionResult Clients(ClientForm model)
        {
            if (ModelState.IsValid)
            {
                context.Client.Update(model);
                context.SaveChanges();
            }

            return View();
        }
    }
}