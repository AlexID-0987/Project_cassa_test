using System.Collections.Generic;
using System.Linq;

namespace Project_cassa_test.Models
{
    public class Cart
    {
        private List<CartLine> lineCollecion = new List<CartLine>();
        public void AddItem(Purchase purchase,int quantity)
        {
            CartLine line = lineCollecion.FirstOrDefault(x => x.Purchase.Id == purchase.Id);
            if(line == null)
            {
                lineCollecion.Add(new CartLine
                { 
                    Purchase= purchase,
                    Quantity= quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void Remove(Purchase purchase)
        {
            lineCollecion.RemoveAll(x=>x.Purchase.Id== purchase.Id);
        }
        public void Clear()
        {
            lineCollecion.Clear();
        }
        public int Comlute()
        {
            return lineCollecion.Sum(x => x.Purchase.Price * x.Quantity);
        }
        public IEnumerable<CartLine> Lines
        {
            get => lineCollecion;
        }
        
    }

    public class CartLine
    {
        public Purchase Purchase { get; set; }
        public int Quantity { get; set; }
    }
}
