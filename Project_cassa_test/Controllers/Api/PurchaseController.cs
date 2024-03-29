﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_cassa_test.Models;
using System;
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
        [HttpPost]
        public async Task<ActionResult<Purchase>> Post(Purchase purchase)
        {
            context.Purchases.Add(purchase);
            await context.SaveChangesAsync();
            return Ok(purchase);
        }
        [HttpPut]
        public async Task<ActionResult<Purchase>> Put(Purchase purchase)
        {
            context.Update(purchase);
            await context.SaveChangesAsync();
            return Ok(purchase);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Purchase>> Delete(int id)
        {
            Purchase purchase = await context.Purchases.FirstOrDefaultAsync(x => x.Id == id);
            if(purchase==null)
            {
                return NotFound();
            }
            context.Purchases.Remove(purchase);
            await context.SaveChangesAsync();
            return Ok(purchase);
        }
    }
}
