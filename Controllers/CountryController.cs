using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactProjectApi.BAL;
using ReactProjectApi.CF;
using ReactProjectApi.Models;
using System.Runtime.CompilerServices;

namespace ReactProjectApi.Controllers
{
    [Area("MST")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        #region Global Variables 
        CountryBAL bal = new CountryBAL();
        APICommonFunctions apiCF = new APICommonFunctions();
        #endregion Global Variables

        #region PR_Country_SelectAll
        [HttpGet]
        public IActionResult PR_Country_SelectAll(/*[FromBody] MST_Country_FilterModel modelMST_CountryFilter*/)
        {
            try
            {
                var result = bal.PR_Country_SelectAll(/*modelMST_CountryFilter*/);
                return apiCF.GetResponseResult(result);
            }
            catch (Exception ex)
            {
                return apiCF.GetResponseError(ex);
            }

        }
        #endregion PR_Country_SelectAll

        #region PR_Country_Insert
        [HttpPost]
        public IActionResult PR_Country_Insert([FromForm] CountryModel modelCountry)
        {
            try
            {
                bool isSucceess = bal.PR_Country_Insert(modelCountry);
                return apiCF.CreateResponse(isSucceess, CommonVariables.InsertMessage);
            }
            catch (Exception ex)
            {
                return apiCF.GetResponseError(ex);
            }

        }
        #endregion PR_Country_Insert

        #region PR_Country_Update  
        [HttpPut("{CountryID}")]
        public IActionResult PR_Country_Update(int CountryID, [FromForm] CountryModel modelCountry)
        {
            try
            {
                modelCountry.CountryID = CountryID;
                bool isSucceess = bal.PR_Country_Update(modelCountry);
                return apiCF.CreateResponse(isSucceess, CommonVariables.UpdateMessage);
            }
            catch (Exception ex)
            {
                return apiCF.GetResponseError(ex);
            }
        }
        #endregion PR_Country_Update

        #region PR_Country_Delete
        [HttpPost("{CountryID}")]
        public IActionResult PR_Country_Delete(int CountryID)
        {
            try
            {
                bool isSucceess = bal.PR_Country_Delete(CountryID);
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

        #endregion PR_Country_Delete

        #region PR_Country_SelectPK
        [HttpGet("{CountryID}")]
        public IActionResult PR_Country_SelectPK(int CountryID)
        {
            try
            {
                var result = bal.PR_Country_SelectPK(CountryID);
                return apiCF.GetResponseResult(result);
            }
            catch (Exception ex)
            {
                return apiCF.GetResponseError(ex);
            }
        }

        #endregion PR_Country_SelectPK
    }
}
