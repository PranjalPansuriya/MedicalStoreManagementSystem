<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MedicalStoreAdminPanel.master" AutoEventWireup="true" CodeFile="SellingPanel.aspx.cs" Inherits="AdminPanel_Selling_SellingPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript"> 
        function insertAlert() {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Record Added Successfully',
                timer: 1500
            })
        };
        function insufficientStockAlert() {
            Swal.fire({
                position: 'center',
                icon: 'warning',
                title: 'Insufficient Stock',
                showConfirmButton: false,
                timer: 1500
            })
        };
        function emptyCartAlert() {
            Swal.fire({
                position: 'center',
                icon: 'warning',
                title: 'Your Shopping Cart is Empty ',
                showConfirmButton: false,
                timer: 1500
            })
        };

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
    <asp:Label ID="lblErrorMessage" runat="server" Text="" CssClass="text-danger text-lg"></asp:Label>
    <asp:Label ID="lblAddCustomer" Visible="false" runat="server" Text="">
        <div class="row card-header">
            <div class="col-md-12 text-right">
                New Customer...?
                <asp:HyperLink ID="hlAddCustomer" runat="server" CssClass="" NavigateUrl="~/AdminPanel/Customer/CustomerAddEdit.aspx">Go and Register First</asp:HyperLink>
            </div>

        </div>

    </asp:Label>
    <asp:Label ID="lblMainContent" runat="server" Text="" Visible="true">
        <div class="card shadow mb-4">
            <a href="#collapseCardExample" class="d-block card-header py-3 collapsed" data-toggle="collapse"
                role="button" aria-expanded="false" aria-controls="collapseCardExample">
                <div class="m-0  text-lg text-info">Add Product to Cart </div>
            </a>
            <!-- Card Content - Collapse -->

            <div class="collapse show" id="collapseCardExample">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-3 text-gray-700  text-lg">
                            Select Product Category 
                        </div>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlProductCategory" runat="server" CssClass="form-control shadow-sm"  AutoPostBack="True" OnSelectedIndexChanged="ddlProductCategory_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvddlProductCategory" runat="server" CssClass="text-danger" ErrorMessage="Select Product actegory" Display="Dynamic" InitialValue="-1" ControlToValidate="ddlProductCategory" ValidationGroup="AddToCart"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2 text-gray-700  text-lg">
                            Select Product 
                        </div>
                        <div class="col-md-5">
                            <asp:DropDownList ID="ddlProductName" runat="server" CssClass="form-control shadow-sm " OnSelectedIndexChanged="ddlProductName_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvddlProductName" runat="server" CssClass="text-danger" ErrorMessage="Select Product" Display="Dynamic" InitialValue="-1" ControlToValidate="ddlProductName" ValidationGroup="AddToCart"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2 text-gray-700  text-lg text-right">
                            Price 
                        </div>
                        <div class="col-md-2">
                            <asp:TextBox ID="txtPrice" runat="server" ReadOnly="true" CssClass="form-control shadow-sm" Text=""></asp:TextBox>
                        </div>
                        <div class="col-md-1"></div>
                        <div class="col-md-2 text-gray-700  text-lg">
                            Stock Available
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtStockAvailable" runat="server" ReadOnly="true" CssClass="form-control shadow-sm" Text=""></asp:TextBox>
                        </div>

                    </div>
                    <br />
                    <div class="row">

                        <div class="col-md-6">
                            <div class="text-gray-700 ">
                                <div class="row">
                                    <div class="col-md-5  text-lg">Buying Quantity :</div>
                                    <div class="col-md-7 ">
                                        <asp:TextBox ID="txtBuyingQuantity" runat="server" CssClass="form-control shadow-sm" Text="" TextMode="Number" min="1"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvBuyingQuantity" runat="server" ControlToValidate="txtBuyingQuantity" ErrorMessage="Enter Buying Quantity" CssClass="text-danger" ValidationGroup="AddToCart" Display="Dynamic"></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="col-md-6">
                            <asp:Button ID="btnAddToCart" BackColor="#0e613c" runat="server" Text="Add to Cart" CssClass="btn btn-block shadow-sm btn-lg btn-facebook" ValidationGroup="AddToCart" OnClick="btnAddToCart_Click" />
                        </div>

                    </div>

                </div>
            </div>
        </div>

        <div class="card shadow mb-4">
            <a href="#ShoppingCart" class="d-block card-header py-3 collapsed" data-toggle="collapse"
                role="button" aria-expanded="false" aria-controls="collapseCardExample">
                <div class="m-0  text-lg text-info">Shopping Cart <i class="fas fa-shopping-cart "></i></div>
            </a>
            <!-- Card Content - Collapse -->
            <div class="collapse show" id="ShoppingCart">
                <div class="card-body">
                    <div class="table-responsive table-hover bg-gray-100">
                        <asp:GridView ID="gvCartList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-sm  text-gray-900" Width="100%" CellSpacing="0" OnRowCommand="gvCartList_RowCommand">
                            <Columns>

                                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                                <asp:BoundField DataField="Location" HeaderText="Location" />
                                <asp:BoundField DataField="ProductQuantity" HeaderText="Quantity" />
                                <asp:BoundField DataField="PricePerUnit" HeaderText="PricePerUnit" />

                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbDelete"  runat="server" CssClass="fas fa-trash" CommandName="RemoveFromCart" CommandArgument='<%# Eval("ProductID") + "," + Eval("ProductQuantity")%>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <hr />
                        <div class="row">
                            <div class="col-md-7">
                                <div class="text-info  text-right text-lg">
                                    Total Amount : 
                                <asp:Label ID="lblTotalAmount" runat="server" Text="" CssClass=" text-secondary  "></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-5 text-right">
                                <asp:LinkButton ID="lbCheckOut" runat="server"  Text="Checkout" CssClass="btn btn-success btn-sm " OnClick="lbCheckOut_Click"></asp:LinkButton>
                            </div>
                        </div>
                        <hr />

                    </div>
                </div>
            </div>
        </div>
    </asp:Label>
</asp:Content>

