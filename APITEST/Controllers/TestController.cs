using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using APITEST.Route;
using APITEST.Models.V1.Request;
using APITEST.Models.V1.Responce;
using APITEST.Utility.V1;
using Newtonsoft.Json.Linq;

namespace APITEST.Controllers
{
    public class TestController : ApiController
    {
        TestUtility obj = new TestUtility();
        SystemException exe = new SystemException();

        [HttpPost]
        [Route(RouteA.TestRoutes.UserLogin)]
        public Responce checkLogin(reqLogin ReqPara)
        {
            string result = "";
            string objectName = "";
            string getresult = "";
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    getresult = obj.checkUserLogin(ReqPara);
                    string[] getUserdetails = getresult.Split('|');

                    if (getUserdetails.Length > 0)
                    {
                        result = getUserdetails[0];
                        objectName = getUserdetails[1];

                    }

                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(getresult);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                //exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.UserLogin, 0);
            }
            return Response;
        }

    }
}
