using System.Web.Mvc;

namespace TestG.Areas.adminarea
{
    public class adminareaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "adminarea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "adminarea_default",
                "adminarea/{controller}/{action}/{id}",
                new { action = "IndexAdmin",Controller="HomeAdmin" ,id = UrlParameter.Optional }
            );
        }
    }
}