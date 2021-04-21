using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DatabaseConfig
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel
{
    public class DatabaseConfig
    {
        #region Constructor
        public DatabaseConfig()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        public static string ConnectionString = ConfigurationManager.ConnectionStrings["MedicalStoreManagementSystemConnectionString"].ConnectionString;
    }
}
