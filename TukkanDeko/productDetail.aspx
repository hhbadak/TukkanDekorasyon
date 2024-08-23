<%@ Page Title="" Language="C#" MasterPageFile="~/index.Master" AutoEventWireup="true" CodeBehind="productDetail.aspx.cs" Inherits="TukkanDeko.productDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <!-- Product Detail -->
    <section class="sec-product-detail bg0 p-t-65 p-b-60">
        <div class="container">
            <asp:Repeater ID="rp_detailProduct" runat="server">
                <ItemTemplate>
                    <div class="row">
                        <div class="col-md-6 col-lg-7 p-b-30">
                            <div class="p-l-25 p-r-30 p-lr-0-lg">
                                <div class="wrap-slick3 flex-sb flex-w">
                                    <div class="wrap-slick3-dots"></div>
                                    <div class="wrap-slick3-arrows flex-sb-m flex-w"></div>

                                    <div class="slick3 gallery-lb">
                                        <div class="item-slick3" data-thumb="../images/product/<%# Eval("Image1") %>">
                                            <div class="wrap-pic-w pos-relative">
                                                <asp:Image ID="image1" runat="server"
                                                    ImageUrl='<%# "../images/product/" + Eval("Image1") %>'
                                                    AlternateText='<%# Eval("Name") %>' />
                                                <a class="flex-c-m size-108 how-pos1 bor0 fs-16 cl10 bg0 hov-btn3 trans-04"
                                                    href="../images/product/<%# Eval("Image1") %>">
                                                    <i class="fa fa-expand"></i>
                                                </a>
                                            </div>
                                        </div>

                                        <!-- Repeat similar structure for Image2 and Image3 -->
                                        <div class="item-slick3" data-thumb="../images/product/<%# Eval("Image2") %>">
                                            <div class="wrap-pic-w pos-relative">
                                                <img src="../images/product/<%# Eval("Image2") %>"
                                                    alt="../images/product/<%# Eval("Name") %>">
                                                <a class="flex-c-m size-108 how-pos1 bor0 fs-16 cl10 bg0 hov-btn3 trans-04"
                                                    href="../images/product/<%# Eval("Image2") %>">
                                                    <i class="fa fa-expand"></i>
                                                </a>
                                            </div>
                                        </div>

                                        <div class="item-slick3" data-thumb="../images/product/<%# Eval("Image3") %>">
                                            <div class="wrap-pic-w pos-relative">
                                                <img src="../images/product/<%# Eval("Image3") %>"
                                                    alt="../images/product/<%# Eval("Name") %>">
                                                <a class="flex-c-m size-108 how-pos1 bor0 fs-16 cl10 bg0 hov-btn3 trans-04"
                                                    href="../images/product/<%# Eval("Image3") %>">
                                                    <i class="fa fa-expand"></i>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>

                        <div class="col-md-6 col-lg-5 p-b-30">
                            <div class="bor10 m-t-50 p-b-40">
                                <!-- Social and Wishlist -->
                                <div class="flex-w flex-m p-l-100 p-t-40 respon7 p-0">
                                    <div class="flex-m p-r-10 m-r-11">
                                        <p class="mtext-105 cl3 p-t-23">
                                            İletişim: <a href="https://wa.me/+905372596733" class="fs-30 cl13 hov-cl1 trans-04 lh-10 p-lr-5 p-tb-2 m-r-8 tooltip100" data-tooltip="Whatsapp">
                                                <i class="fa fa-whatsapp"></i>
                                            </a>

                                            <a href="https://wa.me/+905455562298" class="fs-30 cl13 hov-cl1 trans-04 lh-10 p-lr-5 p-tb-2 m-r-8 tooltip100" data-tooltip="Whatsapp">
                                                <i class="fa fa-whatsapp"></i>
                                            </a>
                                        </p>

                                    </div>

                                </div>

                                <h4 class="mtext-105 cl2 js-name-detail p-b-14"><%# Eval("Name") %></h4>
                                <span class="mtext-106 cl2"><%# Eval("TotalPrice") %>₺</span><br />
                                <div class="p-r-50 p-t-5 p-lr-0-lg">

                                    <!-- Product Tabs -->
                                    <div class="tab01" style="padding-top: 3%">
                                        <ul class="nav nav-tabs" role="tablist">
                                            <li class="nav-item p-b-10">
                                                <a class="nav-link active" data-toggle="tab" href="#description" role="tab">Ürün Açıklaması</a>
                                            </li>
                                            <li class="nav-item p-b-10">
                                                <a class="nav-link" data-toggle="tab" href="#additional-info" role="tab">Özellikler</a>
                                            </li>
                                        </ul>

                                        <div class="tab-content">
                                            <div class="tab-pane fade show active" id="description" role="tabpanel">
                                                <div class="how-pos2 p-lr-15-md">
                                                    <p class="stext-102 cl6">
                                                    <p class="stext-102 cl3 p-t-23"><%# Eval("Description") %></p>
                                                </div>
                                            </div>

                                            <div class="tab-pane fade" id="additional-info" role="tabpanel">
                                                <div class="row">
                                                    <div class="col-sm-10 col-md-8 col-lg-6 m-lr-auto" style="flex: 0 0 100% !important; max-width: 100% !important; padding-top: 3%;">
                                                        <ul class="p-lr-28 p-lr-15-sm">
                                                            <li class="flex-w flex-t p-b-7">
                                                                <span class="stext-102 cl3 size-205">Ağırlık</span>
                                                                <span class="stext-102 cl6 size-206"><%# Eval("Weight") %> gr</span>
                                                            </li>

                                                            <li class="flex-w flex-t p-b-7">
                                                                <span class="stext-102 cl3 size-205">Ölçüler</span>
                                                                <span class="stext-102 cl6 size-206"><%# Eval("Width") %> x <%# Eval("Length") %> x <%# Eval("Height") %> mm</span>
                                                            </li>

                                                            <li class="flex-w flex-t p-b-7">
                                                                <span class="stext-102 cl3 size-205">Ürün Kodu</span>
                                                                <span class="stext-102 cl6 size-206"><%# Eval("Barcode") %></span>
                                                            </li>
                                                        </ul>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <!-- Back to top -->
        <div class="btn-back-to-top" id="myBtn">
            <span class="symbol-btn-back-to-top"><i class="zmdi zmdi-chevron-up"></i></span>
        </div>
    </section>
    <!-- JavaScript Kodları -->
    <script>
        // Sayfa yüklendiğinde veya tab'lar arasında geçiş yapıldığında çalışır
        $(document).ready(function () {
            // Açıklama tab'ına tıklama olayını dinler
            $("a[href='#description']").on("click", function (e) {
                e.preventDefault();
                $("#description").addClass("show active");
                $("#additional-info").removeClass("show active");
            });

            // Özellikler tab'ına tıklama olayını dinler
            $("a[href='#additional-info']").on("click", function (e) {
                e.preventDefault();
                $("#additional-info").addClass("show active");
                $("#description").removeClass("show active");
            });
        });

</script>
</asp:Content>
