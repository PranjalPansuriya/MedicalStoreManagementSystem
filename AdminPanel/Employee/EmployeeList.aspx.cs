using MedicalStoreManagementSystem_AdminPanel.BAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class AdminPanel_Employee_EmployeeList : System.Web.UI.Page
{
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check_for_Valid_User
        if (Session["UserName"] == null)
        {
            Response.Redirect("~/AdminPanel/Login/Login.aspx");
        }
        #endregion Check_for_Valid_User
        if (!Page.IsPostBack)
        {
            FillGridViewEmployee();
        }
    }
    #endregion PageLoad

    #region Fill GridView Employee
    private void FillGridViewEmployee()
    {
        EmployeeBAL balEmployee = new EmployeeBAL();
        DataTable dtEmployee = new DataTable();
        dtEmployee = balEmployee.SelectAll();

        if(dtEmployee != null && dtEmployee.Rows.Count >0)
        {
            gvEmployee.DataSource = dtEmployee;
            gvEmployee.DataBind();
        }
    }
    #endregion Fill GridView Employee

    #region Delete Employee
    protected void gvEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "DeleteEmployee")
        {
            EmployeeBAL balEmployee = new EmployeeBAL();
            if(e.CommandArgument != null)
            {
                if(balEmployee.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "deleteAlert();", true); 
                    FillGridViewEmployee();
                }
                else
                {
                    lblErrorMessage.Text = balEmployee.Message;
                }
                
            }
        }
    }
    #endregion Delete Employee

    
}