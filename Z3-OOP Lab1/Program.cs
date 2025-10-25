namespace Z3_OOP_Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // User(Id,Username,Password,Email,EmailConfirm,FirstName,LastName,CreatedDate)
            // Id : Sadece okunabilir olacak. Tip Guid olsun.
            // Username bos gecilemez, 3 ile 20 karakter arasinda olabilir. Eger fazla olursa kirpilsin, eksik kalirsa sol tarafi * sembolu ile doldurulsun.
            // Password en az 8 karakter uzunlugunda olmalidir. Assagi bir durumda herhangi bir karakter ile doldurunuz.
            // Email : Bos gecilemez olsun.
            // EmailConfirm : Sadece okunabilir olsun. Email ile ayni degeri dondursun.
            // FirstName ve LastName : Bos gecilemez.

            // Message(Id,Content,SenderId,RecevierId,CreatedDate)
            // Id : Sadece okunabilir olacak. Tip Guid olsun.
            // Content : En az 1 karakter uzunlugunda olmalidir. Assagi bir durumda herhangi bir karakter ile doldurunuz.
            // SenderId ve RecevierId : Bos gecilemez.
            // CreatedDate : Sadece okunabilir olsun. Mesajin olusturuldugu tarihi dondursun.

            // Generic Repository(CRUD) yapisi olusturunuz. Static bir listeyi depo haline getiriniz.
            // Kullanici uyelik olusturur.
            // Kullanici giris yapar.
            // Belirtilen kullanici id veya kullanici adi ile mesaj gonderir.
            // Kullanici cikis yapar.
            // Diger kullanici giris yapip gelen mesajlari gorur.
            // Cevap verir.
        }
    }
}
