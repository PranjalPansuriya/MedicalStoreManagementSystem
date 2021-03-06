<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPanel_Login_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Login</title>

    <!-- Custom fonts for this template-->
    <link href="vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css"/>
    <link
        href="https://fonts.googleapis.com/css2?family=Montserrat:wght@400&family=Roboto&display=swap"
        rel="stylesheet"/>

    <!-- Custom styles for this template-->
    <link href="../../Content/css/sb-admin-2.css" rel="stylesheet"/>
</head>
<body class="bg-background-image">
    <form id="form1" runat="server">
        <div class="container">

            <!-- Outer Row -->
            <div class="row justify-content-center">

                <div class="col-xl-12 col-lg-12 col-md-9">

                    <div class="card o-hidden border-0 shadow my-5   ">
                        <div class="card-body p-0">
                            <!-- Nested Row within Card Body -->
                            <div class="row">
                                <div class="col-lg-6 d-none d-lg-block bg-Login-image ">
                                </div>
                                <div class="col-lg-6">
                                    <div class="p-5">
                                        <div class="text-left">
                                            <h1 class="text-gray-800 h4 mb-4 ">Login here.. &#128512</h1>
                                        </div>
                                        <div class="text-center">
                                            <h4 class="h5 text-danger">
                                                <asp:Label ID="lblLogin" runat="server" Text=""></asp:Label>
                                            </h4>
                                        </div>
                                        <form class="user">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtUserName" runat="server" class="form-control form-control-user shadow-sm" placeholder="Enter UserName"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ErrorMessage="Enter UserName" CssClass="text-danger" Display="Dynamic" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>

                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox ID="txtPassword" runat="server" class="form-control form-control-user shadow-sm" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Enter Password" Display="Dynamic" CssClass="text-danger" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                                            </div>

                                            <asp:Button ID="btnLogin" runat="server" Text="Login" class="btn btn-success shadow-lg align-content-center " OnClick="btnLogin_Click"/>
                                            <hr>
                                        </form>
                                        <hr>

                                       
                                    </div>
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

    <!-- Custom scripts for all pages-->
    <script src="../../Content/js/sb-admin-2.min.js"></script>
</body>
</html>
