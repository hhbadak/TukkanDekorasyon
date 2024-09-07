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
    public partial class createProduct : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_category.DataTextField = "Name";
                ddl_category.DataValueField = "ID";
                ddl_category.DataSource = dm.CategoryList();
                ddl_category.DataBind();

                ddl_productFilament.DataTextField = "Name";
                ddl_productFilament.DataValueField = "ID";
                ddl_productFilament.DataSource = dm.ListFilament();
                ddl_productFilament.DataBind();
            }
        }

        protected void lbtn_create_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ddl_category.SelectedItem.Value) != 0)
            {
                if (Convert.ToInt32(ddl_productFilament.SelectedItem.Value) != 0)
                {
                    Product p = new Product();
                    p.Name = tb_productName.Text;
                    p.Description = tb_productDescription.Text;
                    p.CategoryID = Convert.ToInt32(ddl_category.SelectedItem.Value);
                    p.Width = tb_productWidth.Text;
                    p.Length = tb_productLength.Text;
                    p.Height = tb_productHeight.Text;
                    p.Weight = Convert.ToDecimal(tb_productWeight.Text);
                    p.Barcode = tb_barcode.Text;
                    p.ProfitMargin = Convert.ToInt32(tb_profitMargin.Text);
                    p.FilamentID = Convert.ToInt32(ddl_productFilament.SelectedItem.Value);
                    p.Image4 = "none.png";
                    p.Image5 = "none.png";
                    if (fu_picture1.HasFile)
                    {
                        FileInfo fi = new FileInfo(fu_picture1.FileName);
                        if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".jpeg" || fi.Extension == ".JPG")
                        {
                            string uzanti = fi.Extension;
                            string isim = Guid.NewGuid().ToString();
                            p.Image1 = isim + uzanti;
                            fu_picture1.SaveAs(Server.MapPath("~/images/product/" + isim + uzanti));
                        }
                        else
                        {
                            string script = "alert('Resim Uzantısı Yalnızca jpg,jpeg veya png olabilir');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "GirisHataScript", script, true);
                        }
                    }
                    else
                    {
                        p.Image1 = "none.png";
                    }
                    if (fu_picture2.HasFile)
                    {
                        FileInfo fi = new FileInfo(fu_picture2.FileName);
                        if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".jpeg" || fi.Extension == ".JPG")
                        {
                            string uzanti = fi.Extension;
                            string isim = Guid.NewGuid().ToString();
                            p.Image2 = isim + uzanti;
                            fu_picture2.SaveAs(Server.MapPath("~/images/product/" + isim + uzanti));
                        }
                        else
                        {
                            string script = "alert('Resim Uzantısı Yalnızca jpg,jpeg veya png olabilir');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "GirisHataScript", script, true);
                        }
                    }
                    else
                    {
                        p.Image2 = "none.png";
                    }
                    if (fu_picture3.HasFile)
                    {
                        FileInfo fi = new FileInfo(fu_picture3.FileName);
                        if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".jpeg" || fi.Extension == ".JPG")
                        {
                            string uzanti = fi.Extension;
                            string isim = Guid.NewGuid().ToString();
                            p.Image3 = isim + uzanti;
                            fu_picture3.SaveAs(Server.MapPath("~/images/product/" + isim + uzanti));
                        }
                        else
                        {
                            string script = "alert('Resim Uzantısı Yalnızca jpg,jpeg veya png olabilir');";
                            ScriptManager.RegisterStartupScript(this, GetType(), "GirisHataScript", script, true);
                        }
                    }
                    else
                    {
                        p.Image3 = "none.png";
                    }
                    if (dm.CreateProduct(p))
                    {
                        string script = "alert('TEBRİKLER Ürün ekleme işlemini tamamladınız');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "GirisHataScript", script, true);
                        ddl_category.SelectedValue = "0";
                        ddl_productFilament.SelectedValue = "0";
                        tb_barcode.Text = tb_productDescription.Text = tb_productHeight.Text = tb_productLength.Text = tb_productName.Text = tb_productWeight.Text = tb_productWidth.Text = tb_profitMargin.Text = "";
                    }
                    else
                    {
                        string script = "alert('aa ürün ekleme işleminde bir sorun var :( ');";
                        ScriptManager.RegisterStartupScript(this, GetType(), "GirisHataScript", script, true);
                    }
                }
                else
                {
                    string script = "alert('Filament seçimi yap kırmıym ağzını!');";
                    ScriptManager.RegisterStartupScript(this, GetType(), "GirisHataScript", script, true);
                }
            }
            else
            {
                string script = "alert('Kategori seçimi yap kırmıym ağzını!');";
                ScriptManager.RegisterStartupScript(this, GetType(), "GirisHataScript", script, true);
            }
        }
    }
}