using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TukkanDeko.AdminBilge
{
    public partial class products : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Data();
        }
        public void Data()
        {
            lv_listProduct.DataSource = dm.ProductList();
            lv_listProduct.DataBind();
        }
        protected void lv_product_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.DeleteProduct(id);
                Response.Redirect("~/AdminBilge/products.aspx");
            }
        }
    }
}