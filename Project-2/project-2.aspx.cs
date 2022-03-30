using System;
using System.Collections;
using System.Web.UI.WebControls;
using Utilities;

namespace Project_2
{

    public partial class Project_2 : System.Web.UI.Page
    {
        DBConnect myDB = new DBConnect();
        ArrayList arrProducts = new ArrayList();
        ArrayList totalQuantity = new ArrayList();
        ArrayList totalCostCal = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ShowProducts()
        {
            String sql = "Select * FROM Drinks Where Category = 'Coffee'";
            Coffee.DataSource = myDB.GetDataSet(sql);// always behind the sql
            Coffee.DataBind();

            String sql2 = "Select * FROM Drinks Where Category = 'Tea'";
            Tea.DataSource = myDB.GetDataSet(sql2);
            Tea.DataBind();
        }
        protected void btnConfirmInfo_Click(object sender, EventArgs e)
        {
            btnOrder.Visible = true;
            if (txtFirstName.Text == "" || txtLastName.Text == "" || txtPhoneNum.Text == "" || CheckBox3.Checked == false && CheckBox4.Checked == false && CheckBox4.Checked == false)
            {
                lblinforerror.Text = "Please provide us all your information!!";

            }
            else
            {
                ShowProducts();
                lblinforerror.Visible = false;
            }


        }

        public void GetReceipt()
        {
            UpdaPrice();

        }

        public void UpdaPrice()
        {
            Product objProduct; //  实例化 

            for (int row = 0; row < Coffee.Rows.Count; row++) // loop 整个 gridview 
            {
                objProduct = new Product();  // 实例化 product
                //
                //
                CheckBox cBoxSelectDrink1;
                cBoxSelectDrink1 = (CheckBox)Coffee.Rows[row].FindControl("CheckBox1"); // Get the reference for the chkSelect control in the current row
                DropDownList ddl;
                ddl = (DropDownList)Coffee.Rows[row].FindControl("DropDownList1"); // get the size

                CheckBoxList cBoxType;
                cBoxType = (CheckBoxList)Coffee.Rows[row].FindControl("CheckBoxList1"); // get the hot or ice

                TextBox Tbox;
                Tbox = (TextBox)Coffee.Rows[row].FindControl("TextBox1"); // get the quantity
                //
                //
                if (cBoxSelectDrink1.Checked)
                {
                    //  set value into product 
                    // product（ 人） objproduct （张三）  title, price （是他的手，脚，（组成部分） ）
                    objProduct.ProductTitle = Coffee.Rows[row].Cells[1].Text.ToString();

                    objProduct.ProductDescription = Coffee.Rows[row].Cells[2].Text; // get the description
                    objProduct.ProductPrice = Coffee.Rows[row].Cells[3].Text; // get the price
                    objProduct.ProductSize = ddl.Text;
                    objProduct.ProductType = cBoxType.Text;
                    objProduct.ProductQuantity = Tbox.Text;
                    double NewPrice = UpdatePrice.updatePrice(objProduct);

                    objProduct.productTotal = "$" + NewPrice.ToString();

                    int quantity = Convert.ToInt32(Tbox.Text);
                    totalCostCal.Add(NewPrice);
                    arrProducts.Add(objProduct);
                    totalQuantity.Add(quantity);
                    String sqlTitle = objProduct.ProductTitle;
                    String sqlquantity = Tbox.Text;
                    String sqlNewprice = NewPrice.ToString();
                    String sql = "UPDATE Drinks SET TotalQuantitySold = TotalQuantitySold +" + sqlquantity + "," +
                        "TotalSales = TotalSales +" + sqlNewprice + "WHERE Title = '" + sqlTitle + "'";
                    myDB.DoUpdate(sql);
                }
            }
            for (int row = 0; row < Tea.Rows.Count; row++)
            {
                objProduct = new Product();
                CheckBox cBoxSelectDrink2;
                cBoxSelectDrink2 = (CheckBox)Tea.Rows[row].FindControl("CheckBox2");

                CheckBoxList cBoxType;
                cBoxType = (CheckBoxList)Tea.Rows[row].FindControl("CheckBoxList2");

                DropDownList ddl;
                ddl = (DropDownList)Tea.Rows[row].FindControl("DropDownList2"); // get the size

                TextBox Tbox;
                Tbox = (TextBox)Tea.Rows[row].FindControl("TextBox2");

                if (cBoxSelectDrink2.Checked)
                {
                    // Get the Title from the boyndFiled from the GridView for the current row
                    // and store it into arraylist
                    objProduct.ProductTitle = Tea.Rows[row].Cells[1].Text.ToString();
                    objProduct.ProductDescription = Tea.Rows[row].Cells[2].Text; // get the description
                    objProduct.ProductPrice = Tea.Rows[row].Cells[3].Text; // get the price
                    objProduct.ProductSize = ddl.Text;
                    objProduct.ProductType = cBoxType.Text;
                    objProduct.ProductQuantity = Tbox.Text;
                    objProduct.ProductQuantity = Tbox.Text;
                    int Quantity = Convert.ToInt32(Tbox.Text);
                    double NewPrice = UpdatePrice.updatePrice(objProduct);
                    objProduct.productTotal = "$" + NewPrice.ToString();
                    totalCostCal.Add(NewPrice);
                    totalQuantity.Add(Quantity);
                    arrProducts.Add(objProduct);
                    String sqlTitle = objProduct.ProductTitle;
                    String sqlquantity = Tbox.Text;
                    String sqlNewprice = NewPrice.ToString();
                    String sql = "UPDATE Drinks SET TotalQuantitySold = TotalQuantitySold +" + sqlquantity + "," +
                        "TotalSales = TotalSales +" + sqlNewprice + "WHERE Title = '" + sqlTitle + "'";
                    myDB.DoUpdate(sql);
                }

            }
        }

        public void DisplayManageReport()
        {
            DBConnect manageDB = new DBConnect();
            String sql = "SELECT SUM(TotalSales) AS Total, SUM(TotalQuantitySold) AS Quantity  FROM Drinks ";
            Report.DataSource = manageDB.GetDataSet(sql);
            DataBind();

        }

        public double TotalCal()
        {
            double sum = 0;

            foreach (double i in totalCostCal)
            {
                sum = i + sum;
            }
            return sum;
        }

        public int TotalQuantity()
        {
            int sum = 0;
            foreach (int i in totalQuantity)
            {
                sum = i + sum;
            }
            return sum;
        }
        public void ShowReceipt()
        {
            Coffee.Visible = false;
            Tea.Visible = false;
            lblGVerror.Visible = false;
            Receipt.DataSource = arrProducts;
            Receipt.DataBind();

            Receipt.Columns[0].FooterText = "Grand Total:";
            String TotalCost = TotalCal().ToString();
            Receipt.Columns[6].FooterText = "$ " + TotalCost;
            String Totalquantity = TotalQuantity().ToString();
            Receipt.Columns[5].FooterText = Totalquantity;
            Receipt.DataBind();
        }


        protected void btnOrder_Click(object sender, EventArgs e)
        {
            GetReceipt();

            if (arrProducts.Count <= 0)
            {
                lblGVerror.Text = "Please Select At lease one Drink";
            }
            else
            {
                ShowReceipt();
            }
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            DisplayManageReport();
        }
    }
}




