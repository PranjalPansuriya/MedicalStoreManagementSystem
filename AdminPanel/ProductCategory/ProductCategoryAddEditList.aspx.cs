using MedicalStoreManagementSystem_AdminPanel.BAL;
using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class AdminPanel_ProductCategory_ProductCategoryAddEditList : System.Web.UI.Page
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
            if (Request.QueryString["ProductCategoryID"] != null)
            {
                lblHeading.Text = "Product Category Edit";
                FillProductCategoryForm(Convert.ToInt32(Request.QueryString["ProductCategoryID"]));
            }
            else
            {
                lblHeading.Text = "Product Category Add";
            }
            lblErrorMessage.Text = "";
            FillGridViewProductCategory();

        }
    }
    #endregion Page_Load

    #region btnSave : OnClick
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMsg = "";
        if (txtProductCategoryName.Text == "")
        {

            strErrorMsg += "- Enter Product Category </br>";
        }
        if (strErrorMsg != "")
        {
            lblErrorMessage.Text = strErrorMsg;
            return;
        }

        #endregion Server Side Validation

        #region Collect Data
        ProductCategoryENT entProductCategory = new ProductCategoryENT();
        if (txtProductCategoryName.Text.Trim() != "")
        {
            entProductCategory.ProductCategoryName = txtProductCategoryName.Text.Trim();
        }
        #endregion Collect Data

        ProductCategoryBAL balProductCategory = new ProductCategoryBAL();
        if (Request.QueryString["ProductCategoryID"] == null)
        {
            #region Product Category Add
            if (balProductCategory.Insert(entProductCategory))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "insertAlert();", true);
                txtProductCategoryName.Text = "";
                FillGridViewProductCategory();
            }
            else
            {
                lblErrorMessage.Text = balProductCategory.Message;
            }
            #endregion Product Category Add
        }
        else
        {
            #region Product Category Edit
            entProductCategory.ProductCategoryID = Convert.ToInt32(Request.QueryString["ProductCategoryID"]);
            if (balProductCategory.Update(entProductCategory))
            {
                txtProductCategoryName.Text = "";
                Response.Redirect("~/AdminPanel/ProductCategory/ProductCategoryAddEditList.aspx");
            }
            else
            {
                lblErrorMessage.Text = balProductCategory.Message;
            }
            #endregion Product Category Edit
        }
    }
    #endregion btnSave : OnClick

    #region Btn_Cancel_Onclick
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtProductCategoryName.Text = "";
    }
    #endregion Btn_Cancel_Onclick

    #region Fill GridView CategoryList
    private void FillGridViewProductCategory()
    {
        ProductCategoryBAL balProductCategory = new ProductCategoryBAL();
        DataTable dtProductCategory = new DataTable();
        dtProductCategory = balProductCategory.SelectAll();

        if(dtProductCategory != null && dtProductCategory.Rows.Count>0)
        {
            gvProductCategory.DataSource = dtProductCategory;
            gvProductCategory.DataBind();
        }

    }
    #endregion Fill GridView CategoryList

    #region Fill_Product_Category_Form
    private void FillProductCategoryForm(SqlInt32 ProductCategoryID)
    {
        ProductCategoryBAL balProductCategory = new ProductCategoryBAL();
        ProductCategoryENT entProductCategory = new ProductCategoryENT();
        entProductCategory = balProductCategory.SelectByPK(ProductCategoryID);

        #region Fill Controls
        txtProductCategoryName.Text = Convert.ToString(entProductCategory.ProductCategoryName);
        #endregion Fill Controls
    }
    #endregion Fill_Category_Form

    #region Call_Delete/Edit
    protected void gvProductCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteProductCategory")
        {
            ProductCategoryBAL balProductCategory = new  ProductCategoryBAL();
            if (e.CommandArgument != null)
            {
                if(balProductCategory.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "deleteAlert();", true);
                    FillGridViewProductCategory();
                }
                else
                {
                    lblErrorMessage.Text = balProductCategory.Message;
                }
            }
           
        }
    }
    #endregion Call_Delete/Edit

    
}