using Core.Entities.Concrete;
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
        public static string BrandNameAlreadyExists = "Marka sistemde kayıtlı";

        //Color messages
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorsListed = "Renkler listelendi.";
        public static string ColorAlreadyExists = "Renk sistemde kayıtlı";


        //User messages
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserListed = "Kullanıcılar listelendi.";
        public static string EmailAlreadyExists = "Bu email adresi zaten mevcut.";

        //Customer messages
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerMustUniqe = "Aynı Id numarasına sahip bir başka müşteri bulunmakta.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerListed = "Müşteriler listelendi.";
        public static string UserIdNotExist = "Bu id'ye sahip bir kullanıcı yoktur.";
        public static string UserNotExist = "Bu bilgilere sahip kullanıcı yoktur.";

        //Rental messages
        public static string RentalAdded = "Araç kiralama eklendi.";
        public static string RentalDeleted = "Araç kiralama silindi.";
        public static string RentalUpdated = "Araç kiralama güncellendi.";
        public static string RentalListed = "Araç kiralamaları listelendi.";
        public static string RentalAddedError = "Kiralanan araç birdaha kiralanamaz.";
        public static string CarNotReturn="Araç Hala kirada.";
        public static string CarNotExists="Araç mevcut değil.";

        //CarImages
        public static string CarImageAdded = "Araç resmi eklendi.";
        public static string CarImageDeleted = "Araç resmi silindi.";
        public static string CarImageUpdated = "Araç resmi güncellendi.";
        public static string CarsImagesListed = "Tüm araçların resimleri listelendi.";
        public static string CarImagesListed = "Seçilen aracın  resimleri listelendi.";
        public static string CarImageLimitExceeded = "Maksimum resim yükleme limitine ulaşıldı.";
        public static string CarImageDefault = "Araç resmi bulunmamaktadır.";
        public static string ImageNotExists="Fotoğraf bulunamadı";

        public static string UserExists = "Kullanıcı mevcut.";

        public static string UserLogin = "Sisteme giriş başarılı";

        public static string WrongPassword = "Şifre hatalı.";
        public static string AccessTokenCreated = "Access token oluşturuldu";
    }
}
