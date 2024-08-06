using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APITEST.Route
{
    public class RouteA
    {
        public const string Root = "api";
        public const string Environment = "Dev";
        public const string Version = "v1";
        public const string Base = Root + "/" + Environment + "/" + Version;

        public static class TestRoutes
        {
            public const string UserLogin = Base + "/UserLogin";
        }
    }
}