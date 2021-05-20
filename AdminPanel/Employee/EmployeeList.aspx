<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MedicalStoreAdminPanel.master" AutoEventWireup="true" CodeFile="EmployeeList.aspx.cs" Inherits="AdminPanel_Employee_EmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- Datatables Plugin -->
    
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=gvEmployee.ClientID%>').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
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

        <div class="card-header">
            <div class="row">
                <div class="col-md-10">
                    <h2 class="m-2 text-lg  text-info">Employee List</h2>
                </div>
                <div class="col-md-2 align-bottom">
                    <asp:HyperLink ID="hlAddEmployee" CssClass="btn mr-2 mt-2 btn-sm btn-success shadow-lg"    runat="server" NavigateUrl="~/AdminPanel/Employee/EmployeeAddEdit.aspx"><i class="fas fa-plus"></i>  Add Employee</asp:HyperLink>
                </div>
            </div>


        </div>




        <asp:Label ID="lblErrorMessage" runat="server" Text="" EnableViewState="false" CssClass="text-danger"></asp:Label>
        <div class="card-body ">
            <div class="table-responsive  bg-gray-100">
                <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered  table-sm text-gray-900" Width="100%" CellSpacing="0" OnRowCommand="gvEmployee_RowCommand">
                    <Columns>

                        <%--<asp:BoundField DataField="EmployeeID" HeaderText="EmployeeID" />--%>
                        <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
                        <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" />
                        <asp:BoundField DataField="Address" HeaderText="Address" />
                        <asp:BoundField DataField="MobileNo" HeaderText="MobileNo" />
                        <asp:BoundField DataField="Post" HeaderText="PostName" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="JoiningDate" HeaderText="JoiningDate" />

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HyperLink ID="hlEdit" ForeColor="#0b4e43" runat="server" CssClass="fas fa-edit" NavigateUrl='<%# "~/AdminPanel/Employee/EmployeeAddEdit.aspx?EmployeeID=" + Eval("EmployeeID").ToString() %>'></asp:HyperLink>&nbsp&nbsp
                                <asp:LinkButton ID="lbDelete" runat="server" CssClass="fas fa-trash" CommandName="DeleteEmployee" CommandArgument='<%# Eval("EmployeeID") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>

        </div>
    </div>

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

