using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TukkanDeko.AdminBilge
{
    public partial class categories : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_category.DataSource = dm.CategoryList();
            rp_category.DataBind();

        }

        protected void saveCategory_Click(object sender, EventArgs e)
        {

            Category cat = new Category();
            cat.Name = tb_category.Text;
            if (dm.CreateCategory(cat))
            {
                Response.Redirect("../AdminBilge/categories.aspx");
            }
            else
            {
                string script = "alert('Kayıt işlemi başarısız oldu. Lütfen tekrar deneyiniz.');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
        }
    }
}