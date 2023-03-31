/* 
date:31.03.2023
PROJE-1 : Console Telefon Rehberi Uygulaması

ozellikler:
-Telefon Numarası Kaydets
-Telefon Numarası Sil
-Telefon Numarası Güncelle
-Rehber Listeleme (A-Z, Z-A seçimli)
-Rehberde Arama
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace TelefonRehberi
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> telefonRehberi = new Dictionary<string, string>()
            {
                {"Ali", "0555 555 55 55" },
                {"Ayşe", "0544 444 44 44" },
                {"Mehmet", "0533 333 33 33" },
                {"Zeynep", "0522 222 22 22" },
                {"Kemal", "0511 111 11 11" }
            };

            while (true)
            {
                Console.WriteLine("Telefon Rehberi Programına Hoşgeldiniz!");
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz:");
                Console.WriteLine("1. Yeni Telefon Numarası Kaydetmek");
                Console.WriteLine("2. Varolan Telefon Numarasını Silmek");
                Console.WriteLine("3. Varolan Telefon Numarasını Güncellemek");
                Console.WriteLine("4. Rehber Listeleme (A-Z, Z-A seçimli)");
                Console.WriteLine("5. Rehberde Arama Yapmak");
                Console.WriteLine("6. Programdan Çıkmak");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.WriteLine("Kaydetmek istediğiniz kişinin adını giriniz:");
                        string yeniAd = Console.ReadLine();

                        Console.WriteLine("Kaydetmek istediğiniz kişinin telefon numarasını giriniz:");
                        string yeniNumara = Console.ReadLine();

                        if (!telefonRehberi.ContainsKey(yeniAd))
                        {
                            telefonRehberi.Add(yeniAd, yeniNumara);
                            Console.WriteLine($"{yeniAd} adlı kişinin telefon numarası kaydedildi.");
                        }
                        else
                        {
                            Console.WriteLine($"{yeniAd} adlı kişi zaten rehberde kayıtlı.");
                        }
                        break;

                    case "2":
                        Console.WriteLine("Silmek istediğiniz kişinin adını giriniz:");
                        string silinecekAd = Console.ReadLine();

                        if (telefonRehberi.ContainsKey(silinecekAd))
                        {
                            telefonRehberi.Remove(silinecekAd);
                            Console.WriteLine($"{silinecekAd} adlı kişinin telefon numarası silindi.");
                        }
                        else
                        {
                            Console.WriteLine($"{silinecekAd} adlı kişi rehberde kayıtlı değil.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Güncellemek istediğiniz kişinin adını giriniz:");
                        string guncellenecekAd = Console.ReadLine();

                        if (telefonRehberi.ContainsKey(guncellenecekAd))
                        {
                            Console.WriteLine($"{guncellenecekAd} adlı kişinin mevcut telefon numarası: {telefonRehberi[guncellenecekAd]}");

                            Console.WriteLine("Yeni telefon numarasını giriniz:");
                            string yeniNumaraGuncelleme = Console.ReadLine();

                            telefonRehberi[guncellenecekAd] = yeniNumaraGuncelleme;
                            Console.WriteLine($"{guncellenecekAd} adlı kişinin telefon numarası güncellendi.");
                        }
                        else
                        {
                            Console.WriteLine($"{guncellenecekAd} adlı kişi rehberde kayıtlı değil.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("Rehber Listeleme");
                        Console.WriteLine("1. A-Z sırala");
                        Console.WriteLine("2. Z-A sırala");
                        string siralamaSecim = Console.ReadLine();

                        if (siralamaSecim == "1")
                        {
                            Console.WriteLine("A-Z sıralama:");
                            foreach (KeyValuePair<string, string> kisi in telefonRehberi.OrderBy(k => k.Key))
                            {
                                Console.WriteLine($"{kisi.Key}: {kisi.Value}");
                            }
                        }
                        else if (siralamaSecim == "2")
                        {
                            Console.WriteLine("Z-A sıralama:");
                            foreach (KeyValuePair<string, string> kisi in telefonRehberi.OrderByDescending(k => k.Key))
                            {
                                Console.WriteLine($"{kisi.Key}: {kisi.Value}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Hatalı seçim yaptınız.");
                        }
                        break;

                    case "5":
                        Console.WriteLine("Aramak istediğiniz kişinin adını giriniz:");
                        string arananAd = Console.ReadLine();

                        if (telefonRehberi.ContainsKey(arananAd))
                        {
                            Console.WriteLine($"{arananAd}: {telefonRehberi[arananAd]}");
                        }
                        else
                        {
                            Console.WriteLine($"{arananAd} adlı kişi rehberde kayıtlı değil.");
                        }
                        break;

                    case "6":
                        Console.WriteLine("Programdan çıkılıyor...");
                        return;

                    default:
                        Console.WriteLine("Hatalı seçim yaptınız. Lütfen tekrar deneyiniz.");
                        break;
                }
                Console.WriteLine("Devam etmek için herhangi bir tuşa basınız...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}







