using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services; // WebMethod attribute

namespace TukkanDeko
{
    public partial class index1 : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            string query = Request.QueryString["query"];
            if (!IsPostBack)
            {
                BindCategories();
            }
        }
        private void BindCategories()
        {
            rp_keychain.DataSource = dm.ProductListKeychain();
            rp_keychain.DataBind();

            rp_trinket.DataSource = dm.ProductListTrinket();
            rp_trinket.DataBind();

            rp_kitchen.DataSource = dm.ProductListKitchen();
            rp_kitchen.DataBind();

            rp_stationary.DataSource = dm.ProductListStationary();
            rp_stationary.DataBind();

            rp_decoration.DataSource = dm.ProductListDecoration();
            rp_decoration.DataBind();

            rp_special.DataSource = dm.ProductListSpecial();
            rp_special.DataBind();

            rp_garden.DataSource = dm.ProductListGarden();
            rp_garden.DataBind();

        }


    }
}