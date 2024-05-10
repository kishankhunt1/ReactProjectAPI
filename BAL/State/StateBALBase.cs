using ReactProjectApi.DAL;
using ReactProjectApi.Models;

namespace ReactProjectApi.BAL;

public class StateBALBase
{
    #region Global Object
    StateDAL dal = new StateDAL();
    #endregion Global Object

    #region PR_MST_State_SelectPage
    public List<StateModel>? PR_State_SelectAll(/*StateModel modelMST_State*/)
    {
        return dal.PR_State_SelectAll(/*modelMST_State*/);
    }
    #endregion PR_MST_State_Insert

    #region PR_State_Insert
    public bool PR_State_Insert(StateModel modelState)
    {
        return dal.PR_State_Insert(modelState);
    }
    #endregion PR_State_Insert

    #region PR_State_Update
    public bool PR_State_Update(StateModel modelState)
    {
        return dal.PR_State_Update(modelState);
    }
    #endregion PR_State_Update

    #region PR_State_Delete
    public bool PR_State_Delete(int StateID)
    {
        return dal.PR_State_Delete(StateID);
    }
    #endregion PR_State_Delete

    #region PR_State_SelectPK
    public List<StateModel>? PR_State_SelectPK(int StateID)
    {
        return dal.PR_State_SelectPK(StateID);
    }
    #endregion PR_State_SelectPK
}
