using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreativeWebAPI.Infrastructure.RouteNames
{
    /// <summary>
    /// Class used to parametarize route names for Creative resource.
    /// </summary>
    public static class CreativeRoute
    {
        public const string GET_ALL = "GetAllCreatives";
        public const string GET_BY_ID = "GetCreativeById";
        public const string CREATE = "CreateCreative";
        public const string UPDATE = "UpdateCreative";
        public const string DELETE = "DeleteCreative";
    }
}