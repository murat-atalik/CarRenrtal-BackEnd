using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //Car messages
        public static string CarAdded = "Araba eklendi.";
        public static string CarAddedError = "Araba eklenemedi lütfen girdiğiniz verilere dikkat edin. " +
                                             "Araç adı en az 2 karakter içermeli ve günlük kirası 0 dan büyük olmalı.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdate = "Araba güncellendi.";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarsDetailsListed = "Arabaların detayları listelendi.";

        //Brand messages
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandsListed = "Markalar listelendi.";

        //Color messages
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorsListed = "Renkler listelendi.";

        //User messages
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserListed = "Kullanıcılar listelendi.";

        //Customer messages
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerAddedError = "Müşteri eklenemedi UserId boş olamaz.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerListed = "Müşteriler listelendi.";

        //Rental messages
        public static string RentalAdded = "Araç kiralama eklendi.";
        public static string RentalDeleted = "Araç kiralama silindi.";
        public static string RentalUpdated = "Araç kiralama güncellendi.";
        public static string RentalListed = "Araç kiralamaları listelendi.";
        public static string RentalAddedError = "Kiralanan araç birdaha kiralanamaz.";
    }
}
