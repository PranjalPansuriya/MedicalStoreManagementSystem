using MedicalStoreManagementSystem_AdminPanel.BAL;
using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Customer_CustomerAddEdit : System.Web.UI.Page
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
            if (Request.QueryString["CustomerID"] == null)
            {
                lblHeading.Text = "Customer Add";
            }
            else
            {
                lblHeading.Text = "Customer Edit";
                FillCustomerForm(Convert.ToInt32(Request.QueryString["CustomerID"]));
            }
        }
    }
    #endregion Page_Load

    #region FillCustomerForm
    private void FillCustomerForm(SqlInt32 CustomerID)
    {
        CustomerBAL balCustomer = new CustomerBAL();
        CustomerENT entCustomer = new CustomerENT();
        entCustomer = balCustomer.SelectByPK(CustomerID);

        #region Fill Controls
        txtCustomerName.Text = Convert.ToString(entCustomer.CustomerName);
        txtContactNo.Text = Convert.ToString(entCustomer.ContactNo);
        txtAmount.Text = Convert.ToString(entCustomer.Amount);
        rblPaymentMethod.SelectedValue = Convert.ToString(entCustomer.PaymentMethod);
        #endregion Fill Controls

    }

    #endregion FillCustomerForm

    #region btnSave : Onclick
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMsg = "";
        if (txtAmount.Text == "")
        {
            strErrorMsg += "- Enter Amount </br>";
        }
        if (txtContactNo.Text == "")
        {
            strErrorMsg += "- Enter ContactNo </br>";
        }
        if (txtCustomerName.Text == "")
        {
            strErrorMsg += "- Enter CustomerName </br>";
        }
        if(rblPaymentMethod.SelectedValue==null)
        {
            strErrorMsg += "- Select PaymentMethod </br>";
        }
        if (strErrorMsg != "")
        {
            lblErrorMessage.Text = strErrorMsg;
            return;
        }

        #endregion Server Side Validation

        #region Collect Data
        CustomerENT entCustomer = new CustomerENT();
        if (txtAmount.Text.Trim() != "")
        {
            entCustomer.Amount = Convert.ToDecimal(txtAmount.Text.Trim());
        }
        if (txtContactNo.Text != "")
        {
            entCustomer.ContactNo = txtContactNo.Text.Trim();
        }
        if (txtCustomerName.Text.Trim() != "")
        {
            entCustomer.CustomerName = txtCustomerName.Text.Trim();
        }
        if(rblPaymentMethod.SelectedValue != null)
        {
            entCustomer.PaymentMethod = Convert.ToString(rblPaymentMethod.SelectedValue);
        }
        #endregion Collect Data
        CustomerBAL balCustomer = new CustomerBAL();
        if (Request.QueryString["CustomerID"] == null)
        {
            #region Customer Add
            if (balCustomer.Insert(entCustomer))
            {
                txtAmount.Text = "";
                txtContactNo.Text = "";
                txtCustomerName.Text = "";
                rblPaymentMethod.SelectedValue = null;

                Response.Redirect("~/AdminPanel/Customer/CustomerList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balCustomer.Message;
            }
            #endregion Customer Add
        }
        else
        {
            #region Customer Edit
            entCustomer.CustomerID = Convert.ToInt32(Request.QueryString["CustomerID"]);
            if (balCustomer.Update(entCustomer))
            {
                txtAmount.Text = "";
                txtContactNo.Text = "";
                txtCustomerName.Text = "";
                rblPaymentMethod.SelectedValue = null;

                Response.Redirect("~/AdminPanel/Customer/CustomerList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balCustomer.Message;
            }
            #endregion Customer Edit
        }
    }
    #endregion btnSave : Onclick

    #region btnCancel :  Onclick
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtAmount.Text = "";
        txtContactNo.Text = "";
        txtCustomerName.Text = "";
        rblPaymentMethod.SelectedValue = null;
        
        Response.Redirect("~/AdminPanel/Customer/CustomerList.aspx");
    }
    #endregion btnCancel :  Onclick
}