using MedicalStoreManagementSystem_AdminPanel.BAL;
using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Employee_EmployeeAddEdit : System.Web.UI.Page
{
    #region Page_Load
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
            if(Request.QueryString["EmployeeID"] == null)
            {
                lblHeading.Text = "Employee Add";
            }
            else
            {
                lblHeading.Text = "Employee Edit";
                FillEmployeeForm(Convert.ToInt32(Request.QueryString["EmployeeID"]));
            }
        }
    }
    #endregion Page_Load

    #region FillEmployeeForm
    private void FillEmployeeForm(SqlInt32 EmployeeID)
    {
        EmployeeBAL balEmployee = new EmployeeBAL();
        EmployeeENT entEmployee = new EmployeeENT();
        DateTime bd;
        DateTime jd;
        entEmployee = balEmployee.SelectByPK(EmployeeID);

        #region Fill Controls
        txtEmployeeName.Text = Convert.ToString(entEmployee.EmployeeName);
        txtAddress.Text = Convert.ToString(entEmployee.Address);

        bd = Convert.ToDateTime(entEmployee.BirthDate.Value.ToString());
        txtBirthDate.Text = bd.ToString("MM-dd-yyyy");

        txtMobileNo.Text = Convert.ToString(entEmployee.MobileNo);
        txtEmail.Text = Convert.ToString(entEmployee.Email);
        txtPost.Text = Convert.ToString(entEmployee.Post);

        jd = Convert.ToDateTime(entEmployee.JoiningDate.Value.ToString());
        txtJoiningDate.Text = jd.ToString("MM-dd-yyyy");

        #endregion Fill Controls

    }

    #endregion FillEmployeeForm

    #region btnCancel :  Onclick
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtEmployeeName.Text = "";
        txtAddress.Text = "";
        txtBirthDate.Text = "";
        txtMobileNo.Text = "";
        txtEmail.Text = "";
        txtPost.Text = "";
        txtJoiningDate.Text = "";
        Response.Redirect("~/AdminPanel/Employee/EmployeeList.aspx");
    }
    #endregion btnCancel :  Onclick


    #region btnSave : Onclick
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMsg = "";
        if(txtEmployeeName.Text == "")
        {
            strErrorMsg += "- Enter Name </br>";
        }
        if(txtMobileNo.Text == "")
        {
            strErrorMsg += "- Enter MobileNo </br>";
        }
        if (txtAddress.Text == "")
        {
            strErrorMsg += "- Enter Address </br>";
        }
        if (txtBirthDate.Text == "")
        {
            strErrorMsg += "- Select BirthDate </br>";
        }
        if (txtEmail.Text == "")
        {
            strErrorMsg += "- Enter Email </br>";
        }
        if (txtJoiningDate.Text == "")
        {
            strErrorMsg += "- Select JoiningDate </br>";
        }
        if (txtPost.Text == "")
        {
            strErrorMsg += "- Enter Post </br>";
        }
        if(strErrorMsg != "")
        {
            lblErrorMessage.Text = strErrorMsg;
            return;
        }

        #endregion Server Side Validation

        #region Collect Data
        EmployeeENT entEmployee = new EmployeeENT();
        if(txtAddress.Text.Trim()!="")
        {
            entEmployee.Address=txtAddress.Text.Trim();
        }
        if (txtBirthDate.Text != "")
        {
            entEmployee.BirthDate = Convert.ToDateTime(txtBirthDate.Text.Trim());
        }
        if (txtEmail.Text.Trim() != "")
        {
            entEmployee.Email = txtEmail.Text.Trim();
        }
        if (txtEmployeeName.Text.Trim() != "")
        {
            entEmployee.EmployeeName = txtEmployeeName.Text.Trim();
        }
        if (txtJoiningDate.Text != "")
        {
            entEmployee.JoiningDate = Convert.ToDateTime(txtJoiningDate.Text.Trim());
        }
        if (txtMobileNo.Text != "")
        {
            entEmployee.MobileNo = txtMobileNo.Text.Trim();
        }
        if (txtPost.Text != "")
        {
            entEmployee.Post = txtPost.Text.Trim();
        }
        #endregion Collect Data
        EmployeeBAL balEmployee = new EmployeeBAL();
        if (Request.QueryString["EmployeeID"]==null)
        {
            #region Employee Add
            if(balEmployee.Insert(entEmployee))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "insertAlert();", true);
                txtAddress.Text = "";
                txtBirthDate.Text = "";
                txtEmail.Text = "";
                txtEmployeeName.Text = "";
                txtJoiningDate.Text = "";
                txtMobileNo.Text = "";
                txtPost.Text = "";
                
            }
            else
            {
                lblErrorMessage.Text = balEmployee.Message; 
            }
            #endregion Employee Add
        }
        else
        {
            #region Employee Edit
            entEmployee.EmployeeID = Convert.ToInt32(Request.QueryString["EmployeeID"]);
            if(balEmployee.Update(entEmployee))
            {
                txtAddress.Text = "";
                txtBirthDate.Text = "";
                txtEmail.Text = "";
                txtEmployeeName.Text = "";
                txtJoiningDate.Text = "";
                txtMobileNo.Text = "";
                txtPost.Text = "";
                Response.Redirect("~/AdminPanel/Employee/EmployeeList.aspx");
                
            }
            else
            {
                lblErrorMessage.Text = balEmployee.Message;
            }
            #endregion Employee Edit
        }
    }
    #endregion btnSave : Onclick

    
}