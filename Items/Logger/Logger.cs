using System;
using System.IO;

public static class Logger
{
    // Log dosyasına yazma işlemi
    public static void LogYaz(string mesaj)
    {
        string logFilePath = @"Log.txt";  // Varsayılan olarak kök dizinde bir Log.txt dosyasına yazılır

        try
        {
            // Log dosyasına yazmak için StreamWriter kullanıyoruz
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {mesaj}");
            }
        }
        catch (Exception ex)
        {
            // Eğer log dosyasına yazılamazsa, hata mesajı konsola yazdırılır
            Console.WriteLine("Log dosyasına yazılamadı: " + ex.Message);
        }
    }
}
