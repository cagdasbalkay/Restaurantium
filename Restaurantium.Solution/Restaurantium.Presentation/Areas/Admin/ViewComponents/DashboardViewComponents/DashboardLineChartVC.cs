using Microsoft.AspNetCore.Mvc;

namespace Restaurantium.Presentation.Areas.Admin.ViewComponents.DashboardViewComponents
{
    public class DashboardLineChartVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
