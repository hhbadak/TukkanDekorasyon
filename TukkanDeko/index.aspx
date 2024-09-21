<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="TukkanDeko.index1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Product -->
    <div class="bg0 m-t-23 p-b-140">
        <div class="container">
            <div class="flex-w flex-sb-m p-b-52">
                <div class="col-lg-12 flex-w flex-l-m filter-tope-group m-tb-10">
                    <button class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5 how-active1" data-filter="*">
                        All Products
                    </button>

                    <button class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5" data-filter=".keychain">
                        Anahtarlık
                    </button>

                    <button class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5" data-filter=".trinket">
                        Biblo
                    </button>

                    <button class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5" data-filter=".kitchen">
                        Mutfak Gereçleri
                    </button>

                    <button class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5" data-filter=".stationary">
                        Kırtasiye
                    </button>

                    <button class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5" data-filter=".decoration">
                        Dekorasyon
                    </button>

                    <button class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5" data-filter=".special">
                        Kişiye Özel
                    </button>

                    <button class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5" data-filter=".garden">
                        Bahçe Gereçleri
                    </button>

                     <button class="stext-106 cl6 hov1 bor3 trans-04 m-r-32 m-tb-5" data-filter=".phonestand">
                        Telefon Tutacağı
                    </button>
                </div>

                <asp:Repeater ID="rp_keychain" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-6 col-md-4 col-lg-3 p-b-35 isotope-item keychain">
                            <!-- Block2 -->
                            <div class="block2">
                                <div class="block2-pic hov-img0">
                                    <img src="
                                        
                                        
                                        
                                        
                                        /images/product/<%# Eval("Image1") %>" loading="lazy" style="max-width: 423px; max-height: 423px;" alt="<%# Eval("Name") %>">
                                    <a href='productDetail.aspx?mid=<%# Eval("ID") %>' class="block2-btn flex-c-m stext-103 cl2 size-102 bg0 bor2 hov-btn1 p-lr-15 trans-04">İncele
                                    </a>
                                </div>
                                <div class="block2-txt flex-w flex-t p-t-14">
                                    <div class="block2-txt-child1 flex-col-l ">
                                        <span class="stext-105 cl3"><%# Eval("Name") %>
                                        </span>
                                        <span class="stext-105 cl3"><%# Eval("TotalPrice") %>₺
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Repeater ID="rp_trinket" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-6 col-md-4 col-lg-3 p-b-35 isotope-item trinket">
                            <!-- Block2 -->
                            <div class="block2">
                                <div class="block2-pic hov-img0">
                                    <img src="
                                        
                                        /images/product/<%# Eval("Image1") %>" loading="lazy" style="max-width: 423px; max-height: 423px;" alt="<%# Eval("Name") %>">
                                    <a href='productDetail.aspx?mid=<%# Eval("ID") %>' class="block2-btn flex-c-m stext-103 cl2 size-102 bg0 bor2 hov-btn1 p-lr-15 trans-04">İncele
                                    </a>
                                </div>
                                <div class="block2-txt flex-w flex-t p-t-14">
                                    <div class="block2-txt-child1 flex-col-l ">
                                        <span class="stext-105 cl3"><%# Eval("Name") %>
                                        </span>
                                        <span class="stext-105 cl3"><%# Eval("TotalPrice") %>₺
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Repeater ID="rp_kitchen" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-6 col-md-4 col-lg-3 p-b-35 isotope-item kitchen">
                            <!-- Block2 -->
                            <div class="block2">
                                <div class="block2-pic hov-img0">
                                    <img src="../images/product/<%# Eval("Image1") %>" loading="lazy" style="max-width: 423px; max-height: 423px;" alt="<%# Eval("Name") %>">
                                    <a href='productDetail.aspx?mid=<%# Eval("ID") %>' class="block2-btn flex-c-m stext-103 cl2 size-102 bg0 bor2 hov-btn1 p-lr-15 trans-04">İncele
                                    </a>
                                </div>
                                <div class="block2-txt flex-w flex-t p-t-14">
                                    <div class="block2-txt-child1 flex-col-l ">
                                        <span class="stext-105 cl3"><%# Eval("Name") %>
                                        </span>
                                        <span class="stext-105 cl3"><%# Eval("TotalPrice") %>₺
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Repeater ID="rp_stationary" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-6 col-md-4 col-lg-3 p-b-35 isotope-item stationary">
                            <!-- Block2 -->
                            <div class="block2">
                                <div class="block2-pic hov-img0">
                                    <img src="../images/product/<%# Eval("Image1") %>" loading="lazy" style="max-width: 423px; max-height: 423px;" alt="<%# Eval("Name") %>">
                                    <a href='productDetail.aspx?mid=<%# Eval("ID") %>' class="block2-btn flex-c-m stext-103 cl2 size-102 bg0 bor2 hov-btn1 p-lr-15 trans-04">İncele
                                    </a>
                                </div>
                                <div class="block2-txt flex-w flex-t p-t-14">
                                    <div class="block2-txt-child1 flex-col-l ">
                                        <span class="stext-105 cl3"><%# Eval("Name") %>
                                        </span>
                                        <span class="stext-105 cl3"><%# Eval("TotalPrice") %>₺
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Repeater ID="rp_decoration" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-6 col-md-4 col-lg-3 p-b-35 isotope-item decoration">
                            <!-- Block2 -->
                            <div class="block2">
                                <div class="block2-pic hov-img0">
                                    <img src="../images/product/<%# Eval("Image1") %>" loading="lazy" style="max-width: 423px; max-height: 423px;" alt="<%# Eval("Name") %>">
                                    <a href='productDetail.aspx?mid=<%# Eval("ID") %>' class="block2-btn flex-c-m stext-103 cl2 size-102 bg0 bor2 hov-btn1 p-lr-15 trans-04">İncele
                                    </a>
                                </div>
                                <div class="block2-txt flex-w flex-t p-t-14">
                                    <div class="block2-txt-child1 flex-col-l ">
                                        <span class="stext-105 cl3"><%# Eval("Name") %>
                                        </span>
                                        <span class="stext-105 cl3"><%# Eval("TotalPrice") %>₺
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Repeater ID="rp_special" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-6 col-md-4 col-lg-3 p-b-35 isotope-item special">
                            <!-- Block2 -->
                            <div class="block2">
                                <div class="block2-pic hov-img0">
                                    <img src="../images/product/<%# Eval("Image1") %>" loading="lazy" style="max-width: 423px; max-height: 423px;" alt="<%# Eval("Name") %>">
                                    <a href='productDetail.aspx?mid=<%# Eval("ID") %>' class="block2-btn flex-c-m stext-103 cl2 size-102 bg0 bor2 hov-btn1 p-lr-15 trans-04">İncele
                                    </a>
                                </div>
                                <div class="block2-txt flex-w flex-t p-t-14">
                                    <div class="block2-txt-child1 flex-col-l ">
                                        <span class="stext-105 cl3"><%# Eval("Name") %>
                                        </span>
                                        <span class="stext-105 cl3"><%# Eval("TotalPrice") %>₺
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Repeater ID="rp_garden" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-6 col-md-4 col-lg-3 p-b-35 isotope-item garden">
                            <!-- Block2 -->
                            <div class="block2">
                                <div class="block2-pic hov-img0">
                                    <img src="../images/product/<%# Eval("Image1") %>" loading="lazy" style="max-width: 423px; max-height: 423px;" alt="<%# Eval("Name") %>">
                                    <a href='productDetail.aspx?mid=<%# Eval("ID") %>' class="block2-btn flex-c-m stext-103 cl2 size-102 bg0 bor2 hov-btn1 p-lr-15 trans-04">İncele
                                    </a>
                                </div>
                                <div class="block2-txt flex-w flex-t p-t-14">
                                    <div class="block2-txt-child1 flex-col-l ">
                                        <span class="stext-105 cl3"><%# Eval("Name") %>
                                        </span>
                                        <span class="stext-105 cl3"><%# Eval("TotalPrice") %>₺
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Repeater ID="rp_phonestand" runat="server">
                    <ItemTemplate>
                        <div class="col-sm-6 col-md-4 col-lg-3 p-b-35 isotope-item garden">
                            <!-- Block2 -->
                            <div class="block2">
                                <div class="block2-pic hov-img0">
                                    <img src="../images/product/<%# Eval("Image1") %>" loading="lazy" style="max-width: 423px; max-height: 423px;" alt="<%# Eval("Name") %>">
                                    <a href='productDetail.aspx?mid=<%# Eval("ID") %>' class="block2-btn flex-c-m stext-103 cl2 size-102 bg0 bor2 hov-btn1 p-lr-15 trans-04">İncele
                                    </a>
                                </div>
                                <div class="block2-txt flex-w flex-t p-t-14">
                                    <div class="block2-txt-child1 flex-col-l ">
                                        <span class="stext-105 cl3"><%# Eval("Name") %>
                                        </span>
                                        <span class="stext-105 cl3"><%# Eval("TotalPrice") %>₺
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>


    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.filter-tope-group button').on('click', function (e) {
                e.preventDefault(); // Butonun varsayılan davranışını engeller

                var filter = $(this).attr('data-filter');

                if (filter === '*') {
                    $('.isotope-item').show();
                } else {
                    $('.isotope-item').hide();
                    $(filter).show();
                }

                $('.filter-tope-group button').removeClass('how-active1');
                $(this).addClass('how-active1');
            });
        });

    </script>

</asp:Content>
