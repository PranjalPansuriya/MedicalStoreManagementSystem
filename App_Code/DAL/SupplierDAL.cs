using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SupplierDAL
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel.DAL
{
    public class SupplierDAL : DatabaseConfig
    {
        #region Constructor
        public SupplierDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region LocalVariable
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
        #endregion LocalVariable

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Supplier_SelectAll";
                        #endregion Prepare Command

                        #region Read Data & Set Control
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            //Convert.ToDateTime(objSDR["BirthDate"].ToString()).ToString("MM/dd/yyyy");
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion Read Data & Set Control
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion SelectAll

        #region SelectByPK
        public SupplierENT SelectByPK(SqlInt32 SupplierID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Supplier_SelectByPK";
                        objCmd.Parameters.AddWithValue("@SupplierID", SupplierID);
                        #endregion Prepare Command

                        #region Read Data & Set Controls
                        SupplierENT entSupplier = new SupplierENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["SupplierID"].Equals(DBNull.Value))
                                    entSupplier.SupplierID = Convert.ToInt32(objSDR["SupplierID"]);
                                if (!objSDR["SupplierName"].Equals(DBNull.Value))
                                    entSupplier.SupplierName = Convert.ToString(objSDR["SupplierName"]);
                                if (!objSDR["Address"].Equals(DBNull.Value))
                                    entSupplier.Address = Convert.ToString(objSDR["Address"]);
                                if (!objSDR["ContactNo"].Equals(DBNull.Value))
                                    entSupplier.ContactNo = Convert.ToString(objSDR["ContactNo"]);
                                

                            }
                            return entSupplier;
                        }
                        #endregion Read Data & Set Controls
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion SelectByPK

        #endregion Select Operation

        #region Insert Operation
        public Boolean Insert(SupplierENT entSupplier)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Supplier_Insert";
                        objCmd.Parameters.Add("@SupplierID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@SupplierName", entSupplier.SupplierName);
                        objCmd.Parameters.AddWithValue("@Address", entSupplier.Address);
                        objCmd.Parameters.AddWithValue("@ContactNo", entSupplier.ContactNo);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        if (objCmd.Parameters["@SupplierID"] != null)
                            entSupplier.SupplierID = Convert.ToInt32(objCmd.Parameters["@SupplierID"].Value);
                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Insert Operation

        #region Delete Operation
        public Boolean Delete(SqlInt32 SupplierID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare_Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Supplier_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@SupplierID", SupplierID);
                        #endregion Prepare_Command

                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                        {
                            objConn.Close();
                        }
                    }
                }
            }
        }
        #endregion Delete Operation

        #region Update Operation
        public Boolean Update(SupplierENT entSupplier)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();
                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Supplier_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@SupplierID", entSupplier.SupplierID);
                        objCmd.Parameters.AddWithValue("@SupplierName", entSupplier.SupplierName);
                        objCmd.Parameters.AddWithValue("@Address", entSupplier.Address);
                        objCmd.Parameters.AddWithValue("@ContactNo", entSupplier.ContactNo);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        return true;
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion Update Operation
    }
}
