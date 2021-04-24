using MedicalStoreManagementSystem_AdminPanel;
using MedicalStoreManagementSystem_AdminPanel.BAL;
using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Product_ProductAddEdit : System.Web.UI.Page
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
            
            if (Request.QueryString["ProductID"] == null)
            {
                lblHeading.Text = "Product Add";
            }
            else
            {
                lblHeading.Text = "Product Edit";
                FillProductForm(Convert.ToInt32(Request.QueryString["ProductID"]));
            }
            CommonFillMethods.FillDropDownListProductCategory(ddlProductCategory);
            CommonFillMethods.FillDropDownListSupplierName(ddlSupplierName);
        }
    }
    #endregion Page_Load

    #region FillProductForm
    private void FillProductForm(SqlInt32 ProductID)
    {
        ProductBAL balProduct = new ProductBAL();
        ProductENT entProduct = new ProductENT();
        DateTime ed;
        DateTime dd;
        entProduct = balProduct.SelectByPK(ProductID);

        #region Fill Controls
        txtProductName.Text = Convert.ToString(entProduct.ProductName);
        ddlProductCategory.SelectedValue = Convert.ToString(entProduct.ProductCategoryID);
        ddlSupplierName.SelectedValue = Convert.ToString(entProduct.SupplierID);
        txtCompanyName.Text = Convert.ToString(entProduct.CompanyName);
        txtQuantity.Text = Convert.ToString(entProduct.Quantity);
        ed = Convert.ToDateTime(entProduct.ProductExpiryDate.Value.ToString());
        txtExpiryDate.Text = ed.ToString("MM-dd-yyyy");
        dd = Convert.ToDateTime(entProduct.DeliveryDate.Value.ToString());
        txtDeliveryDate.Text = dd.ToString("MM-dd-yyyy");
        txtLocation.Text = Convert.ToString(entProduct.Location);
        txtOtherDescription.Text = Convert.ToString(entProduct.OtherDescription);
        txtPricePerUnit.Text = Convert.ToString(entProduct.PricePerUnit);
        #endregion Fill Controls

    }

    #endregion FillProductForm

    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMsg = "";
        if (txtProductName.Text == "")
        {
            strErrorMsg += "- Enter Product Name </br>";
        }
        if (ddlProductCategory.SelectedIndex == 0)
        {
            strErrorMsg += "- Select Product Category";
        }
        if (txtCompanyName.Text == "")
        {
            strErrorMsg += "- Enter Company Name </br>";
        }
        if (ddlSupplierName.SelectedIndex == 0)
        {
            strErrorMsg += "- Select Suppler";
        }
        if (txtQuantity.Text == "")
        {
            strErrorMsg += "- Enter Quantity </br>";
        }
        if (txtDeliveryDate.Text == "")
        {
            strErrorMsg += "- Enter Delivery Date </br>";
        }
        if (txtExpiryDate.Text == "")
        {
            strErrorMsg += "- Enter Expiry Date </br>";
        }
        if (txtLocation.Text == "")
        {
            strErrorMsg += "- Enter Location </br>";
        }
        if (txtPricePerUnit.Text == "")
        {
            strErrorMsg += "- Enter Price Per Unit </br>";
        }
        if (strErrorMsg != "")
        {
            lblErrorMessage.Text = strErrorMsg;
            return;
        }



        #endregion Server Side Validation

        #region Collect Data
        ProductENT entProduct = new ProductENT();
        if (txtProductName.Text.Trim() != "")
        {
            entProduct.ProductName = Convert.ToString(txtProductName.Text.Trim());
        }
        if (ddlProductCategory.SelectedIndex != 0)
        {
            entProduct.ProductCategoryID = Convert.ToInt32(ddlProductCategory.SelectedValue);
        }
        if (ddlSupplierName.SelectedIndex != 0)
        {
            entProduct.SupplierID = Convert.ToInt32(ddlSupplierName.SelectedValue);
        }
        if (txtCompanyName.Text.Trim() != "")
        {
            entProduct.CompanyName = Convert.ToString(txtCompanyName.Text.Trim());
        }
        if (txtQuantity.Text.Trim() != "")
        {
            entProduct.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
        }
        if (txtExpiryDate.Text != "")
        {
            entProduct.ProductExpiryDate = Convert.ToDateTime(txtExpiryDate.Text.Trim());
        }
        if (txtDeliveryDate.Text != "")
        {
            entProduct.DeliveryDate = Convert.ToDateTime(txtDeliveryDate.Text.Trim());
        }
        if (txtLocation.Text != "")
        {
            entProduct.Location = Convert.ToString(txtLocation.Text.Trim());
        }
        if (txtOtherDescription.Text != "")
        {
            entProduct.OtherDescription = Convert.ToString(txtOtherDescription.Text.Trim());
        }
        if (txtPricePerUnit.Text != "")
        {
            entProduct.PricePerUnit = Convert.ToDouble(txtPricePerUnit.Text.Trim());
        }
        #endregion Collect Data

        ProductBAL balProduct = new ProductBAL();
        if (Request.QueryString["ProductID"] == null)
        {
            #region Product Add
            if (balProduct.Insert(entProduct))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "insertAlert();", true);
                txtProductName.Text = "";
                ddlProductCategory.SelectedIndex = 0;
                ddlSupplierName.SelectedIndex = 0;
                txtCompanyName.Text = "";
                txtQuantity.Text = "";
                txtExpiryDate.Text = "";
                txtDeliveryDate.Text = "";
                txtLocation.Text = "";
                txtOtherDescription.Text = "";
                txtPricePerUnit.Text = "";
            }
            else
            {
                lblErrorMessage.Text = balProduct.Message;
            }
            #endregion Product Add
        }
        else
        {
            #region Product Edit
            entProduct.ProductID = Convert.ToInt32(Request.QueryString["ProductID"]);
            if (balProduct.Update(entProduct))
            {
                txtProductName.Text = "";
                ddlProductCategory.SelectedIndex = 0;
                ddlSupplierName.SelectedIndex = 0;
                txtCompanyName.Text = "";
                txtQuantity.Text = "";
                txtExpiryDate.Text = "";
                txtDeliveryDate.Text = "";
                txtLocation.Text = "";
                txtOtherDescription.Text = "";
                txtPricePerUnit.Text = "";
                Response.Redirect("~/AdminPanel/Product/ProductList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balProduct.Message;
            }
            #endregion Product Edit
        }
    }

    #region btnCancel : OnClick
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtProductName.Text = "";
        ddlProductCategory.SelectedIndex = 0;
        ddlSupplierName.SelectedIndex = 0;
        txtCompanyName.Text = "";
        txtQuantity.Text = "";
        txtExpiryDate.Text = "";
        txtDeliveryDate.Text = "";
        txtLocation.Text = "";
        txtOtherDescription.Text = "";
        txtPricePerUnit.Text = "";
        Response.Redirect("~/AdminPanel/Product/ProductList.aspx");
    }
    #endregion btnCancel : OnClick
}