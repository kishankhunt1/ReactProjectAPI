using ReactProjectApi.DAL;
using ReactProjectApi.Models;

namespace ReactProjectApi.BAL;

public class CountryBAL: CountryBALBase
{
    #region Global Object
    CountryDAL dal = new CountryDAL();
    #endregion Global Object

    #region PR_Country_SelectComboBox
    public List<CountryComboBox>? PR_Country_SelectComboBox()
    {
        return dal.PR_Country_SelectComboBox();
    }
    #endregion PR_Country_SelectComboBox
}
