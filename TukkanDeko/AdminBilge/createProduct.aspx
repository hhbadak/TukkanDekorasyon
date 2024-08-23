<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBilge/bindex.Master" AutoEventWireup="true" CodeBehind="createProduct.aspx.cs" Inherits="TukkanDeko.AdminBilge.createProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-4 px-4">
        <div class="bg-secondary rounded h-100 p-4">
            <div class="row g-4">
                <div class="col-sm-6 col-xl-6">
                    <h6 class="mb-4">Ürün Ekleme</h6>
                    <div class="input-group mb-3">

                        <div class="bg-secondary rounded h-100 p-0" style="width: 100%;">
                            <label for="basic-url" class="form-label">Ürün Adı</label>
                            <asp:TextBox ID="tb_productName" runat="server" CssClass="form-control mb-3" placeholder="Ürün Adı"></asp:TextBox>
                        </div>

                        <div class="input-group mb-3">
                            <span class="input-group-text">Ürün Açıklaması</span>
                            <asp:TextBox ID="tb_productDescription" runat="server" CssClass="form-control"
                                TextMode="MultiLine" Placeholder="Açıklama"></asp:TextBox>
                        </div>

                        <div class="bg-secondary rounded h-100 p-0 w-100">
                            <label for="basic-url" class="form-label">Ürün Kategorisi</label>
                            <asp:DropDownList ID="ddl_category" runat="server" Enabled="true" CssClass="form-select mb-3" AppendDataBoundItems="true">
                                <asp:ListItem Text="Seçiniz" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div class="bg-secondary rounded h-100 p-0">
                            <label for="basic-url" class="form-label">Genişlik</label>
                            <asp:TextBox ID="tb_productWidth" runat="server" CssClass="form-control" Placeholder="Genişlik"></asp:TextBox>
                        </div>

                        <div class="bg-secondary rounded h-100 pl-2">
                            <label for="basic-url" class="form-label">Uzunluk</label>
                            <asp:TextBox ID="tb_productLength" runat="server" CssClass="form-control" Placeholder="Uzunluk"></asp:TextBox>
                        </div>

                        <div class="bg-secondary rounded h-100 p-0">
                            <label for="basic-url" class="form-label">Yükseklik</label>
                            <asp:TextBox ID="tb_productHeight" runat="server" CssClass="form-control" Placeholder="Yükseklik"></asp:TextBox>
                        </div>

                        <div class="bg-secondary rounded h-100 pl-2">
                            <label for="basic-url" class="form-label">Ağırlık</label>
                            <asp:TextBox ID="tb_productWeight" runat="server" CssClass="form-control" Placeholder="Ağırlık"></asp:TextBox>
                        </div>

                        <div class="bg-secondary rounded h-100 p-0">
                            <label for="basic-url" class="form-label">Barkod No</label>
                            <asp:TextBox ID="tb_barcode" runat="server" CssClass="form-control" Placeholder="Barkod"></asp:TextBox>
                        </div>

                        <div class="bg-secondary rounded h-100 pl-2">
                            <label for="basic-url" class="form-label">Kâr Marjı</label>
                            <asp:TextBox ID="tb_profitMargin" runat="server" CssClass="form-control" Placeholder="ProfitMargin"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="col-sm-6 col-xl-6">

                    <div class="mb-3">
                        <label for="basic-url" class="form-label">Resim 1</label>
                        <asp:Image ID="img_picture1" runat="server" Style="width: 100px" /><br />
                        <asp:FileUpload ID="fu_picture1" runat="server" CssClass="form-control bg-dark" AllowMultiple="true" />

                    </div>

                    <div class="mb-3">
                        <label for="basic-url" class="form-label">Resim 2</label>
                        <asp:Image ID="img_picture2" runat="server" Style="width: 100px" /><br />
                        <asp:FileUpload ID="fu_picture2" runat="server" CssClass="form-control bg-dark" AllowMultiple="true" />
                    </div>

                    <div class="mb-3">
                        <label for="basic-url" class="form-label">Resim 3</label>
                        <asp:Image ID="img_picture3" runat="server" Style="width: 100px" /><br />
                        <asp:FileUpload ID="fu_picture3" runat="server" CssClass="form-control bg-dark" AllowMultiple="true" />
                    </div>

                    <div class="mb-3">
                        <label for="basic-url" class="form-label">Kullanılan Filament</label>
                        <asp:DropDownList ID="ddl_productFilament" runat="server" Enabled="true" CssClass="form-select mb-3" AppendDataBoundItems="true">
                            <asp:ListItem Text="Seçiniz" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="row">
                    <asp:LinkButton ID="lbtn_create" runat="server" Text="GÜNCELLE" CssClass="btn btn-primary btn-lg" OnClick="lbtn_create_Click"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
