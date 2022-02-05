using Microsoft.AspNetCore.Mvc;
using Project_cassa_test.Models;
using System.Linq;

namespace Project_cassa_test.Controllers
{
    public class AdminController : Controller
    {
        PurchaseContext context;

        public AdminController(PurchaseContext context) 
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Purchases.ToList());
        }
        public IActionResult Create(int? purId)
        {
            if (purId == null)
            {
                return View();
            }
            else
            {
                return View(context.Purchases.FirstOrDefault(x=>x.Id==purId));
            }
        }
        [HttpPost]
        public IActionResult Create(Purchase purchase)
        { if(purchase.Id == 0)
            {
                context.Purchases.Add(purchase);
            }
            else
            {
                context.Update(purchase);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
            
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var ToDelete = context.Purchases.Find(id);
            context.Purchases.Remove(ToDelete);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
