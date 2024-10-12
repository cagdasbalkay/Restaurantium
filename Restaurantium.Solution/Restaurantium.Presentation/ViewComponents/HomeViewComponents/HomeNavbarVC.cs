using Microsoft.AspNetCore.Mvc;

namespace Restaurantium.Presentation.ViewComponents.HomeViewComponents
{
    public class HomeNavbarVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

