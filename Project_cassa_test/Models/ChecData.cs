using System.Linq;

namespace Project_cassa_test.Models
{
    public static class ChecData
    {
        public static void Init(PurchaseContext context)
        {
            if(!context.Purchases.Any())
            {
                context.Purchases.AddRange(

                    new Purchase
                    {
                        Products = "Milk",
                        Price = 23
                        
                    },
                    new Purchase
                    {
                        Products = "Bread",
                        Price = 26
                        

                    },
                    new Purchase
                    {
                        Products = "Water",
                        Price = 45
                        

                    },
                    new Purchase
                    {
                        Products = "Apple",
                        Price = 34
                        

                    },
                    new Purchase
                    {
                        Products = "Orange",
                        Price = 34
                        

                    },
                    new Purchase
                    {
                        Products = "Meat",
                        Price = 56
                        

                    }
                    );
                    
                        context.SaveChanges();
            }
        }
    }
}
