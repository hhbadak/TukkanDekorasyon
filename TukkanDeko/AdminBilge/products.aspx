<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBilge/bindex.Master" AutoEventWireup="true" CodeBehind="products.aspx.cs" Inherits="TukkanDeko.AdminBilge.products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid pt-4 px-4">
        <div class="row g-4">
            <div class="col-lg-12 col-sm-12 col-xl-6" style="width: 100%">
                <div class="m-n2">
                    <a href="../AdminBilge/createProduct.aspx" class="btn btn-outline-primary w-100 m-2" type="button">Ürün EKLE</a>
                </div>
            </div>
            <div class="col-12">
                <div class="bg-secondary rounded h-100 p-4">
                    <h6 class="mb-4">Ürünler</h6>
                    <div class="table-responsive">
                        <asp:ListView ID="lv_listProduct" runat="server" DataKeyNames="ID" OnItemCommand="lv_product_ItemCommand">
                            <LayoutTemplate>
                                <table class="table" cellpadding="0" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th scope="col">#</th>
                                            <th scope="col">Ürün Adı</th>
                                            <th scope="col">Açıklama</th>
                                            <th scope="col">Kategori Adı</th>
                                            <th scope="col">Ürün Maliyeti</th>
                                            <th scope="col">Genişlik</th>
                                            <th scope="col">Uzunluk</th>
                                            <th scope="col">Yükseklik</th>
                                            <th scope="col">Ağırlık</th>
                                            <th scope="col">Barcode</th>
                                            <th scope="col">Resim</th>
                                            <th scope="col">Kullanılan Filament</th>
                                            <th scope="col">Seçenekler</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <tr>
                                    <th scope="row"><%# Eval("ID") %></th>
                                    <td><%# Eval("Name") %></td>
                                    <td><%# Eval("Description") %></td>
                                    <td><%# Eval("Category") %></td>
                                    <td><%# Eval("Price") %>₺</td>
                                    <td><%# Eval("Width") %>mm</td>
                                    <td><%# Eval("Length") %>mm</td>
                                    <td><%# Eval("Height") %>mm</td>
                                    <td><%# Eval("Weight") %>gr</td>
                                    <td><%# Eval("Barcode") %></td>
                                    <td> <img src="../images/product/<%# Eval("Image1") %>" width="30" /></td>
                                    <td><%# Eval("Filament") %></td>
                                    <td>
                                        <a href='../AdminBilge/updateProduct.aspx?mid=<%# Eval("ID") %>' class="duzenle"><i class="fa fa-user-edit me-2"></i></a>
                                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="sil" CommandArgument='<%# Eval("ID") %>' CommandName="delete"><i class="fa fa-trash"></i></asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
