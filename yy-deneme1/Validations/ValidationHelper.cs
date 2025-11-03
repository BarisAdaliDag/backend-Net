
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace yy_deneme1
{

    /*
     Console.Write("Ad: ");
            string ad = ValidationHelper.ValidateNotEmpty(Console.ReadLine(), "Ad");

            Console.Write("Soyad: ");
            string soyad = ValidationHelper.ValidateNotEmpty(Console.ReadLine(), "Soyad");

            Console.Write("Email: ");
            string email = ValidationHelper.ValidateEmail(Console.ReadLine(), "Email");

            Console.Write("Şifre: ");
            string sifre = ValidationHelper.ValidatePassword(MaskPassword(), "Şifre");

            Console.Write("Doğum Tarihi (gg.aa.yyyy): ");
            DateTime dogumTarihi = ValidationHelper.ValidateDate(Console.ReadLine(), "Doğum Tarihi");

            uyeler.Add(new Uye(ad, soyad, email, dogumTarihi));
            Console.WriteLine("Üye başarıyla kaydedildi!");
     */
    public static class ValidationHelper
    {
        // Email Doğrulama
        public static string ValidateEmail(string input, string fieldName = "Email")
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ValidationException($"{fieldName} boş olamaz.", fieldName);

            input = input.Trim();

            if (!Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
                throw new ValidationException("Geçersiz email formatı.", fieldName);

            return input.ToLower();
        }

        // Şifre Doğrulama (6+ karakter, 1 harf, 1 rakam)
        public static string ValidatePassword(string input, string fieldName = "Şifre")
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ValidationException($"{fieldName} boş olamaz.", fieldName);

            if (input.Length < 6)
                throw new ValidationException($"{fieldName} en az 6 karakter olmalı.", fieldName);

            if (!Regex.IsMatch(input, @"[a-zA-Z]"))
                throw new ValidationException($"{fieldName} en az bir harf içermeli.", fieldName);

            if (!Regex.IsMatch(input, @"\d"))
                throw new ValidationException($"{fieldName} en az bir rakam içermeli.", fieldName);

            return input;
        }

        // Tarih Doğrulama (geçmişte veya bugün olabilir, gelecekte olamaz)
        public static DateTime ValidateDate(string input, string fieldName = "Tarih")
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ValidationException($"{fieldName} boş olamaz.", fieldName);

            if (!DateTime.TryParse(input, out DateTime date))
                throw new ValidationException("Geçersiz tarih formatı. (Ör: 15.03.2025)", fieldName);

            if (date > DateTime.Now.Date.AddDays(1))
                throw new ValidationException($"{fieldName} gelecekte olamaz.", fieldName);

            if (date.Year < 1900)
                throw new ValidationException($"{fieldName} çok eski olamaz.", fieldName);

            return date;
        }

        // Boş olmayan string
        public static string ValidateNotEmpty(string input, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ValidationException($"{fieldName} boş olamaz.", fieldName);

            return input.Trim();
        }

        // Sayı (int) doğrulama
        public static int ValidateInt(string input, string fieldName, int min = int.MinValue, int max = int.MaxValue)
        {
            if (!int.TryParse(input, out int value))
                throw new ValidationException($"Geçersiz sayı girişi.", fieldName);

            if (value < min || value > max)
                throw new ValidationException($"{fieldName} {min} ile {max} arasında olmalı.", fieldName);

            return value;
        }
    }
}
