using Restaurantium.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Abstract
{
    public interface IFooterDal
    {
        Task<FooterViewModel> GetFooterDataAsync();
    }
}
