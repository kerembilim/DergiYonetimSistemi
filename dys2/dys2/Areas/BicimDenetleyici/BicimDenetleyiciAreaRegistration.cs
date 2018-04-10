using System.Web.Mvc;

namespace dys2.Areas.BicimDenetleyici
{
    public class BicimDenetleyiciAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BicimDenetleyici";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BicimDenetleyici_default",
                "BicimDenetleyici/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}