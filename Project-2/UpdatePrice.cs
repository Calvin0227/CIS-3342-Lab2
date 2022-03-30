using System;

namespace Project_2
{
    public static class UpdatePrice
    {


        public static double updatePrice(Product objProduct)
        {
            // Product product = new Product();
            // Price = double.Parse(product.ProductPrice);
            double Price = double.Parse(objProduct.ProductPrice.ToString().Replace("$", ""));
            String Size = objProduct.productSize;
            switch (Size)
            {
                case "Small":
                    Price *= 1;
                    break;
                case "Tall":
                    Price *= 1.5;
                    break;
                case "Grande":
                    Price *= 1.8;
                    break;
                case "Venti":
                    Price *= 2.0;
                    break;
                case "Trenta":
                    Price *= 2.3;
                    break;
            }
            Price *= double.Parse(objProduct.productQuantity);
            return Price;
        }






    }
}