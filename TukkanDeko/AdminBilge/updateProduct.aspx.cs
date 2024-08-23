using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TukkanDeko.AdminBilge
{
    public partial class updateProduct : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request.QueryString["mid"]);

                // Category dropdown list binding
                var categories = dm.CategoryList();
                if (categories != null)
                {
                    ddl_category.DataTextField = "Name";
                    ddl_category.DataValueField = "ID";
                    ddl_category.DataSource = categories;
                    ddl_category.DataBind();
                }

                // Filament dropdown list binding
                var filaments = dm.ListFilament();
                if (filaments != null)
                {
                    ddl_productFilament.DataTextField = "Name";
                    ddl_productFilament.DataValueField = "ID";
                    ddl_productFilament.DataSource = filaments;
                    ddl_productFilament.DataBind();
                }

                Product p = dm.GetProduct(id);

                ddl_category.SelectedValue = p.CategoryID.ToString();
                ddl_productFilament.SelectedValue = p.FilamentID.ToString();
                tb_productWidth.Text = p.Width;
                tb_productHeight.Text = p.Height;
                tb_productWeight.Text = p.Weight.ToString();
                tb_productName.Text = p.Name;
                tb_productLength.Text = p.Length;
                tb_productDescription.Text = p.Description;
                tb_barcode.Text = p.Barcode;
                img_picture1.ImageUrl = "~/images/product/" + p.Image1;
                img_picture2.ImageUrl = "~/images/product/" + p.Image2;
                img_picture3.ImageUrl = "~/images/product/" + p.Image3;
                img_picture4.ImageUrl = "~/images/product/" + p.Image4;
                img_picture5.ImageUrl = "~/images/product/" + p.Image5;
                tb_profitMargin.Text = p.ProfitMargin.ToString();
            }
        }

        protected void lbtn_update_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["mid"]);

            Product pro = dm.GetProduct(id);
            pro.Name = tb_productName.Text;
            pro.Description = tb_productDescription.Text;
            pro.CategoryID = Convert.ToInt32(ddl_category.SelectedItem.Value);
            pro.FilamentID = Convert.ToInt32(ddl_productFilament.SelectedItem.Value);
            pro.Width = tb_productWidth.Text;
            pro.Height = tb_productHeight.Text;
            pro.Weight = Convert.ToDecimal(tb_productWeight.Text);
            pro.Length = tb_productLength.Text;
            pro.Barcode = tb_barcode.Text;
            pro.ProfitMargin = Convert.ToDecimal(tb_profitMargin.Text);
            if (fu_picture1.HasFile)
            {
                FileInfo fi = new FileInfo(fu_picture1.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".jpeg")
                {
                    string uzanti = fi.Extension;
                    string isim = Guid.NewGuid().ToString();
                    pro.Image1 = isim + uzanti;
                    fu_picture1.SaveAs(Server.MapPath("~/images/product/" + isim + uzanti));
                }
                else
                {
                    string script = "alert('Resim Uzantısı Yalnızca jpg,jpeg veya png olabilir');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "GirisHataScript", script, true);
                }
            }
            if (fu_picture2.HasFile)
            {
                FileInfo fi = new FileInfo(fu_picture2.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".jpeg")
                {
                    string uzanti = fi.Extension;
                    string isim = Guid.NewGuid().ToString();
                    pro.Image2 = isim + uzanti;
                    fu_picture2.SaveAs(Server.MapPath("~/images/product/" + isim + uzanti));
                }
                else
                {
                    string script = "alert('Resim Uzantısı Yalnızca jpg,jpeg veya png olabilir');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "GirisHataScript", script, true);
                }
            }
            if (fu_picture3.HasFile)
            {
                FileInfo fi = new FileInfo(fu_picture3.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".jpeg")
                {
                    string uzanti = fi.Extension;
                    string isim = Guid.NewGuid().ToString();
                    pro.Image3 = isim + uzanti;
                    fu_picture3.SaveAs(Server.MapPath("~/images/product/" + isim + uzanti));
                }
                else
                {
                    string script = "alert('Resim Uzantısı Yalnızca jpg,jpeg veya png olabilir');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "GirisHataScript", script, true);
                }
            }
            if (fu_picture4.HasFile)
            {
                FileInfo fi = new FileInfo(fu_picture4.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".jpeg")
                {
                    string uzanti = fi.Extension;
                    string isim = Guid.NewGuid().ToString();
                    pro.Image4 = isim + uzanti;
                    fu_picture4.SaveAs(Server.MapPath("~/images/product/" + isim + uzanti));
                }
                else
                {
                    string script = "alert('Resim Uzantısı Yalnızca jpg,jpeg veya png olabilir');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "GirisHataScript", script, true);
                }
            }
            if (fu_picture5.HasFile)
            {
                FileInfo fi = new FileInfo(fu_picture5.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".jpeg")
                {
                    string uzanti = fi.Extension;
                    string isim = Guid.NewGuid().ToString();
                    pro.Image5 = isim + uzanti;
                    fu_picture5.SaveAs(Server.MapPath("~/images/product/" + isim + uzanti));
                }
                else
                {
                    string script = "alert('Resim Uzantısı Yalnızca jpg,jpeg veya png olabilir');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "GirisHataScript", script, true);
                }
            }
            if (dm.UpdateProduct(pro))
            {
                Response.Redirect("../AdminBilge/products.aspx");
            }
            else
            {
                string script = "alert('Ürün Güncelleme İşlemi BAŞARISIZ!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "GirisHataScript", script, true);
            }
        }
    }
}