using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarAddedError = "Araba eklenemedi lütfen girdiğiniz verilere dikkat edin. " +
                                             "Araç adı en az 2 karakter içermeli ve günlük kirası 0 dan büyük olmalı.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdate = "Araba güncellendi.";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarsDetailsListed = "Arabaların detayları listelendi.";

        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandsListed = "Markalar listelendi.";

        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorsListed = "Renkler listelendi.";
    }
}
