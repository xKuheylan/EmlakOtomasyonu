using System;
using System.IO;

namespace ClassLibraryEmlakOdev
{
    public enum EvTuru
    {
        Daire,
        Bahçeli,
        Dubleks,
        Müstakil
    }

    public class Ev
    {
        // Alanlar
        private int _odaSayisi;
        private int _katNumarasi;
        private string _semt;
        private double _alani;
        private DateTime _yapimTarihi;
        private EvTuru _turu;
        private bool _aktif;
        private string _emlakNumarasi;

        // Kurucu Metotlar
        public Ev(int odaSayisi, int katNumarasi, string semt, double alani, DateTime yapimTarihi, EvTuru turu)
        {
            OdaSayisi = odaSayisi;
            KatNumarasi = katNumarasi;
            Semti = semt ?? "Bilinmeyen";  // Semt, null ise "Bilinmeyen" olarak atanır
            Alani = alani;
            YapimTarihi = yapimTarihi;
            EmlakNumarasi = Guid.NewGuid().ToString();  // Emlak numarası, her seferinde benzersiz bir GUID atanır
        }

        // Kiralık evler için
        public double Depozito { get; set; }
        public double Kira { get; set; }

        // Satılık evler için
        public double Fiyat { get; set; }

        // Özellikler
        public int OdaSayisi
        {
            get { return _odaSayisi; }
            set
            {
                if (value < 0)
                {
                    _odaSayisi = 0;  // Negatif değer atandığında oda sayısı sıfırlanır
                    LogNegatifDeger("OdaSayisi", value);  // Negatif değer loglanır
                }
                else
                {
                    _odaSayisi = value;  // Geçerli değer atanır
                    LogPozitifDeger("OdaSayisi", value);  // Pozitif değer loglanır
                }
            }
        }

        public int KatNumarasi
        {
            get { return _katNumarasi; }
            set
            {
                if (value < 0)
                {
                    _katNumarasi = 0;
                    LogNegatifDeger("KatNumarasi", value);
                }
                else
                {
                    _katNumarasi = value;
                    LogPozitifDeger("KatNumarasi", value);
                }
            }
        }

        public string Semti
        {
            get { return _semt; }
            set { _semt = value; }
        }

        public double Alani
        {
            get { return _alani; }
            set
            {
                if (value < 0)
                {
                    _alani = 0;
                    LogNegatifDeger("Alani", value);
                }
                else
                {
                    _alani = value;
                    LogPozitifDeger("Alani", value);
                }
            }
        }

        public DateTime YapimTarihi
        {
            get { return _yapimTarihi; }
            set { _yapimTarihi = value; }
        }

        public EvTuru Turu
        {
            get { return _turu; }
            set { _turu = value; }
        }

        public bool Aktif
        {
            get { return _aktif; }
            set { _aktif = value; }
        }

        public string EmlakNumarasi
        {
            get { return _emlakNumarasi; }
            set { _emlakNumarasi = value; }
        }

        // Yas Özelliği
        public int Yas
        {
            get { return DateTime.Now.Year - _yapimTarihi.Year; }
        }

        
        // Ev sınıfındaki EvBilgileri metodunu virtual olarak işaretliyoruz
        public virtual string EvBilgileri()
        {
            return string.Format(
                "Emlak No: {0}\nOda Sayısı: {1}\nSemt: {2}\nAlan: {3} m²\nYapım Tarihi: {4}\nAktif: {5}",
                EmlakNumarasi, OdaSayisi, Semti, Alani, YapimTarihi.Year, Aktif ? "Evet" : "Hayır");
        }



        // Fiyat Hesaplama (kira fiyatı)
        public double FiyatHesapla()
        {
            double katsayi = 200; // Varsayılan katsayı

            try
            {
                // room_cost.txt dosyasını oku
                var lines = File.ReadAllLines("room_cost.txt");

                if (lines.Length > 0)
                {
                    katsayi = Convert.ToDouble(lines[0]);
                    LogPozitifDeger("Katsayi", katsayi);  // Log dosyasına yazılacak
                }
                else
                {
                    // Dosya boşsa varsayılan katsayıyı kullan
                    LogNegatifDeger("Katsayi", katsayi);
                }
            }
            catch (Exception ex)
            {
                // Dosya yoksa ya da bir hata oluşursa varsayılan katsayı kullanılır
                LogNegatifDeger("Katsayi", katsayi);  // Hata logunu yaz
                File.AppendAllText("log.txt", $"{DateTime.Now} - Hata oluştu: {ex.Message}\n");
                Console.WriteLine($"Hata oluştu: {ex.Message}");  // Hata mesajını konsola yaz
            }

            // Fiyat hesapla: Oda sayısı * katsayı
            double fiyat = OdaSayisi * katsayi;
            return fiyat;
        }



        // int türü için loglama
        protected void LogNegatifDeger(string alan, int deger)
        {
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine($"{DateTime.Now} - Negatif değer girildi: {alan} = {deger}");
            }
        }

        protected void LogPozitifDeger(string alan, int deger)
        {
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine($"{DateTime.Now} - Pozitif değer girildi: {alan} = {deger}");
            }
        }

        protected void LogNegatifDeger(string alan, double deger)
        {
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine($"{DateTime.Now} - Negatif değer girildi: {alan} = {deger}");
            }
        }

        protected void LogPozitifDeger(string alan, double deger)
        {
            using (StreamWriter writer = new StreamWriter("log.txt", true))
            {
                writer.WriteLine($"{DateTime.Now} - Pozitif değer girildi: {alan} = {deger}");
            }
        }

    }
}
