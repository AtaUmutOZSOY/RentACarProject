using Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static class AuthMessages
        {
            public static string UnSucceedLogIn = "Kullanıcı Adı veya Parola Yanlış";
            public static string SucceedUserRegistiration = "Kullanıcı Başarıyla Oluşturuldu";
            public static string AuthorizationDenied = "Yetkiniz Yok";
            public static string RegistirationDenied = "Kullanıcı Adı veya Parola Yanlış";
            public static string SuccessLogin = "Giriş Başarılı";
            public static string AccessTokenCreated = "Token Başarılı Şekilde Oluşturuldu";

        }
        

        public static class BrandMessages
        {
            
        }
        
        public static class UserMassages
        {
            public static string UserDeleted = "Kullanıcı Başarılı Bir Şekilde Silindi";
            public static string UserNotFound = "Kullanıcı Bulunamadı";
            public static string UserAlreadyExist = "Bu E-Posta Adresi ile Kayıtlı Kullanıcı Zaten Var";
        }
        public static class ActionMessages
        {
            public static string SuccedAdd = "Ekleme Başarılı";
            public static string SuccedRemove = "Silme Başarılı";
            public static string SuccedUpdate = "Güncelleme Başarılı";
            public static string UnsuccedUpdate = "Güncelleme Başarısız";
            public static string UnsucceddAdd = "Ekleme Başarısız";
            public static string UnsucceddRemove = "Silme Başarısız";

        }
    }
}
