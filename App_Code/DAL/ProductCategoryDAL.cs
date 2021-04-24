using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;

/// <summary>
/// Summary description for ProductCategoryDAL
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel.DAL
{
    public class ProductCategoryDAL : DatabaseConfig
    {
        #region Constructor
        public ProductCategoryDAL()
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
                        objCmd.CommandText = "PR_ProductCategory_SelectAll";
                        #endregion Prepare Command

                        #region Read Data & Set Control
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
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
        public ProductCategoryENT SelectByPK(SqlInt32 ProductCategoryID)
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
                        objCmd.CommandText = "PR_ProductCategory_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
                        #endregion Prepare Command

                        #region Read Data & Set Controls
                        ProductCategoryENT entProductCategory = new ProductCategoryENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                //if (!objSDR["ProductCategoryID"].Equals(DBNull.Value))
                                //    entProductCategory.ProductCategoryID = Convert.ToInt32(objSDR["ProductCategoryID"]);
                                if (!objSDR["ProductCategoryName"].Equals(DBNull.Value))
                                    entProductCategory.ProductCategoryName = Convert.ToString(objSDR["ProductCategoryName"]);
                                
                            }
                            return entProductCategory;
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
        public Boolean Insert(ProductCategoryENT entProductCategory)
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
                        objCmd.CommandText = "PR_ProductCategory_Insert";
                        objCmd.Parameters.Add("@ProductCategoryID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@ProductCategoryName", entProductCategory.ProductCategoryName);
                        
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        if (objCmd.Parameters["@ProductCategoryID"] != null)
                            entProductCategory.ProductCategoryID = Convert.ToInt32(objCmd.Parameters["@ProductCategoryID"].Value);
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
        public Boolean Delete(SqlInt32 ProductCategoryID)
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
                        objCmd.CommandText = "PR_ProductCategory_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
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
        public Boolean Update(ProductCategoryENT entProductCategory)
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
                        objCmd.CommandText = "PR_ProductCategory_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@ProductCategoryID", entProductCategory.ProductCategoryID);
                        objCmd.Parameters.AddWithValue("@ProductCategoryName", entProductCategory.ProductCategoryName);
                        
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