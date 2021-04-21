using MedicalStoreManagementSystem_AdminPanel.DAL;
using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupplierBAL
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel.BAL
{
    public class SupplierBAL
    {
        #region Constructor
        public SupplierBAL()
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
            SupplierDAL dalSupplier = new SupplierDAL();
            return dalSupplier.SelectAll();
        }
        #endregion SelectAll

        #region SelectByPK
        public SupplierENT SelectByPK(SqlInt32 SupplierID)
        {
            SupplierDAL dalSupplier = new SupplierDAL();
            return dalSupplier.SelectByPK(SupplierID);
        }
        #endregion SelectByPK

        #region Delete Operation
        public Boolean Delete(SqlInt32 SupplierID)
        {
            SupplierDAL dalSupplier = new SupplierDAL();
            if (dalSupplier.Delete(SupplierID))
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
        public Boolean Insert(SupplierENT entSupplier)
        {
            SupplierDAL dalSupplier = new SupplierDAL();
            if (dalSupplier.Insert(entSupplier))
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
        public Boolean Update(SupplierENT entSupplier)
        {
            SupplierDAL dalSupplier = new SupplierDAL();
            if (dalSupplier.Update(entSupplier))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion Update Operation
    }
}
