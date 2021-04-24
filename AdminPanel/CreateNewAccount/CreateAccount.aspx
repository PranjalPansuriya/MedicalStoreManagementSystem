<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateAccount.aspx.cs" Inherits="AdminPanel_CreateNewAccount_CreateAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Create Account</title>

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <link
        href="https://fonts.googleapis.com/css?family=Nunito:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet">

    <!-- Custom styles for this template-->
    <link href="../../Content/css/sb-admin-2.css" rel="stylesheet">
    <link href="../../Content/vendor/DatePicker/bootstrap-datepicker.css" rel="stylesheet" />
    <link href="../../Content//vendor/DatePicker/bootstrap.min.css" rel="stylesheet" />
    <!-- Interal CSS for Datepicker-->
    <style>
        .datepicker td, .datepicker th {
            width: 2rem;
            height: 2rem; 
            font-size: 0.85rem;
        }

        .datepicker {
            margin-top: 3rem;
        }
    </style>
    <!-- Interal CSS for Datepicker-->
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

            <div class="card o-hidden border-0 shadow-lg my-5">
                <div class="card-body p-0">
                    <!-- Nested Row within Card Body -->
                    <div class="row">
                        <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>
                        <div class="col-lg-7">
                            <div class="p-5">
                                <div class="text-center">
                                    <h1 class="h4 text-gray-900 mb-4">Create an Account</h1>
                                </div>
                                <form class="user">
                                    <div class="form-group ">
                                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control form-control-user" placeholder="Enter Name"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Enter Name" Display="Dynamic" CssClass="text-danger" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-6 mb-3 mb-sm-0">
                                            <asp:TextBox ID="txtBirthDate" runat="server" CssClass=" form-control form-control-user " autocomplete="off" placeholder="Select Birthdate"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" ErrorMessage="Select Birthdate" Display="Dynamic" CssClass="text-danger" ControlToValidate="txtBirthDate"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-sm-6  mb-3 mb-sm-0">
                                            <asp:TextBox ID="txtMobileNo" runat="server" CssClass=" form-control form-control-user " placeholder="Enter MobileNo"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvMobileNo" runat="server" ErrorMessage="Enter MobileNo" Display="Dynamic" CssClass="text-danger" ControlToValidate="txtMobileNo"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Address" CssClass="form-control form-control-user" Rows="0" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="Enter Address" Display="Dynamic" CssClass="text-danger" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass=" form-control form-control-user " placeholder="Enter Email Address"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Enter Email Address" Display="Dynamic" CssClass="text-danger" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-6 mb-3 mb-sm-0">
                                            <asp:TextBox ID="txtJoiningDate" runat="server" CssClass=" form-control form-control-user date-time" autocomplete="off" placeholder="Select Joining Date"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvJoiningDate" runat="server" ErrorMessage="Select Joining Date" Display="Dynamic" CssClass="text-danger" ControlToValidate="txtJoiningDate"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-sm-6  mb-3 mb-sm-0">
                                            <asp:DropDownList ID="ddlPost" placeholder="Select Post" CssClass="form-control form-control-user" runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvPost" runat="server" ErrorMessage="Select Post" Display="Dynamic" CssClass="text-danger" ControlToValidate="ddlPost"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-group row">
                                        <div class="col-sm-6 mb-3 mb-sm-0">
                                            <asp:TextBox ID="txtPassword" runat="server" CssClass=" form-control form-control-user" autocomplete="off" placeholder="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Enter Password" Display="Dynamic" CssClass="text-danger" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass=" form-control form-control-user" autocomplete="off" placeholder="Confirm Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ErrorMessage="Reenter Password" Display="Dynamic" CssClass="text-danger" ControlToValidate="txtConfirmPassword"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <asp:Button ID="btnCreateAccount" runat="server" Text="Register Account" CssClass="btn btn-primary btn-user btn-block" />

                                    <hr>
                                </form>
                                <div class="text-center">
                                    <a class="small" href="../Login/Login.aspx">Already have an account? Login!</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
    <!-- Bootstrap core JavaScript-->
    <script src="../../Content/vendor/jquery/jquery.min.js"></script>
    <script src="../../Content/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="../../Content/vendor/jquery-easing/jquery.easing.min.js"></script>
    <script src="../../Content/vendor/jquery/Jquery-3.5.1.min.js"></script>

    <script src="../../Content/vendor/DatePicker/bootstrap-datepicker.min.js"></script>


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
    <script src="../../Content/js/sb-admin-2.js"></script>
</body>
</html>
