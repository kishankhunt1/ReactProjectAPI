using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactProjectApi.BAL;
using ReactProjectApi.CF;
using ReactProjectApi.Models;

namespace ReactProjectApi.Controllers
{
    [Area("MST")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        #region Global Variables 
        StateBAL bal = new StateBAL();
        APICommonFunctions apiCF = new APICommonFunctions();
        #endregion Global Variables

        #region PR_State_SelectAll
        [HttpGet]
        public IActionResult PR_State_SelectAll(/*[FromBody] MST_State_FilterModel modelMST_StateFilter*/)
        {
            try
            {
                var result = bal.PR_State_SelectAll(/*modelMST_StateFilter*/);
                return apiCF.GetResponseResult(result);
            }
            catch (Exception ex)
            {
                return apiCF.GetResponseError(ex);
            }

        }
        #endregion PR_State_SelectAll

        #region PR_State_Insert
        [HttpPost]
        public IActionResult PR_State_Insert([FromForm] StateModel modelState)
        {
            try
            {
                bool isSucceess = bal.PR_State_Insert(modelState);
                return apiCF.CreateResponse(isSucceess, CommonVariables.InsertMessage);
            }
            catch (Exception ex)
            {
                return apiCF.GetResponseError(ex);
            }

        }
        #endregion PR_State_Insert

        #region PR_State_Update  
        [HttpPut("{StateID}")]
        public IActionResult PR_State_Update(int StateID, [FromForm] StateModel modelState)
        {
            try
            {
                modelState.StateID = StateID;
                bool isSucceess = bal.PR_State_Update(modelState);
                return apiCF.CreateResponse(isSucceess, CommonVariables.UpdateMessage);
            }
            catch (Exception ex)
            {
                return apiCF.GetResponseError(ex);
            }
        }
        #endregion PR_State_Update

        #region PR_State_Delete
        [HttpPost("{StateID}")]
        public IActionResult PR_State_Delete(int StateID)
        {
            try
            {
                bool isSucceess = bal.PR_State_Delete(StateID);
                if (isSucceess)
                {
                    return apiCF.CreateResponse(isSucceess, CommonVariables.DeleteMessage);
                }
                else
                {
                    return apiCF.CreateResponse(isSucceess, "Some Error has Occured...");
                }
            }
            catch (Exception ex)
            {
                return apiCF.GetResponseError(ex);
            }
        }

        #endregion PR_State_Delete

        #region PR_State_SelectPK
        [HttpGet("{StateID}")]
        public IActionResult PR_State_SelectPK(int StateID)
        {
            try
            {
                var result = bal.PR_State_SelectPK(StateID);
                return apiCF.GetResponseResult(result);
            }
            catch (Exception ex)
            {
                return apiCF.GetResponseError(ex);
            }
        }

        #endregion PR_State_SelectPK
    }
}
