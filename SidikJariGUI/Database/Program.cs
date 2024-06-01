using System;
using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class Program
{
    public static async Task Main(string[] args)
    {
        string DbPath = "blogging.db";

        Console.WriteLine($"Database path: {DbPath}.");
        var db = new SQLiteConnection(DbPath);
        
        // Create tables if they don't exist
        db.CreateTable<Biodata>();
        db.CreateTable<SidikJari>();

        string fingerprintDirectory = @"assets";
        
        foreach (var filePath in Directory.GetFiles(fingerprintDirectory, "*.BMP"))
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);

            // Assuming fileName follows the format "NIK_Nama.jpg"
            var parts = fileName.Split('_');
            if (parts.Length < 2) continue;

            int nik;
            if (!int.TryParse(parts[0], out nik)) continue;

            string nama = parts[1] + nik.ToString();

            // Insert or update the biodata record if it doesn't exist
            var biodata = db.Find<Biodata>(nik);
            if (biodata == null)
            {
                biodata = new Biodata
                {
                    NIK = nik,
                    Nama = nama,
                    TempatLahir = null,
                    TanggalLahir = null,
                    JenisKelamin = null,
                    GolonganDarah = null,
                    Alamat = null,
                    Agama = null,
                    StatusPerkawinan = null,
                    Pekerjaan = null,
                    Kewarganegaraan = null
                };
                try
                {
                    db.Insert(biodata);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Failed to insert biodata: {e}");
                }
            }

            // Insert the fingerprint record
            var sidikJari = new SidikJari
            {
                BerkasCitra = filePath,
                Nama = nama,
            };
            db.Insert(sidikJari);
        }

        // Membaca dan menampilkan data
        Console.WriteLine("Querying for biodata");
        
        var results = db.Table<Biodata>().ToList();
        var sidikJariResults = db.Table<SidikJari>().ToList();
        // foreach (var s in results)
        // {
        //     Console.WriteLine($"NIK: {s.NIK}, Nama: {s.Nama}, Alamat: {s.Alamat}, Agama: {s.Agama}, Status Perkawinan: {s.StatusPerkawinan}, Pekerjaan: {s.Pekerjaan}, Kewarganegaraan: {s.Kewarganegaraan}, Jenis Kelamin: {s.JenisKelamin}, Golongan Darah: {s.GolonganDarah}");
        // }
        // foreach (var s in sidikJariResults)
        // {
        //     Console.WriteLine($"Berkas Citra: {s.BerkasCitra}, Nama: {s.Nama}");
        // }
        var databaseService = new FingerprintService(db);

        string targetNama = "99";
        var biodatas = databaseService.GetBiodataByNama(targetNama);
        foreach (var biodata in biodatas)
        {
            Console.WriteLine(biodata.NIK);
            Console.WriteLine(biodata.Nama);
            Console.WriteLine(biodata.TempatLahir);
            Console.WriteLine(biodata.TanggalLahir);
            Console.WriteLine(biodata.JenisKelamin);
            Console.WriteLine(biodata.GolonganDarah);
            Console.WriteLine(biodata.Alamat);
            Console.WriteLine(biodata.Agama);
            Console.WriteLine(biodata.StatusPerkawinan);
            Console.WriteLine(biodata.Pekerjaan);
            Console.WriteLine(biodata.Kewarganegaraan);
        }

        var berkasCitraList = databaseService.GetAllBerkasCitra();
        foreach (var berkasCitra in berkasCitraList)
        {
            Console.WriteLine(berkasCitra.BerkasCitra);
        }

        db.Close();
    }
}
