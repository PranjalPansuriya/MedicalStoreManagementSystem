<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MedicalStoreAdminPanel.master" AutoEventWireup="true" CodeFile="EmployeeAddEdit.aspx.cs" Inherits="AdminPanel_Employee_EmployeeAddEdit" Debug="true" %>

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
                                Name :
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtEmployeeName" runat="server" class="form-control " placeholder="Enter Name"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmployeeName" runat="server" ErrorMessage="Enter Name" Display="Dynamic" ControlToValidate="txtEmployeeName" CssClass="text-danger" ValidationGroup="AddEmployee"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="row align-items-center">
                            <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                                Address :
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtAddress" runat="server" class="form-control " placeholder="Enter Address" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Enter Address" Display="Dynamic" ControlToValidate="txtAddress" CssClass="text-danger" ValidationGroup="AddEmployee"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="row align-items-center">
                            <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                                BirthDate :
                            </div>
                            <div class="col-md-5">
                                <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control form-control-user " autocomplete="off" placeholder="Select Birthdate"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" ErrorMessage="Select Birthdate" Display="Dynamic" CssClass="text-danger" ControlToValidate="txtBirthDate" ValidationGroup="AddEmployee"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="row align-items-center">
                            <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                                MobileNo :
                            </div>
                            <div class="col-md-5">
                                <asp:TextBox ID="txtMobileNo" runat="server" class="form-control " placeholder="Enter MobileNo"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ErrorMessage="Enter MobileNo" Display="Dynamic" ControlToValidate="txtMobileNo" CssClass="text-danger" ValidationGroup="AddEmployee"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revMobileNo" runat="server" ControlToValidate="txtMobileNo" Display="Dynamic" ErrorMessage="Enter Valid MobileNo" ValidationExpression="[0-9]{10}" CssClass="text-danger" ValidationGroup="AddEmployee"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <br />

                        <div class="row align-items-center">
                            <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                                Email :
                            </div>
                            <div class="col-md-8">
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control " placeholder="Enter Email Address"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Enter Email Address" Display="Dynamic" ControlToValidate="txtEmail" CssClass="text-danger" ValidationGroup="AddEmployee"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter Valid Email Address" ValidationExpression="^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$" CssClass="text-danger" ValidationGroup="AddEmployee"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <br />
                        <div class="row align-items-center">
                            <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                                Post :
                            </div>
                            <div class="col-md-5">
                                <asp:TextBox ID="txtPost" runat="server" class="form-control " placeholder="Enter Your Post"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvPost" runat="server" ErrorMessage="Enter Your Post" Display="Dynamic" ControlToValidate="txtPost" CssClass="text-danger" ValidationGroup="AddEmployee"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div class="row align-items-center">
                            <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                                Joining Date :
                            </div>
                            <div class="col-md-5">
                                <asp:TextBox ID="txtJoiningDate" runat="server" CssClass="form-control form-control-user" autocomplete="off" placeholder="Select Joining Date"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvJoiningDate" runat="server" ErrorMessage="Select Joining Date" Display="Dynamic" CssClass="text-danger" ControlToValidate="txtJoiningDate" ValidationGroup="AddEmployee"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br/>

                    <div class="row">
                        <div class="col-4"></div>
                        <div class="col-4 row">
                            <div class="col-5 text-right">
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success icon " ValidationGroup="AddEmployee" OnClick="btnSave_Click" Visible="True"></asp:Button>

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
            $("#<%=txtBirthDate.ClientID%>").datepicker({
                format: "mm/dd/yyyy",
                changeYear: true,
                changeMonth: true,
                inline: true,
                autoclose: true,
                todayHighlight: true,
            });
        });
        $(document).ready(function () {
            $("#<%=txtJoiningDate.ClientID%>").datepicker({
                format: "mm/dd/yyyy",
                changeYear: true,
                changeMonth: true,
                inline: true,
                autoclose: true,
                todayHighlight: true,
            });
        });
    </script>
    <!-- Custom scripts for all pages-->
    <script src="<%=ResolveClientUrl("~/Content/js/sb-admin-2.js")%>"></script>
</asp:Content>

