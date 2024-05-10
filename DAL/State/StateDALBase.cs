using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ReactProjectApi.Models;
using System.Data.Common;
using System.Data;

namespace ReactProjectApi.DAL;

public class StateDALBase:DALHelper
{
    #region PR_State_SelectAll
    public List<StateModel>? PR_State_SelectAll(/*StateModel modelMST_State*/)
    {
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_State_SelectAll");
            //sqlDB.AddInParameter(dbCMD, "PageOffset", SqlDbType.Int, modelMST_StateFilter.F_PageOffset);
            //sqlDB.AddInParameter(dbCMD, "PageSize", SqlDbType.Int, modelMST_StateFilter.F_PageSize);
            //sqlDB.AddOutParameter(dbCMD, "TotalRecords", SqlDbType.Int, 4);
            //sqlDB.AddInParameter(dbCMD, "StateName", SqlDbType.NVarChar, modelMST_StateFilter.F_StateName);

            DataTable dt = new DataTable();
            using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
            {
                dt.Load(dr);
            }

            return ConvertDataTableToEntity<StateModel>(dt);
        }
        catch (Exception ex)
        {
            var vExceptionHandler = ExceptionHandler(ex);
            if (vExceptionHandler.IsToThrowAnyException)
                throw vExceptionHandler.ExceptionToThrow;
            return null;
        }
    }

    #endregion PR_MST_State_SelectPage

    #region PR_State_Insert
    public bool PR_State_Insert(StateModel modelState)
    {
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_State_Insert");
            sqlDB.AddInParameter(dbCMD, "@StateName", SqlDbType.NVarChar, modelState.StateName);
            sqlDB.AddInParameter(dbCMD, "@CountryID", SqlDbType.Int, modelState.CountryID);
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

    #endregion PR_State_Insert

    #region PR_State_Update
    public bool PR_State_Update(StateModel modelState)
    {
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_State_UpdateByPK");
            sqlDB.AddInParameter(dbCMD, "@StateID", SqlDbType.NVarChar, modelState.StateID);
            sqlDB.AddInParameter(dbCMD, "@StateName", SqlDbType.NVarChar, modelState.StateName);
            sqlDB.AddInParameter(dbCMD, "@CountryID", SqlDbType.Int, modelState.CountryID);
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

    #endregion PR_State_Update

    #region PR_State_Delete
    public bool PR_State_Delete(int StateID)
    {
        try
        {
            var result = PR_State_SelectPK(StateID);
            if (result != null && result.Count > 0)
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_State_DeleteByPK");
                sqlDB.AddInParameter(dbCMD, "StateID", SqlDbType.Int, StateID);
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

    #endregion PR_State_Delete

    #region PR_State_SelectPK
    public List<StateModel>? PR_State_SelectPK(int StateID)
    {
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_State_SelectByPK");
            sqlDB.AddInParameter(dbCMD, "@StateID", SqlDbType.Int, StateID);
            DataTable dt = new DataTable();
            using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
            {
                dt.Load(dr);
            }
            return ConvertDataTableToEntity<StateModel>(dt);
        }
        catch (Exception ex)
        {
            var vExceptionHandler = ExceptionHandler(ex);
            if (vExceptionHandler.IsToThrowAnyException)
                throw vExceptionHandler.ExceptionToThrow;
            return null;
        }
    }
    #endregion PR_State_SelectPK
}
