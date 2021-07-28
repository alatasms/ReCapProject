using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string Added = "Eklendi";
        public static string Deleted = "Silindi";
        public static string Updated = "Güncellendi";
        public static string Listed = "Listelendi ";

        public static string NoAdded = "Eklenemedi";
        public static string NoDeleted = "Silinemedi";
        public static string NoUpdated = "Güncellenemedi";
        public static string NoListed = "Listelenemedi ";


        public static string NameInvalid = "İsim geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ImageNotFound = "Resim bulunamadı";

        public static string LimitExceded = "Resim limiti aşıldı";

        public static string NoImage = "Resim yok";
        public static string UserRegistered = "Kayıt başarılı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string YetkiYok { get; internal set; }
    }
}
