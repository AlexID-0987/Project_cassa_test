using Microsoft.AspNetCore.Mvc;
using Project_cassa_test.Extench;
using Project_cassa_test.Models;
using Project_cassa_test.Models.ViewModels;
using System.Linq;

namespace Project_cassa_test.Controllers
{
    public class CartController : Controller
    {
        PurchaseContext context;

        public CartController(PurchaseContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string returnUrl)
        {
            var cart=GetCart();
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturtUrl = returnUrl   
            });
        }
        public IActionResult AddtoItem(int Id,string returnUrl)
        {
            Purchase purchase = context.Purchases.FirstOrDefault(x => x.Id == Id);
            if(purchase != null)
            {
                var cart=GetCart();
                cart.AddItem(purchase, 1);
                HttpContext.Session.SetObjectAsJson("Cart",cart);
            }
            return RedirectToAction("Index", new {returnUrl});
        }
        public IActionResult RemoveItem()
        {
            return null;
        }
        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
                if (cart == null)
            {
                cart=new Cart();
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return cart;
        }
        
    }
}
