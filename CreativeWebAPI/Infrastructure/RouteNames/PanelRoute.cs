using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreativeWebAPI.Infrastructure.RouteNames
{
    /// <summary>
    /// Class used to parametarize route names for Panel resource.
    /// </summary>
    public static class PanelRoute
    {
        public const string GET_ALL = "GetAllPanels";
        public const string GET_BY_ID = "GetPanelById";
        public const string CREATE = "CreatePanel";
        public const string UPDATE = "UpdatePanel";
        public const string DELETE = "DeletePanel";
    }
}