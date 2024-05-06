using ReactProjectApi.DAL;
using ReactProjectApi.Models;

namespace ReactProjectApi.BAL;

public class CountryBALBase
{
    #region Global Object
    CountryDAL dal = new CountryDAL();
    #endregion Global Object

    #region PR_MST_Country_SelectPage
    public List<CountryModel>? PR_Country_SelectAll(/*CountryModel modelMST_Country*/)
    {
        return dal.PR_Country_SelectAll(/*modelMST_Country*/);
    }
    #endregion PR_MST_Country_Insert

    #region PR_Country_Insert
    public bool PR_Country_Insert(CountryModel modelCountry)
    {
        return dal.PR_Country_Insert(modelCountry);
    }
    #endregion PR_Country_Insert

    #region PR_Country_Update
    public bool PR_Country_Update(CountryModel modelCountry)
    {
        return dal.PR_Country_Update(modelCountry);
    }
    #endregion PR_Country_Update

    #region PR_Country_Delete
    public bool PR_Country_Delete(int CountryID)
    {
        return dal.PR_Country_Delete(CountryID);
    }
    #endregion PR_Country_Delete

    #region PR_Country_SelectPK
    public List<CountryModel>? PR_Country_SelectPK(int CountryID)
    {
        return dal.PR_Country_SelectPK(CountryID);
    }
    #endregion PR_Country_SelectPK
}
