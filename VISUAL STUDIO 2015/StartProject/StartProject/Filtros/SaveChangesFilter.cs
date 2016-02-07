using StartProject.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StartProject.Filtros
{
    class SaveChangesFilter : ActionFilterAttribute
    {
        private EstoqueContext context;

        public SaveChangesFilter(EstoqueContext context)
        {
            this.context = context;
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
            {

                this.context.SaveChanges();
            }

            this.context.Dispose();

        }
    }
}
