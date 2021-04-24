<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MedicalStoreAdminPanel.master" AutoEventWireup="true" CodeFile="ProductAddEdit.aspx.cs" Inherits="AdminPanel_Product_ProductAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Custom styles for this template-->
    <link href="<%=ResolveClientUrl("~/Content/css/sb-admin-2.css")%>" rel="stylesheet" />
    <link href="<%=ResolveClientUrl("~/Content/vendor/DatePicker/bootstrap-datepicker.css")%>"  rel="stylesheet"/>
    <!-- Interal CSS for Datepicker-->
    <style>
        .datepicker td, .datepicker th {
            width: 2rem;
            height: 2rem;
            font-size: 0.85rem;
        }

        .datepicker {
            margin-top: 1rem;
        }
    </style>
    <script> 
        function insertAlert() {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Record Added Successfully',
                showConfirmButton: false,
                timer: 1500
            })
        };
        
    </script>
    <!-- Interal CSS for Datepicker-->
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTopbarHeading" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphAlerts" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMessages" runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphProfile" runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPageContent" runat="Server">
    <div class="card  shadow mb-4">
        <div class="card-header py-2">
            <h3 class="m-2 text-lg  text-info">
                <asp:Label ID="lblHeading" runat="server" Text=""></asp:Label>
            </h3>
        </div>
        <div class="card-body ">
            <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="text-danger" EnableViewState="false"></asp:Label>
            <div class="card border-left-info shadow h-100 py-2 m-4  bg-gray-200">
                <div class="card-body">
                    <div class="row align-items-center">
                        <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                            Product Name :
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtProductName" runat="server" class="form-control " placeholder="Enter ProductName"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvProductName" runat="server" ErrorMessage="Enter Prdouct Name" Display="Dynamic" ControlToValidate="txtProductName" CssClass="text-danger" ValidationGroup="AddProduct"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row align-items-center">
                        <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                            Product Catgeory :
                        </div>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddlProductCategory" runat="server" CssClass="form-control" ValidationGroup="AddProduct"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvProductCategory" runat="server" ErrorMessage="Select Product Category" Display="Dynamic" ControlToValidate="ddlProductCategory" CssClass="text-danger" ValidationGroup="AddProduct" InitialValue="-1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row align-items-center">
                        <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                            Company Name :
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtCompanyName" runat="server" class="form-control " placeholder="Enter CompanyName"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ErrorMessage="Enter CompanyName" Display="Dynamic" ControlToValidate="txtCompanyName" CssClass="text-danger" ValidationGroup="AddProduct"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row align-items-center">
                        <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                            Supplier Name :
                        </div>
                        <div class="col-md-8">
                            <asp:DropDownList ID="ddlSupplierName" runat="server" CssClass="form-control" ValidationGroup="AddProduct"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvSupplierName" runat="server" ErrorMessage="Select Supplier Name" Display="Dynamic" ControlToValidate="ddlSupplierName" CssClass="text-danger" ValidationGroup="AddProduct" InitialValue="-1"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />

                    <div class="row align-items-center">
                        <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                            Quantity :
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtQuantity" runat="server" TextMode="Number" min="1" class="form-control " placeholder="Enter Quantity of Product"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ErrorMessage="Enter Quantity of Product" Display="Dynamic" ControlToValidate="txtQuantity" CssClass="text-danger" ValidationGroup="AddProduct"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row align-items-center">
                        <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                            Delivery Date :
                        </div>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtDeliveryDate" runat="server" CssClass="form-control   date-time" autocomplete="off" placeholder="Select Date of Delivery"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDeliveryDate" runat="server" ErrorMessage="Select Date of Delivery" Display="Dynamic" CssClass="text-danger" ControlToValidate="txtDeliveryDate" ValidationGroup="AddProduct"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row align-items-center">
                        <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                            Expiry Date :
                        </div>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="form-control   date-time" autocomplete="off" placeholder="Select Date of Expiry"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvExpiryDate" runat="server" ErrorMessage="Select Date of Expiry" Display="Dynamic" CssClass="text-danger" ControlToValidate="txtExpiryDate" ValidationGroup="AddProduct"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row align-items-center">
                        <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                            Price Per Unit :
                        </div>
                        <div class="col-md-5">
                            <asp:TextBox ID="txtPricePerUnit" runat="server" CssClass="form-control   date-time" autocomplete="off" placeholder="Enter Price Per Unit"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPricePerUnit" TextMode="Number" runat="server" ErrorMessage="Enter Price Per Unit" Display="Dynamic" CssClass="text-danger" ControlToValidate="txtPricePerUnit" ValidationGroup="AddProduct"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revPricePerUnit" runat="server" ErrorMessage="Enter Valid price" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtPricePerUnit" ValidationGroup="AddProduct" ValidationExpression="^\d*\.?\d*$"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row align-items-center">
                        <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                            Location :
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtLocation" runat="server" class="form-control " placeholder="Enter Location of Product"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ErrorMessage="Enter Location of Product" Display="Dynamic" ControlToValidate="txtLocation" CssClass="text-danger" ValidationGroup="AddProduct"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row align-items-center">
                        <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                            Other Description :
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtOtherDescription" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-4"></div>
                        <div class="col-4 row">
                            <div class="col-5 text-right">
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success icon " ValidationGroup="AddProduct" OnClick="btnSave_Click" Visible="True"></asp:Button>

                            </div>
                            <div class="col-1"></div>
                            <div class="col-5 text-left">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                        <div class="col-4"></div>

                    </div>
                </div>

            </div>
        </div>
    </div>
    <!-- Core plugin JavaScript-->
    <script src="<%=ResolveClientUrl("~/Content/vendor/jquery-easing/jquery.easing.min.js")%>"></script>
    <script src="<%=ResolveClientUrl("~/Content/vendor/jquery/Jquery-3.5.1.min.js")%>"></script>
    <script src="<%=ResolveClientUrl("~/Content/vendor/DatePicker/bootstrap.bundle.min.js")%>"></script>
    <script src="<%=ResolveClientUrl("~/Content/vendor/DatePicker/bootstrap-datepicker.min.js")%>"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtExpiryDate.ClientID%>").datepicker({

                format: "mm/dd/yyyy",
                changeYear: true,
                changeMonth: true,
                inline: true,
                autoclose: true,
                todayHighlight: true,
            });
        });
        $(document).ready(function () {
            $("#<%=txtDeliveryDate.ClientID%>").datepicker({
                format: "mm/dd/yyyy",
                changeYear: true,
                changeMonth: true,
                inline: true,
                autoclose: true,
                todayHighlight: true,
            });
        });
        
    </script>
   <script src="<%=ResolveClientUrl("~/Content/js/sb-admin-2.js")%>"></script>
</asp:Content>

