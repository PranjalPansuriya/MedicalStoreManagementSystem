using MedicalStoreManagementSystem_AdminPanel.DAL;
using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductCategoryBAL
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel.BAL
{
    public class ProductCategoryBAL
    {
        #region Constructor
        public ProductCategoryBAL()
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
            ProductCategoryDAL dalProductCategory = new ProductCategoryDAL();
            return dalProductCategory.SelectAll();
        }
        #endregion SelectAll

        #region SelectByPK
        public ProductCategoryENT SelectByPK(SqlInt32 ProductCategoryID)
        {
            ProductCategoryDAL dalProductCategory = new ProductCategoryDAL();
            return dalProductCategory.SelectByPK(ProductCategoryID);
        }
        #endregion SelectByPK

        #region Delete Operation
        public Boolean Delete(SqlInt32 ProductCategoryID)
        {
            ProductCategoryDAL dalProductCategory = new ProductCategoryDAL();
            if (dalProductCategory.Delete(ProductCategoryID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Delete Operation

        #region Update Operation
        public Boolean Update(ProductCategoryENT entProductCategory)
        {
            ProductCategoryDAL dalProductCategory = new ProductCategoryDAL();
            if (dalProductCategory.Update(entProductCategory))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Update Operation

        #region Insert Operation
        public Boolean Insert(ProductCategoryENT entProductCategory)
        {
            ProductCategoryDAL dalProductCategory = new ProductCategoryDAL();
            if (dalProductCategory.Insert(entProductCategory))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Insert Operation


    }
}
