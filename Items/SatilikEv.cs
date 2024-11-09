using System;

namespace ClassLibraryEmlakOdev
{
    public class SatilikEv : Ev
    {
        // Yapıcı metot (EvTuru.Daire varsayılan olarak belirtilmiş)
        public SatilikEv(int odaSayisi, int katNumarasi, string semt, double alani, DateTime yapimTarihi, EvTuru turu = EvTuru.Daire)
            : base(odaSayisi, katNumarasi, semt, alani, yapimTarihi, turu)
        {
        }

        // EvBilgileri metodunun override edilmesi
        public override string EvBilgileri()
        {
            return string.Format(
                "Emlak No: {0}\nOda Sayısı: {1}\nSemt: {2}\nAlan: {3} m²\nYapım Tarihi: {4}\nAktif: {5}\nFiyat: {6} TL",
                EmlakNumarasi, OdaSayisi, Semti, Alani, YapimTarihi.Year, Aktif ? "Evet" : "Hayır", Fiyat);
        }

        // Satılık ev için fiyat hesaplama eklemek isterseniz:
        public new double FiyatHesapla()  // 'new' anahtar kelimesi ekleniyor
        {
            double katsayi = 500; // Örnek katsayı
            return OdaSayisi * katsayi;
        }

    }
}
