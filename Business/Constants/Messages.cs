using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static class ColorMassages
        {
            public static string SuccedColorAdd = "Renk Eklemesi Başarılı";
            public static string SuccedColorRemove= "Renk Silmesi Başarılı";
            public static string SuccedColorUpdate= "Renk Güncellemesi Başarılı";
            public static string UnsuccedColorUpdate= "Renk Güncellemesi Başarısız";
            public static string UnsuccedColorAdd= "Renk Eklemesi Başarısız";
            public static string UnsuccedColorRemove= "Renk Silmesi Başarısız";
        }

       

        public static class CarMassages
        {
            public static string SuccedCarAdd =      "Araç Eklemesi Başarılı";
            public static string SuccedCarRemove =   "Araç Silmesi Başarılı";
            public static string SuccedCarUpdate =   "Araç Güncellemesi Başarılı";
            public static string UnsuccedCarUpdate = "Araç Güncellemesi Başarısız";
            public static string UnsuccedCarAdd =    "Araç Eklemesi Başarısız";
            public static string UnsuccedCarRemove = "Araç Silmesi Başarısız";

        }
        public static class BrandMessages
        {
            public static string SuccedBrandAdd =        "Marka Eklemesi Başarılı";
            public static string SuccedBrandRemove =     "Marka Silmesi Başarılı";
            public static string SuccedBrandUpdate =     "Marka Güncellemesi Başarılı";
            public static string UnsuccedBrandUpdate =   "Marka Güncellemesi Başarısız";
            public static string UnsuccedBrandAdd =      "Marka Eklemesi Başarısız";
            public static string UnsuccedBrandRemove =   "Marka Silmesi Başarısız";
        }
    }
}
