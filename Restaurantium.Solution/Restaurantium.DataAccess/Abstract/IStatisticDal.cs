using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Abstract
{
    /*
     1) Aşçı sayısı
     2) Yemek sayısı
    3) Hizmet sayısı
    4)Referans sayısı
    5)Abone Sayısı
    6) Ortalama yemek ücreti
    7) Ortalama kahvaltı ücreti
    8) ortalama öğle yemeği ücreti
    9) ortalama akşam yemeği ücreti
    10) En pahalı yemeğin adı 
    11) En ucuz yemeğin adı
    12) Mesaj sayısı
     */
    public interface IStatisticDal
    {
        int GetChefCount();
        int GetMealCount();
        int GetServiceCount();
        int GetTestimonialCount();
        int GetSubscribeCount();
        decimal GetAvgMealPrice();
        decimal GetAvgBreakfastPrice();
        decimal GetAvgLunchPrice();
        decimal GetAvgDinnerPrice();
        string GetMostExpensiveMeal();
        string GetCheapestMeal();
        int GetContactMessageCount();

    }
}
