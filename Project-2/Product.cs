using System;

namespace Project_2
{
    public class Product
    {
        public String productTitle;

        public String productDescription;

        public String productPrice;

        public String productSize;

        public String productType;

        public String productQuantity;

        public String productTotal;

        public String totalCost;
        public String ProductTitle
        {
            get { return productTitle; }
            set { productTitle = value; }
        }

        public String ProductDescription
        {
            get { return productDescription; }
            set { productDescription = value; }
        }
        public String ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value; }
        }

        public String ProductSize
        {
            get { return productSize; }
            set { productSize = value; }
        }
        public String ProductType
        {
            get { return productType; }
            set { productType = value; }
        }

        public String ProductQuantity
        {
            get { return productQuantity; }
            set { productQuantity = value; }
        }

        public String ProductTotal
        {
            get { return productTotal; }
            set { productTotal = value; }
        }

        public String TotalCost
        {
            get;
            set;
        }



    }


}