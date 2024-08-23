using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TukkanDeko.AdminBilge
{
    public partial class bindex : System.Web.UI.MasterPage
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                Admin a = (Admin)Session["admin"];

            }
            else
            {
                Response.Redirect("../AdminBilge/signIn.aspx");
            }
            string pageName = System.IO.Path.GetFileName(Request.Path);

            switch (pageName)
            {
                case "categories.aspx":
                    categoriesLink.Attributes["class"] += " active";
                    break;
                case "products.aspx":
                    productsLink.Attributes["class"] += " active";
                    break;
                case "index.aspx": // Assuming this is for the Filament link
                    filamentLink.Attributes["class"] += " active";
                    break;
                default:
                    break;
            }
        }
    }
}