using DAL_Celebrity_MSSQL;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ASPA008_1
{
    public class InfoAsyncActionFilter: Attribute, IAsyncActionFilter
    {
        public static readonly string Wikipedia = "WIKI";
        public static readonly string Facebook = "FACE";

        string infotype;
        public InfoAsyncActionFilter(string infotype = "") { 
            this.infotype = infotype.ToUpper();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            IRepository? repo = context.HttpContext.RequestServices.GetService<IRepository>();
            int id = (int)(context.ActionArguments["id"] ?? -1);
            Celebrity? celebrity = repo?.GetCelebrityById(id);
            if(infotype.Contains(Wikipedia) && celebrity != null)
            {
                context.HttpContext.Items.Add(Wikipedia, await WikiInfoCelebrity.GetRefereces(celebrity.FullName));
            }
            if (infotype.Contains(Facebook) && celebrity != null)
            {
                context.HttpContext.Items.Add(Facebook, getFromFace(celebrity.FullName));
            }
            await next();
        }
        string getFromFace(string fullname)
        {
            return "Info from Face";
        }
    }
}
