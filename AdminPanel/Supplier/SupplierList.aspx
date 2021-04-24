<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MedicalStoreAdminPanel.master" AutoEventWireup="true" CodeFile="SupplierList.aspx.cs" Inherits="AdminPanel_Supplier_SupplierList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- Datatables Plugin -->
    
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=gvSupplier.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
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
                    <h2 class="m-2 text-lg  text-info">Supplier List</h2>
                </div>
                <div class="col-md-2 align-bottom">
                    <asp:HyperLink ID="hlAddSupplier" CssClass="btn btn-primary mr-2 mt-2 btn-sm " runat="server" NavigateUrl="~/AdminPanel/Supplier/SupplierAddEdit.aspx"><i class="fas fa-plus"></i>  Add Supplier</asp:HyperLink>
                </div>
            </div>


        </div>




        <asp:Label ID="lblErrorMessage" runat="server" Text="" EnableViewState="false" CssClass="text-danger"></asp:Label>
        <div class="card-body ">
            <div class="table-responsive table-hover bg-gray-100">
                <asp:GridView ID="gvSupplier" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-sm  text-gray-900" Width="100%" CellSpacing="0" OnRowCommand="gvSupplier_RowCommand">
                    <Columns>
                        
                        <%--<asp:BoundField DataField="SupplierID" HeaderText="SupplierID" />--%>
                        <asp:BoundField DataField="SupplierName" HeaderText="Name" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="ContactNo" HeaderText="ContactNo"  />
                       
                        
                        <asp:TemplateField>
                            <ItemTemplate   >
                                <asp:HyperLink ID="hlEdit" runat="server" CssClass="fas fa-edit" NavigateUrl='<%# "~/AdminPanel/Supplier/SupplierAddEdit.aspx?SupplierID=" + Eval("SupplierID").ToString() %>'></asp:HyperLink>&nbsp&nbsp
                                <asp:LinkButton ID="lbDelete" runat="server" CssClass="fas fa-trash" CommandName="DeleteSupplier" CommandArgument='<%# Eval("SupplierID") %>'></asp:LinkButton>
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

