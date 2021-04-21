using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupplierENT
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel.ENT
{
    public class SupplierENT
    {
        #region Constructor
        public SupplierENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region SupplierID
        protected SqlInt32 _SupplierID;
        public SqlInt32 SupplierID
        {
            get
            {
                return _SupplierID;
            }
            set
            {
                _SupplierID = value;
            }
        }
        #endregion SupplierID

        #region SupplierName
        protected SqlString _SupplierName;
        public SqlString SupplierName
        {
            get
            {
                return _SupplierName;
            }
            set
            {
                _SupplierName = value;
            }
        }
        #endregion SupplierName

        #region ContactNo
        protected SqlString _ContactNo;
        public SqlString ContactNo
        {
            get
            {
                return _ContactNo;
            }
            set
            {
                _ContactNo = value;
            }
        }
        #endregion ContactNo

        #region Address
        protected SqlString _Address;
        public SqlString Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        #endregion Address

    }
}

