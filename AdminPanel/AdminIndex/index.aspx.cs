using MedicalStoreManagementSystem_AdminPanel.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_AdminIndex_index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
            #region Check_For_Valid_User
            if(Session["UserName"]==null )
            {
                Response.Redirect("~/AdminPanel/Login/Login.aspx");
            }
            #endregion Check_For_Valid_User
            #region Fill_All_Counter
            FillAllCounter();
            #endregion Fill_All_Counter
        }
    }

    private void FillAllCounter()
    {
        #region Display_EmployeeCount
        EmployeeBAL balEmployee = new EmployeeBAL();
        DataTable dtEmployee = new DataTable();
        dtEmployee = balEmployee.SelectAll();
        lblEmployeeCount.Text = Convert.ToString(dtEmployee.Rows.Count);
        #endregion Display_EmployeeCount

        #region Display_CustomerCount
        CustomerBAL balCustomer = new CustomerBAL();
        DataTable dtCustomer = new DataTable();
        dtCustomer = balCustomer.SelectAll();
        lblCustomerCount.Text = Convert.ToString(dtCustomer.Rows.Count);
        #endregion Display_CustomerCount

        #region Display_SupplierCount
        SupplierBAL balSupplier = new SupplierBAL();
        DataTable dtSupplier = new DataTable();
        dtSupplier = balSupplier.SelectAll();
        lblSupplierCount.Text = Convert.ToString(dtCustomer.Rows.Count);
        #endregion Display_SupplierCount    

        #region Display_ProductCount
        ProductBAL balProduct = new ProductBAL();
        DataTable dtProduct = new DataTable();
        dtProduct = balProduct.SelectAll();
        lblProductCount.Text = Convert.ToString(dtProduct.Rows.Count);
        #endregion Display_ProductCount
    }
}