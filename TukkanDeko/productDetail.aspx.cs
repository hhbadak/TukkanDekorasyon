using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TukkanDeko.AdminBilge;

namespace TukkanDeko
{
    public partial class productDetail : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["mid"]);

                    // GetProduct metodundan dönen tek Product nesnesini bir listeye ekleyin
                    List<Product> productList = new List<Product>();
                    Product product = dm.GetProduct(id);
                    if (product != null)
                    {
                        productList.Add(product);
                    }

                    // Repeater'ı bu liste ile bağlayın
                    rp_detailProduct.DataSource = productList;
                    rp_detailProduct.DataBind();
                }
            }
        }
    }
}