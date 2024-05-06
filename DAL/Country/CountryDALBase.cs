using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using ReactProjectApi.Models;

namespace ReactProjectApi.DAL;

public class CountryDALBase : DALHelper
{
    #region PR_Country_SelectAll
    public List<CountryModel>? PR_Country_SelectAll(/*CountryModel modelMST_Country*/)
    {
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Country_SelectAll");
            //sqlDB.AddInParameter(dbCMD, "PageOffset", SqlDbType.Int, modelMST_CountryFilter.F_PageOffset);
            //sqlDB.AddInParameter(dbCMD, "PageSize", SqlDbType.Int, modelMST_CountryFilter.F_PageSize);
            //sqlDB.AddOutParameter(dbCMD, "TotalRecords", SqlDbType.Int, 4);
            //sqlDB.AddInParameter(dbCMD, "CountryName", SqlDbType.NVarChar, modelMST_CountryFilter.F_CountryName);

            DataTable dt = new DataTable();
            using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
            {
                dt.Load(dr);
            }

            return ConvertDataTableToEntity<CountryModel>(dt);
        }
        catch (Exception ex)
        {
            var vExceptionHandler = ExceptionHandler(ex);
            if (vExceptionHandler.IsToThrowAnyException)
                throw vExceptionHandler.ExceptionToThrow;
            return null;
        }
    }

    #endregion PR_MST_Country_SelectPage

    #region PR_Country_Insert
    public bool PR_Country_Insert(CountryModel modelCountry)
    {
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Country_Insert");
            sqlDB.AddInParameter(dbCMD, "@CountryName", SqlDbType.NVarChar, modelCountry.CountryName);
            sqlDB.AddInParameter(dbCMD, "@CountryCode", SqlDbType.NVarChar, modelCountry.CountryCode);
            sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, DateTime.Now);
            sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, DateTime.Now);
            var vResult = sqlDB.ExecuteScalar(dbCMD);
            if (vResult == null)
                return true;
            return false;
        }
        catch (Exception ex)
        {
            var vExceptionHandler = ExceptionHandler(ex);
            if (vExceptionHandler.IsToThrowAnyException)
                throw vExceptionHandler.ExceptionToThrow;
            return false;
        }
    }

    #endregion PR_Country_Insert

    #region PR_Country_Update
    public bool PR_Country_Update(CountryModel modelCountry)
    {
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Country_UpdateByPK");
            sqlDB.AddInParameter(dbCMD, "@CountryID", SqlDbType.NVarChar, modelCountry.CountryID);
            sqlDB.AddInParameter(dbCMD, "@CountryName", SqlDbType.NVarChar, modelCountry.CountryName);
            sqlDB.AddInParameter(dbCMD, "@CountryCode", SqlDbType.NVarChar, modelCountry.CountryCode);
            sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, DateTime.Now);
            var vResult = sqlDB.ExecuteScalar(dbCMD);
            if (vResult == null)
                return true;
            return false;
        }
        catch (Exception ex)
        {
            var vExceptionHandler = ExceptionHandler(ex);
            if (vExceptionHandler.IsToThrowAnyException)
                throw vExceptionHandler.ExceptionToThrow;
            return false;
        }
    }

    #endregion PR_Country_Update

    #region PR_Country_Delete
    public bool PR_Country_Delete(int CountryID)
    {
        try
        {
            var result = PR_Country_SelectPK(CountryID);
            if (result != null && result.Count > 0)
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Country_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "CountryID", SqlDbType.Int, CountryID);
                int vReturnValue = sqlDB.ExecuteNonQuery(dbCMD);
                return (vReturnValue == 1 ? true : false);
            }
            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            var vExceptionHandler = ExceptionHandler(ex);
            if (vExceptionHandler.IsToThrowAnyException)
                throw vExceptionHandler.ExceptionToThrow;
            return false;
        }
    }

    #endregion PR_Country_Delete

    #region PR_Country_SelectPK
    public List<CountryModel>? PR_Country_SelectPK(int CountryID)
    {
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Country_SelectByPK");
            sqlDB.AddInParameter(dbCMD, "@CountryID", SqlDbType.Int, CountryID);
            DataTable dt = new DataTable();
            using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
            {
                dt.Load(dr);
            }
            return ConvertDataTableToEntity<CountryModel>(dt);
        }
        catch (Exception ex)
        {
            var vExceptionHandler = ExceptionHandler(ex);
            if (vExceptionHandler.IsToThrowAnyException)
                throw vExceptionHandler.ExceptionToThrow;
            return null;
        }
    }
    #endregion PR_Country_SelectPK
}
