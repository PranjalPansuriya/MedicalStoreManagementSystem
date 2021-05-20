<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MedicalStoreAdminPanel.master" AutoEventWireup="true" CodeFile="ProductCategoryAddEditList.aspx.cs" Inherits="AdminPanel_ProductCategory_ProductCategoryAddEditList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Datatables Plugin -->
    
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=gvProductCategory.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
        });
    </script>
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
                           Product Category :
                        </div>
                        <div class="col-md-8">
                            <asp:TextBox ID="txtProductCategoryName" runat="server" class="form-control shadow-sm" placeholder="Enter Product Category"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvProductCategoryName" runat="server" ErrorMessage="Enter Product Category" Display="Dynamic" ControlToValidate="txtProductCategoryName" CssClass="text-danger" ValidationGroup="AddProductCategory"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-4"></div>
                        <div class="col-4 row">
                            <div class="col-5 text-right">
                                <asp:Button ID="btnAdd" runat="server" Text="Save" CssClass="btn btn-success icon " ValidationGroup="AddProductCategory" OnClick="btnAdd_Click"  />

                            </div>
                            <div class="col-1"></div>
                            <div class="col-5 text-left">
                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn shadow-lg" OnClick="btnCancel_Click"  />
                            </div>
                        </div>
                        <div class="col-4"></div>

                    </div>
                </div>

            </div>
        </div>
    </div>

    <div class="card  shadow mb-4">
        <div class="card-header py-2">
            <h3 class="m-2 text-lg  text-info">Product Category List</h3>
        </div>
        <div class="card-body ">
            <div class="table-responsive bg-gray-100">
                <asp:GridView ID="gvProductCategory" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-sm  text-gray-900" Width="100%" CellSpacing="0" OnRowCommand="gvProductCategory_RowCommand" >
                    <Columns>
                        <asp:BoundField DataField="ProductCategoryName" HeaderText="Product Category Name" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" runat="server"  ForeColor="#0b4e43" class=" fas fa-edit" NavigateUrl='<%# "~/AdminPanel/ProductCategory/ProductCategoryAddEditList.aspx?ProductCategoryID=" + Eval("ProductCategoryID").ToString() %>'></asp:HyperLink>&nbsp&nbsp&nbsp
                                <asp:LinkButton ID="lbDelete" runat="server"  CssClass="fas fa-trash" CommandName="DeleteProductCategory" CommandArgument='<%# Eval("ProductCategoryID") %>' ></asp:LinkButton>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>

        </div>
    </div>
    <script src="<%=ResolveClientUrl("~/Content/vendor/jquery/Jquery-3.5.1.min.js")%>"></script>
    <script>
        function deleteAlert() {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Record Deleted Successfully',
                showConfirmButton: false,
                timer: 1500
            })
        };
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
    <%--Script for sweetAlert--%>
</asp:Content>



