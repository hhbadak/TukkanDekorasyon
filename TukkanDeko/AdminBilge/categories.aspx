<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBilge/bindex.Master" AutoEventWireup="true" CodeBehind="categories.aspx.cs" Inherits="TukkanDeko.AdminBilge.categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid pt-4 px-4">
        <div class="row g-4">
            <div class="col-lg-12 col-sm-12 col-xl-6" style="width: 100%">
                <div class="m-n2">
                    <a href="#" class="btn btn-outline-primary w-100 m-2" type="button" data-toggle="modal" data-target="#addCategoryModal">Kategori EKLE</a>
                </div>
            </div>
            <div class="col-12">
                <div class="bg-secondary rounded h-100 p-4">
                    <h6 class="mb-4">Responsive Table</h6>
                    <div class="table-responsive">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Kategori Adı</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rp_category" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <th scope="row"><%# Eval("ID") %></th>
                                            <td><%# Eval("Name") %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <!-- Modal -->
    <div class="modal fade" id="addCategoryModal" tabindex="-1" role="dialog" aria-labelledby="addCategoryModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content" style="background-color: lightslategray !important;">
                <div class="modal-header">
                    <h5 class="modal-title" style="color:black" id="addCategoryModalLabel">Kategori Ekle</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-floating mb-3">
                        <asp:TextBox class="form-control" for="categoryName" runat="server" ID="tb_category"></asp:TextBox>
                        <label style="color:aliceblue" for="floatingInput">Kategori Adı Giriniz</label>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Kapat</button>
                    <asp:LinkButton ID="saveCategory" runat="server" class="btn btn-primary" OnClick="saveCategory_Click">Kaydet</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
