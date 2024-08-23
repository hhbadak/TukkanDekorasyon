using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TukkanDeko.AdminBilge
{
    public partial class signIn : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbl_email.Text) && !string.IsNullOrEmpty(lbl_password.Text))
            {
                Admin t = dm.AdminLogin(lbl_email.Text, lbl_password.Text);
                if (t != null)
                {
                    Session["admin"] = t;
                    Response.Redirect("../AdminBilge/bindex.aspx");
                }
                else
                {
                    //pnl_hata.Visible = true;
                    //lbl_hata.Text = "Kullanıcı Bulunamadı";
                }
            }
            else
            {
                //pnl_hata.Visible = true;
                //lbl_hata.Text = "Kullanıcı Adı ve Şifre Boş olamaz";
            }
        }
    }
}