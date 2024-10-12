using Microsoft.AspNetCore.Mvc;

namespace Restaurantium.Presentation.ViewComponents.LayoutViewComponents
{
    public class FooterNewsletterVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
