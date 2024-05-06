using Microsoft.AspNetCore.Mvc;

namespace ReactProjectApi.CF
{
    public class APICommonFunctions : ControllerBase
    {
        #region GetResponseResult
        public IActionResult GetResponseResult<T>(List<T>? data)
        {
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (data != null && data.Count > 0)
            {
                response.Add("IsResult", 1);
                response.Add("message", "Data Found");
                response.Add("ResultList", data);
                return Ok(response);
            }
            else
            {
                response.Add("IsResult", 0);
                response.Add("message", "No Data Found");
                response.Add("ResultList", null);
                return Ok(response);
            }
        }
        #endregion GetResponseResult

        #region CreateResponse
        public IActionResult CreateResponse(bool isSucceess, string message)
        {
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (isSucceess)
            {
                response.Add("IsResult", 1);
                response.Add("message", message);
                response.Add("ResultList", null);
                return Ok(response);
            }
            else
            {
                response.Add("IsResult", 0);
                response.Add("message", message ?? "Some Error has Occurs");
                response.Add("ResultList", null);
                return Ok(response);
            }
        }
        #endregion CreateResponse

        #region GetResponseError
        public IActionResult GetResponseError(Exception ex)
        {
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            response.Add("IsResult", 0);
            response.Add("message", ex.Message.ToString());
            response.Add("ResultList", null);
            return Ok(response);
        }
        #endregion GetResponseError
    }
}
