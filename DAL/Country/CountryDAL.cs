using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ReactProjectApi.Models;
using System.Data.Common;
using System.Data;

namespace ReactProjectApi.DAL;

public class CountryDAL:CountryDALBase
{
    #region PR_Country_SelectComboBox
    public List<CountryComboBox>? PR_Country_SelectComboBox()
    {
        try
        {
            SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("dbo.PR_Country_SelectComboBox");

            DataTable dt = new DataTable();
            using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
            {
                dt.Load(dr);
            }

            return ConvertDataTableToEntity<CountryComboBox>(dt);
        }
        catch (Exception ex)
        {
            var vExceptionHandler = ExceptionHandler(ex);
            if (vExceptionHandler.IsToThrowAnyException)
                throw vExceptionHandler.ExceptionToThrow;
            return null;
        }
    }

    #endregion PR_Country_SelectComboBox
}
