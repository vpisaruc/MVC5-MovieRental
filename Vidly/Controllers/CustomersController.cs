using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using AutoMapper;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        // HttpPost - мы декларируем, что это действие посылае только пост запросы
        [HttpPost]
        // по хорошему надо создать класс CustommerUpdate в котором дать доступ к полям Name и BirthDate
        public ActionResult Save(Customer customer)
        {
            // если клиента нет в базе данных, то добавляем его в бд
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                // вместо этих 4 строчек можно сделать так Mapper.Map(customer, customerInDb)
                Mapper.Map(customer, customerInDb);
                /*customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;*/
            }

            _context.SaveChanges();

            // после добавления нового юзера редиректим на страницу со всеми пользователями
            return RedirectToAction("Index", "Customers");
        }

        public ViewResult Index()
        {
            //Get all custommers from DB
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            // Показывает, что в нашем клиенте будет отображаться MembershipType,
            // SingleOrDefault(c => c.Id == id) высвечивать всех клиентов
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };

            return View("CustomerForm", viewModel);
        }
    }
}