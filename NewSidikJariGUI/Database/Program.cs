using System;
using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;


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

        var fakerBiodata = new Faker<Biodata>()
            .RuleFor(b => b.NIK, (f, b) => int.Parse(f.Random.ReplaceNumbers("#########")) * 1000)
            .RuleFor(b => b.Nama, f => Biodata.NormalizeNama(f.Name.FullName()))
            .RuleFor(b => b.TempatLahir, f => f.Address.City())
            .RuleFor(b => b.TanggalLahir, f => f.Date.Past(30, DateTime.Now.AddYears(-18)))
            .RuleFor(b => b.JenisKelamin, f => f.PickRandom<JenisKelamin>())
            .RuleFor(b => b.GolonganDarah, f => f.PickRandom(new[] { "A", "B", "AB", "O" }))
            .RuleFor(b => b.Alamat, f => f.Address.FullAddress())
            .RuleFor(b => b.Agama, f => f.PickRandom(new[] { "Islam", "Kristen", "Katolik", "Hindu", "Buddha", "Konghucu" }))
            .RuleFor(b => b.StatusPerkawinan, f => f.PickRandom<StatusPerkawinan>())
            .RuleFor(b => b.Pekerjaan, f => f.Name.JobTitle())
            .RuleFor(b => b.Kewarganegaraan, f => "Indonesia");

        // Get all fingerprint files
        var files = Directory.GetFiles(fingerprintDirectory, "*.BMP");
        var groupedFiles = files.GroupBy(f => Path.GetFileNameWithoutExtension(f).Split('_')[0]);

        int counter = 1;
        foreach (var group in groupedFiles)
        {
            int nikSuffix = counter % 600 + 1;
            int nik = (fakerBiodata.Generate().NIK / 1000) * 1000 + nikSuffix;
            counter++;

            // Check if biodata exists for this NIK
            var biodata = db.Find<Biodata>(nik);
            if (biodata == null)
            {
                biodata = fakerBiodata.Generate();
                biodata.NIK = nik;
                db.Insert(biodata);
            }

            foreach (var filePath in group)
            {
                var sidikJari = new SidikJari
                {
                    BerkasCitra = filePath,
                    Nama = biodata.Nama
                };
                db.Insert(sidikJari);
            }
        }

        // Query and display the data
        Console.WriteLine("Querying for biodata");

        var results = db.Table<Biodata>().ToList();
        var sidikJariResults = db.Table<SidikJari>().ToList();

        // Membaca dan menampilkan data
        
        // foreach (var s in results)
        // {
        //     Console.WriteLine($"NIK: {s.NIK}, Nama: {s.Nama}, Alamat: {s.Alamat}, Agama: {s.Agama}, Status Perkawinan: {s.StatusPerkawinan}, Pekerjaan: {s.Pekerjaan}, Kewarganegaraan: {s.Kewarganegaraan}, Jenis Kelamin: {s.JenisKelamin}, Golongan Darah: {s.GolonganDarah}");
        // }
        // foreach (var s in sidikJariResults)
        // {
        //     Console.WriteLine($"Berkas Citra: {s.BerkasCitra}, Nama: {s.Nama}");
        // }
        var databaseService = new FingerprintService(db);

        var berkasCitraList = databaseService.GetAllBerkasCitra();

        for (int i = 0; i < berkasCitraList.Count; i++) {
            var berkasCitra = berkasCitraList[i];
            var berkas = berkasCitra.BerkasCitra;
            var nama = berkasCitra.Nama;
            Console.WriteLine($"Nama: {nama}, Berkas: {berkas}");
        }
        db.Close();
    }
}
