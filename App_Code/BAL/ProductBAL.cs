using MedicalStoreManagementSystem_AdminPanel.DAL;
using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Web;

/// <summary>
/// Summary description for ProductBAL
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel.BAL
{
    public class ProductBAL
    {
        #region Constructor
        public ProductBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region Local_Variable
        protected string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion Local_Variable

        #region SelectAll
        public DataTable SelectAll()
        {
            ProductDAL dalProduct = new ProductDAL();
            return dalProduct.SelectAll();
        }
        #endregion SelectAll

        #region SelectByProductCategory
        public DataTable SelectByProductCategory(SqlInt32 ProductCategoryID)
        {
            ProductDAL dalProduct = new ProductDAL();
            return dalProduct.SelectByProductCategoryID(ProductCategoryID);
        }
        #endregion SelectByProductCategory

        #region SelectByPK
        public ProductENT SelectByPK(SqlInt32 ProductID)
        {
            ProductDAL dalProduct = new ProductDAL();
            return dalProduct.SelectByPK(ProductID);
        }
        #endregion SelectByPK

        #region SelectQuantityByProductID
        public int SelectQuantityByProductID(SqlInt32 ProductID)
        {
            ProductDAL dalProduct = new ProductDAL();
            return dalProduct.SelectQuantityByProductID(ProductID);
        }
        #endregion SelectQuantityByProductID

        #region Delete Operation
        public Boolean Delete(SqlInt32 ProductID)
        {
            ProductDAL dalProduct = new ProductDAL();
            if (dalProduct.Delete(ProductID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Delete Operation

        #region Insert Operation
        public Boolean Insert(ProductENT entProduct)
        {
            ProductDAL dalProduct = new ProductDAL();
            if (dalProduct.Insert(entProduct))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Insert Operation

        #region Update Operation
        public Boolean Update(ProductENT entProduct)
        {
            ProductDAL dalProduct = new ProductDAL();
            if (dalProduct.Update(entProduct))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Update Operation

        #region Decrease Quantity When Product Added TO Cart
        public Boolean DecreaseQuantity(SqlInt32 ProductID, SqlInt32 Quantity)
        {
            ProductDAL dalProduct = new ProductDAL();
            if(dalProduct.DecreaseQuantity(ProductID,Quantity))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Decrease Quantity When Product Added TO Cart

        #region Increase Quantity When Product Removed From Cart
        public Boolean IncreaseQuantity(SqlInt32 ProductID, SqlInt32 Quantity)
        {
            ProductDAL dalProduct = new ProductDAL();
            if (dalProduct.IncreaseQuantity(ProductID, Quantity))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Decrease Quantity When Product Removed From Cart
    }
}
