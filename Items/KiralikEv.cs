using System;

namespace ClassLibraryEmlakOdev
{
    public class KiralikEv : Ev
    {
        // KiralıkEv için özel yapıcı metot (varsayılan EvTuru.Daire)
        public KiralikEv(int odaSayisi, int katNumarasi, string semt, double alani, DateTime yapimTarihi, EvTuru turu = EvTuru.Daire)
            : base(odaSayisi, katNumarasi, semt, alani, yapimTarihi, turu) // Tür dinamik olarak geçilebilir
        {
        }

        // EvBilgileri metodunun override edilmesi
        public override string EvBilgileri()
        {
            return string.Format(
                "Emlak No: {0}\nOda Sayısı: {1}\nSemt: {2}\nAlan: {3} m²\nYapım Tarihi: {4}\nAktif: {5}\nKira: {6} TL\nDepozito: {7} TL",
                EmlakNumarasi, OdaSayisi, Semti, Alani, YapimTarihi.Year, Aktif ? "Evet" : "Hayır", Kira, Depozito);
        }
    }
}
