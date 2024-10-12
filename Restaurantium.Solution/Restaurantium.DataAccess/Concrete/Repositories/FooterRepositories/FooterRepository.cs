using Microsoft.EntityFrameworkCore;
using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Context;
using Restaurantium.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Concrete.Repositories.FooterRepositories
{
    public class FooterRepository : IFooterDal
    {
        private readonly RestaurantiumContext _context;

        public FooterRepository(RestaurantiumContext context)
        {
            _context = context;
        }

        public async Task<FooterViewModel> GetFooterDataAsync()
        {
            var workingHour = await _context.WorkingHours.FirstOrDefaultAsync();
            var footerContact = await _context.FooterContacts.FirstOrDefaultAsync();
           
                var viewModel = new FooterViewModel
                {
                    WorkingHour = workingHour,
                    FooterContact = footerContact
                };

                return viewModel;
            }

            
        }
    }


