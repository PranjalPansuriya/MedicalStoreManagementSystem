<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerateInvoice.aspx.cs" Inherits="AdminPanel_Selling_GenerateInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="UTF-8">
    <title>Medical Store Management System</title>

    <!-- Custom fonts for this template-->
    <link href="../../Content/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@300&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Playfair+Display:wght@400;500&display=swap" rel="stylesheet" />
    <!-- Custom styles for this template-->
    <link href="../../Content/css/sb-admin-2.css" rel="stylesheet" />
    <%--<script src="https://cdnjs.cloudflare.com/ajax/libs/html2pdf.js/0.9.3/html2pdf.bundle.js"></script>--%>
</head>
<body style="background-color: azure">
    <form id="form1" runat="server">
        <br/>
        <div class="row ">
            
            <div class="col-md-1 text-right common" style="font-size:15px">
                <asp:HyperLink ID="hlGoBack" runat="server" ForeColor="#073e1b" NavigateUrl="~/AdminPanel/Customer/CustomerList.aspx"><i class="fas fa-arrow-left"></i>  Go Back</asp:HyperLink>
            </div>
            <div class="col-md-3 text-right mt-2">
                <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Content/img/MyLogo.png" Height="100px" Width="120px" />
            </div>
            <div class="col-md-6">
                <div class="personal-heading text-left" style="font-size: 3.5em; color: #117922; text-shadow: 1.5px 0.2px #b9a4a4">
                    Best Care Pharmacy 
                </div>
                <div class="col-md-8 text-right" style="color: #476146">
                    <span class="personal-heading">we care for your better health.</span>
                </div>
            </div>

            <div class="col-md-2 common text-left" style="font-size: 1em;">
                OrderID :
                <asp:Label ID="lblOrderID" runat="server" Text=""></asp:Label>
            </div>
        </div>

        <hr />
        <asp:Panel ID="billPanel" runat="server">
            <div class="container ">
                <div class="row text-center text-gray-800">
                    <div class="col-md-6 common" style="font-size: 1em;">
                        Customer Name :
                        <asp:Label ID="lblCustomerName" runat="server" Text=""></asp:Label>
                        <br />
                        Payment Method :
                        <asp:Label ID="lblPaymentMethod" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="col-md-6 common  text-gray-800" style="font-size: 1em;">
                        Mobile No. :
                        <asp:Label ID="lblMobileNo" runat="server" Text=""></asp:Label>
                        <br />
                        Order Date :
                        <asp:Label ID="lblOrderDate" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            <hr />
            <div class="container">
                <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="text-danger"></asp:Label>

                <div class="table-responsive table-hover shadow-sm bg-gray-100" style="border-radius: 10px;">
                    <asp:GridView ID="gvProductList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-sm  text-gray-900" Width="100%" CellSpacing="0">
                        <Columns>
                            <asp:BoundField DataField="ProductName" HeaderText="Products" HeaderStyle-CssClass="text-center" />
                            <asp:BoundField DataField="ProductQuantity" HeaderText="Quantity" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                            <asp:BoundField DataField="PricePerUnit" HeaderText="Price Per Unit" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                            <asp:BoundField DataField="Multiplication" HeaderText="Price" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                        </Columns>
                    </asp:GridView>
                </div>

                <br />
                <div class="row">
                    <div class="col-md-11 text-right common text-gray-800 font-weight-bold ">
                        Total Amount : 
                    <asp:Label ID="lblTotalAmount" runat="server" Text=""></asp:Label>
                    </div>
                </div>

            </div>
        </asp:Panel>
        <div class="mt-5 row">
            <div class="col-md-7 text-right common">
                Thanks And Regards...&#128512;
                
            </div>
            <div class="col-md-5 text-center common">
                <asp:Button ID="btnGenerateInvoice" runat="server" Text="Generate Invoice" CssClass="btn btn-sm btn-dark" OnClientClick="generateInvoice()" />
            </div>
        </div>

    </form>
    <!-- Bootstrap core JavaScript-->
    <script src="../../Content/vendor/jquery/jquery.min.js"></script>
    <script src="../../Content/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="../../Content/vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="../../Content/js/sb-admin-2.min.js"></script>
    <script>
        function generateInvoice() {
            javascript: window.print();
        };
    </script>
</body>
</html>
