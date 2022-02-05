using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_cassa_test.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_cassa_test.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : Controller
    {
        private readonly PurchaseContext context;

        public PurchaseController(PurchaseContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult<IEnumerable<Purchase>>> Get()
        {
            return await context.Purchases.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task <ActionResult<Purchase>> Get(int id)
        {
            Purchase purchase = await context.Purchases.FirstOrDefaultAsync(x => x.Id == id);
            if(purchase == null)
            {
                return NotFound();
            }
            return purchase;
        }
    }
}
