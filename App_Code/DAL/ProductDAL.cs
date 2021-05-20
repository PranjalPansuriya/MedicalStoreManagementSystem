using MedicalStoreManagementSystem_AdminPanel.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web;

/// <summary>
/// Summary description for ProductDAL
/// </summary>
/// 
namespace MedicalStoreManagementSystem_AdminPanel.DAL
{
    public class ProductDAL:DatabaseConfig
    {
        #region Constructor
        public ProductDAL()
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
                        objCmd.CommandText = "PR_Product_SelectAll";
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
        public ProductENT SelectByPK(SqlInt32 ProductID)
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
                        objCmd.CommandText = "PR_Product_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ProductID", ProductID);
                        #endregion Prepare Command

                        #region Read Data & Set Controls
                        ProductENT entProduct = new ProductENT();
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["ProductID"].Equals(DBNull.Value))
                                    entProduct.ProductID = Convert.ToInt32(objSDR["ProductID"]);
                                if (!objSDR["ProductName"].Equals(DBNull.Value))
                                    entProduct.ProductName = Convert.ToString(objSDR["ProductName"]);
                                if (!objSDR["ProductCategoryID"].Equals(DBNull.Value))
                                    entProduct.ProductCategoryID = Convert.ToInt32(objSDR["ProductCategoryID"]);
                                if (!objSDR["CompanyName"].Equals(DBNull.Value))
                                    entProduct.CompanyName = Convert.ToString(objSDR["CompanyName"]);
                                if (!objSDR["SupplierID"].Equals(DBNull.Value))
                                    entProduct.SupplierID = Convert.ToInt32(objSDR["SupplierID"]);
                                if (!objSDR["Quantity"].Equals(DBNull.Value))
                                    entProduct.Quantity = Convert.ToInt32(objSDR["Quantity"]);
                                if (!objSDR["ProductExpiryDate"].Equals(DBNull.Value))
                                    entProduct.ProductExpiryDate = Convert.ToDateTime(objSDR["ProductExpiryDate"]);
                                if (!objSDR["DeliveryDate"].Equals(DBNull.Value))
                                    entProduct.DeliveryDate = Convert.ToDateTime(objSDR["DeliveryDate"]);
                                if (!objSDR["Location"].Equals(DBNull.Value))
                                    entProduct.Location = Convert.ToString(objSDR["Location"]);
                                if (!objSDR["OtherDescription"].Equals(DBNull.Value))
                                    entProduct.OtherDescription = Convert.ToString(objSDR["OtherDescription"]);
                                if (!objSDR["PricePerUnit"].Equals(DBNull.Value))
                                    entProduct.PricePerUnit = Convert.ToDouble(objSDR["PricePerUnit"]);

                            }
                            return entProduct;
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

        #region SelectByProductCategoryID
        public DataTable SelectByProductCategoryID(SqlInt32 ProductCategoryID)
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
                        objCmd.CommandText = "PR_Product_SelectForDropDownListByProductCatgeory";
                        objCmd.Parameters.AddWithValue("@ProductCategoryID", ProductCategoryID);
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

        #region SelectQuantityByProductID
        public int SelectQuantityByProductID(SqlInt32 ProductID)
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
                        objCmd.CommandText = "PR_Product_SelectQuantityByProductID";
                        objCmd.Parameters.AddWithValue("@ProductID", ProductID);
                        #endregion Prepare Command

                        #region Read Data & Set Controls
                        int Quantity = 0;
                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            while (objSDR.Read())
                            {
                                
                                if (!objSDR["Quantity"].Equals(DBNull.Value))
                                    Quantity = Convert.ToInt32(objSDR["Quantity"]);
                            }
                            return Quantity;
                        }
                        #endregion Read Data & Set Controls
                    }

                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return 0;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
                        return 0;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion SelectQuantityByProductID

        #endregion Select Operation

        #region Insert Operation
        public Boolean Insert(ProductENT entProduct)
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
                        objCmd.CommandText = "PR_Product_Insert";
                        objCmd.Parameters.Add("@ProductID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@ProductName", entProduct.ProductName);
                        objCmd.Parameters.AddWithValue("@ProductCategoryID", entProduct.ProductCategoryID);
                        objCmd.Parameters.AddWithValue("@CompanyName", entProduct.CompanyName);
                        objCmd.Parameters.AddWithValue("@SupplierID", entProduct.SupplierID);
                        objCmd.Parameters.AddWithValue("@Quantity", entProduct.Quantity);
                        objCmd.Parameters.AddWithValue("@ProductExpiryDate", entProduct.ProductExpiryDate);
                        objCmd.Parameters.AddWithValue("@DeliveryDate", entProduct.DeliveryDate);
                        objCmd.Parameters.AddWithValue("@Location", entProduct.Location);
                        objCmd.Parameters.AddWithValue("@OtherDescription", entProduct.OtherDescription);
                        objCmd.Parameters.AddWithValue("@PricePerUnit", entProduct.PricePerUnit);
                        #endregion Prepare Command

                        objCmd.ExecuteNonQuery();
                        if (objCmd.Parameters["@ProductID"] != null)
                            entProduct.ProductID = Convert.ToInt32(objCmd.Parameters["@ProductID"].Value);
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
        public Boolean Delete(SqlInt32 ProductID)
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
                        objCmd.CommandText = "PR_Product_DeleteByPK";
                        objCmd.Parameters.AddWithValue("@ProductID", ProductID);
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
        public Boolean Update(ProductENT entProduct)
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
                        objCmd.CommandText = "PR_Product_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@ProductID", entProduct.ProductID);
                        objCmd.Parameters.AddWithValue("@ProductName", entProduct.ProductName);
                        objCmd.Parameters.AddWithValue("@ProductCategoryID", entProduct.ProductCategoryID);
                        objCmd.Parameters.AddWithValue("@CompanyName", entProduct.CompanyName);
                        objCmd.Parameters.AddWithValue("@SupplierID", entProduct.SupplierID);
                        objCmd.Parameters.AddWithValue("@Quantity", entProduct.Quantity);
                        objCmd.Parameters.AddWithValue("@ProductExpiryDate", entProduct.ProductExpiryDate);
                        objCmd.Parameters.AddWithValue("@DeliveryDate", entProduct.DeliveryDate);
                        objCmd.Parameters.AddWithValue("@Location", entProduct.Location);
                        objCmd.Parameters.AddWithValue("@OtherDescription", entProduct.OtherDescription);
                        objCmd.Parameters.AddWithValue("@PricePerUnit", entProduct.PricePerUnit);
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

        #region Decrease Quantity When Product Added TO Cart
        public Boolean DecreaseQuantity(SqlInt32 ProductID,SqlInt32 Quantity)
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
                        objCmd.CommandText = "PR_Product_DecreaseQuantityByProductID";
                        objCmd.Parameters.AddWithValue("@ProductID", ProductID);
                        objCmd.Parameters.AddWithValue("@Quantity", Quantity);
                        
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
        #endregion Decrease Quantity When Product Added TO Cart

        #region Increase Quantity When Product Removed From Cart
        public Boolean IncreaseQuantity(SqlInt32 ProductID, SqlInt32 Quantity)
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
                        objCmd.CommandText = "PR_Product_IncreaseQuantityByProductID";
                        objCmd.Parameters.AddWithValue("@ProductID", ProductID);
                        objCmd.Parameters.AddWithValue("@Quantity", Quantity);

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
        #endregion Increase Quantity When Product Removed From Cart
    }
}
