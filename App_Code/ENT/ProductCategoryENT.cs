using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductCategoryENT
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel.ENT
{
    public class ProductCategoryENT
    {
        #region Constructor
        public ProductCategoryENT()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region ProductCategoryID
        protected SqlInt32 _ProductCategoryID;
        public SqlInt32 ProductCategoryID
        {
            get
            {
                return _ProductCategoryID;
            }
            set
            {
                _ProductCategoryID = value;
            }
        }
        #endregion ProductCategoryID

        #region ProductCategoryName
        protected SqlString _ProductCategoryName;
        public SqlString ProductCategoryName
        {
            get
            {
                return _ProductCategoryName;
            }
            set
            {
                _ProductCategoryName = value;
            }
        }
        #endregion ProductCategoryName
    }
}