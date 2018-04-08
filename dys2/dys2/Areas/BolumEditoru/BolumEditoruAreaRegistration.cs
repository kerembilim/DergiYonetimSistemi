using System.Web.Mvc;

namespace dys2.Areas.BolumEditoru
{
    public class BolumEditoruAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BolumEditoru";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BolumEditoru_default",
                "BolumEditoru/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}