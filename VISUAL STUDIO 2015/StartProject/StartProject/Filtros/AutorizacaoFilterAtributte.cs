﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;

namespace StartProject.Filtros
{
    class AutorizacaoFilterAtributte : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object usuario = filterContext.HttpContext.Session["usuarioLogado"];
            if (usuario == null)
            {
                filterContext.Result =  new RedirectToRouteResult(
                                            new RouteValueDictionary(
                                                 new { action = "Index", controller = "login" }
                                            )
                                         );
            }
        }
    }
}
