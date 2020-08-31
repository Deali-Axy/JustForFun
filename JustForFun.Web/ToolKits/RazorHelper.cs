using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustForFun.Web.ToolKits {
    public static class RazorHelper {
        public static string GetCurrentControllerName(ViewContext viewContext) {
            return viewContext.RouteData.Values["controller"] == null ? "" : viewContext.RouteData.Values["controller"].ToString();
        }

        public static string GetCurrentActionName(ViewContext viewContext) {
            return viewContext.RouteData.Values["action"] == null ? "" : viewContext.RouteData.Values["action"].ToString();
        }

        public static string MenuHighlight(ViewContext viewContext, string controllerName) {
            return controllerName == GetCurrentControllerName(viewContext) ? "layui-this" : "";
        }

        public static string SideNavHighlight(ViewContext viewContext, string actionName) {
            return actionName == GetCurrentActionName(viewContext) ? "layui-this" : "";
        }
    }
}