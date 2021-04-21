<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MedicalStoreAdminPanel.master" AutoEventWireup="true" CodeFile="EmployeeList.aspx.cs" Inherits="AdminPanel_Employee_EmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--custom style for this page--%>
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">

    <!-- Page level plugins -->
    <script src="vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>

    <!-- Page level custom scripts -->
    <script src="js/demo/datatables-demo.js"></script>
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

        <div class="card-header">
            <div class="row">
                <div class="col-md-10">
                    <h2 class="m-2 text-lg  text-info">Employee List</h2>
                </div>
                <div class="col-md-2 align-bottom">
                    <asp:HyperLink ID="hlAddEmployee" CssClass="btn btn-primary mr-2 mt-2 btn-sm " runat="server" NavigateUrl="~/AdminPanel/Employee/EmployeeAddEdit.aspx"><i class="fas fa-plus"></i>  Add Employee</asp:HyperLink>
                </div>
            </div>


        </div>




        <asp:Label ID="lblErrorMessage" runat="server" Text="" EnableViewState="false" CssClass="text-danger"></asp:Label>
        <div class="card-body ">
            <div class="table-responsive table-hover bg-gray-100">
                <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered   text-gray-900" Width="100%" CellSpacing="0" OnRowCommand="gvEmployee_RowCommand">
                    <Columns>
                        
                        <%--<asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" />--%>
                        <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
                        <asp:BoundField DataField="BirthDate" HeaderText="BirthDate"  />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                        <asp:BoundField DataField="Post" HeaderText="PostName" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="JoiningDate" HeaderText="JoiningDate" />
                        
                        <asp:TemplateField>
                            <ItemTemplate   >
                                <asp:HyperLink ID="hlEdit" runat="server" CssClass="fas fa-edit" NavigateUrl='<%# "~/AdminPanel/Employee/EmployeeAddEdit.aspx?EmployeeID=" + Eval("EmployeeID").ToString() %>'></asp:HyperLink>&nbsp&nbsp
                                <asp:LinkButton ID="lbDelete" runat="server" CssClass="fas fa-trash" CommandName="DeleteEmployee" CommandArgument='<%# Eval("EmployeeID") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>

        </div>
    </div>
    <script src="<%=ResolveClientUrl("~/Content/vendor/jquery/Jquery-3.5.1.min.js")%>"></script>
</asp:Content>

