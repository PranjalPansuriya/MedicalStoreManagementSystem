using MedicalStoreManagementSystem_AdminPanel.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Product_ProductList : System.Web.UI.Page
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
            FillGridViewProduct();
        }
    }
    #endregion PageLoad

    #region FillGridViewProduct
    public void FillGridViewProduct()
    {
        ProductBAL balProduct = new ProductBAL();
        DataTable dtProduct = new DataTable();
        dtProduct = balProduct.SelectAll();

        if(dtProduct != null  && dtProduct.Rows.Count > 0)
        {
            gvProduct.DataSource = dtProduct;
            gvProduct.DataBind();
        }
    }
    #endregion FillGridViewProduct

    #region DeleteProduct
    protected void gvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "DeleteProduct")
        {
            ProductBAL balProduct = new ProductBAL();
            if (e.CommandArgument != null)
            {
                if (balProduct.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    FillGridViewProduct();
                }
                else
                {
                    lblErrorMessage.Text = balProduct.Message;
                }

            }
        }
    }
    #endregion DeleteProduct
}