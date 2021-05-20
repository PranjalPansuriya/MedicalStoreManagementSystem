<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MedicalStoreAdminPanel.master" AutoEventWireup="true" CodeFile="CustomerAddEdit.aspx.cs" Inherits="AdminPanel_Customer_CustomerAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTopbarHeading" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphAlerts" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphMessages" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphProfile" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="cphPageContent" Runat="Server">
    <div class="card  shadow mb-4">
        <div class="card-header py-2">
            <h3 class="m-2 text-lg  text-info">
                <asp:Label ID="lblHeading" runat="server" Text=""></asp:Label>
            </h3>
        </div>
        <div class="card-body ">
            <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="text-danger" EnableViewState="false"></asp:Label>
            <div class="card border-left-info shadow-lg h-100 py-2 m-4  bg-gray-200"  >
                <div class="card-body" >
                    <div class="row align-items-center">
                        <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                            Customer Name :
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtCustomerName" runat="server" class="form-control shadow-sm" placeholder="Enter Name"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCustomerName" runat="server" ErrorMessage="Enter Name" Display="Dynamic" ControlToValidate="txtCustomerName" CssClass="text-danger" ValidationGroup="AddCustomer"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row align-items-center">
                        <div class="col-md-3 text-right text-gray-700 font-weight-bold text-uppercase">
                            ContactNo :
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtContactNo" runat="server" class="form-control shadow-sm" placeholder="Enter ContactNo"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ErrorMessage="Enter ContactNo" Display="Dynamic" ControlToValidate="txtContactNo" CssClass="text-danger" ValidationGroup="AddCustomer"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revContactNo" runat="server" ControlToValidate="txtContactNo" Display="Dynamic" ErrorMessage="Enter Valid ContactNo" ValidationExpression="[0-9]{10}" CssClass="text-danger" ValidationGroup="AddCustomer"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    
                    <br />
                    
                    <div class="row">
                        <div class="col-4"></div>
                        <div class="col-4 row">
                            <div class="col-5 text-right">
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" ValidationGroup="AddCustomer" OnClick="btnSave_Click" Visible="True"></asp:Button>

                            </div>
                            <div class="col-1"></div>
                            <div class="col-5 text-left">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn shadow-lg" OnClick="btnCancel_Click"/>
                            </div>
                        </div>
                        <div class="col-4"></div>

                    </div>
                </div>

            </div>
        </div>
    </div>
    <script src="<%=ResolveClientUrl("~/Content/vendor/jquery/Jquery-3.5.1.min.js")%>"></script>
</asp:Content>

