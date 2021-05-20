using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Web;

/// <summary>
/// Summary description for CustomerENT
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel.ENT
{
    public class CustomerWiseProductENT
    {
        #region Constructor
        public CustomerWiseProductENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region CustomerWiseProductID
        protected SqlInt32 _CustomerWiseProductID;
        public SqlInt32 CustomerWiseProductID
        {
            get
            {
                return _CustomerWiseProductID;
            }
            set
            {
                _CustomerWiseProductID = value;
            }
        }
        #endregion CustomerWiseProductID

        #region CustomerID
        protected SqlInt32 _CustomerID;
        public SqlInt32 CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
            }
        }
        #endregion CustomerID

        #region ProductID
        protected SqlInt32 _ProductID;
        public SqlInt32 ProductID
        {
            get
            {
                return _ProductID;
            }
            set
            {
                _ProductID = value;
            }
        }
        #endregion ProductID

        #region ProductQuantity
        protected SqlInt32 _ProductQuantity;
        public SqlInt32 ProductQuantity
        {
            get
            {
                return _ProductQuantity;
            }
            set
            {
                _ProductQuantity = value;
            }
        }
        #endregion ProductQuantity

    }
}
