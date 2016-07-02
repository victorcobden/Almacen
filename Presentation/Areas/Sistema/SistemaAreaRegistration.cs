using System.Web.Mvc;

namespace Presentation.Areas.Sistema
{
    public class SistemaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Sistema";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Sistema_default",
                "Sistema/{controller}/{action}/{id}",
                new { controller = "Dashboard",action = "Index", id = UrlParameter.Optional },
                new string[] { "Presentation.Areas.Sistema.Controllers" }
            );
        }
    }
}