<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MedicalStoreAdminPanel.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="AdminPanel_Product_ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!-- Datatables Plugin -->
    
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=gvProduct.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
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
                    <h2 class="m-2 text-lg  text-info">Product List</h2>
                </div>
                <div class="col-md-2 align-bottom">
                    <asp:HyperLink ID="hlAddProduct" CssClass="btn btn-primary mr-2 mt-2 btn-sm " runat="server" NavigateUrl="~/AdminPanel/Product/ProductAddEdit.aspx"><i class="fas fa-plus"></i>  Add Product</asp:HyperLink>
                </div>
            </div>


        </div>




        <asp:Label ID="lblErrorMessage" runat="server" Text="" EnableViewState="false" CssClass="text-danger"></asp:Label>
        <div class="card-body ">
            <div class="table-responsive table-hover bg-gray-100" style="overflow-x: scroll;">
                <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-sm text-gray-900" Width="100%" CellSpacing="0" OnRowCommand="gvProduct_RowCommand">
                    <Columns>
                        
                        <%--<asp:BoundField DataField="ProductID" HeaderText="ProductID" />--%>
                        <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                        <asp:BoundField DataField="ProductCategoryName" HeaderText="Product Category"  />
                        <asp:BoundField DataField="CompanyName" HeaderText="Company Name" />
                        <asp:BoundField DataField="SupplierName" HeaderText="Supplier" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="ProductExpiryDate" HeaderText="Expiry Date" />
                        
                        <asp:BoundField DataField="PricePerUnit" HeaderText="PricePerUnit" />
                        <%--<asp:BoundField DataField="Location" HeaderText="Location" />
                            <asp:BoundField DataField="DeliveryDate" HeaderText="Delivery Date" />
                        <asp:BoundField DataField="OtherDescription" HeaderText="OtherDescription" />--%>

                        <asp:TemplateField>
                            <ItemTemplate   >
                                <asp:HyperLink ID="hlEdit" runat="server" CssClass="fas fa-edit" NavigateUrl='<%# "~/AdminPanel/Product/ProductAddEdit.aspx?ProductID=" + Eval("ProductID").ToString() %>'></asp:HyperLink>&nbsp&nbsp
                                <asp:LinkButton ID="lbDelete" runat="server" CssClass="fas fa-trash" CommandName="DeleteProduct" CommandArgument='<%# Eval("ProductID") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>

        </div>
    </div>
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
    <script src="<%=ResolveClientUrl("~/Content/vendor/jquery/Jquery-3.5.1.min.js")%>"></script>
</asp:Content>

