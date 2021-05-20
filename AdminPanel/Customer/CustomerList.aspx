<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MedicalStoreAdminPanel.master" AutoEventWireup="true" CodeFile="CustomerList.aspx.cs" Inherits="AdminPanel_Customer_CustomerList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- Datatables Plugin -->
    
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=gvCustomer.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
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

        <div class="card-header">
            <div class="row">
                <div class="col-md-10">
                    <h2 class="m-2 text-lg  text-info">Customer List</h2>
                </div>
                <div class="col-md-2 align-bottom">
                    <asp:HyperLink ID="hlAddCustomer" CssClass="btn btn-success shadow-lg mr-2 mt-2 btn-sm " runat="server" NavigateUrl="~/AdminPanel/Customer/CustomerAddEdit.aspx"><i class="fas fa-plus"></i>  Add Customer</asp:HyperLink>
                </div>
            </div>


        </div>




        <asp:Label ID="lblErrorMessage" runat="server" Text="" EnableViewState="false" CssClass="text-danger"></asp:Label>
        <div class="card-body ">
            <div class="table-responsive table-hover bg-gray-100">
                <asp:GridView ID="gvCustomer" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-sm  text-gray-900" Width="100%" CellSpacing="0">
                    <Columns>
                        
                        <%--<asp:BoundField DataField="CustomerID" HeaderText="CustomerID" />--%>
                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
                        <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" />
                        <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" />
                        
                        <asp:TemplateField>
                            <ItemTemplate   >
                                <%--<asp:HyperLink ID="hlEdit" runat="server" CssClass="fas fa-edit" NavigateUrl='<%# "~/AdminPanel/Customer/CustomerAddEdit.aspx?CustomerID=" + Eval("CustomerID").ToString() %>'></asp:HyperLink>&nbsp&nbsp--%>
                                 <asp:HyperLink ID="hlSellingPanel" runat="server"  CssClass="fas fa-shopping-cart " ForeColor="#073e1b" NavigateUrl='<%# "~/AdminPanel/Selling/SellingPanel.aspx?CustomerID=" + Eval("CustomerID").ToString() %>'></asp:HyperLink>&nbsp&nbsp
                               <%-- <asp:LinkButton ID="lbDelete" runat="server" CssClass="fas fa-trash" CommandName="DeleteCustomer" CommandArgument='<%# Eval("CustomerID") %>'></asp:LinkButton>&nbsp&nbsp   
                                <asp:HyperLink ID="hlCustomerDetail" runat="server" CssClass="far fa-eye" NavigateUrl='<%# "~/AdminPanel/Customer/CustomerDetail.aspx?CustomerID=" + Eval("CustomerID").ToString() %>'></asp:HyperLink>--%>
                               
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>

        </div>
    </div>
    <script src="<%=ResolveClientUrl("~/Content/vendor/jquery/Jquery-3.5.1.min.js")%>"></script>
    <%--Script for sweetAlert--%>
    <script>
        function deleteAlert() {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Record Deleted Successfully',
                showConfirmButton: false,
                timer: 1500
            })
        }
        
    </script>
    <%--Script for sweetAlert--%>
</asp:Content>

