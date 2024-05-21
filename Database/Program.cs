using System;
using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections;

public class Program
{
    public static async Task Main(string[] args)
    {
        string DbPath = "blogging.db";

        Console.WriteLine($"Database path: {DbPath}.");
        var db = new SQLiteAsyncConnection(DbPath);

        // Membuat tabel jika belum ada
        await db.CreateTableAsync<Biodata>();

        await db.CreateTableAsync<SidikJari>();

        // Menambahkan contoh data jika belum ada data dalam tabel
        if (await db.Table<Biodata>().CountAsync() == 0)
        {
            List<Biodata> biodataList = new List<Biodata>();
            biodataList.Add(new Biodata
            {
                NIK = 1234567890,
                Nama = "John Doe",
                TempatLahir = "Jakarta",
                TanggalLahir = new DateTime(1990, 1, 1),
                JenisKelamin = "LakiLaki",
                GolonganDarah = "O",
                Alamat = "Jl. Merdeka No.1",
                Agama = "Islam",
                StatusPerkawinan = "Menikah",
                Pekerjaan = "Pegawai Negeri",
                Kewarganegaraan = "Indonesia"
            });

            biodataList.Add(new Biodata
            {
                NIK = 1234567891,
                Nama = "Jack Daniels",
                TempatLahir = "Surabaya",
                TanggalLahir = new DateTime(1988, 3, 15),
                JenisKelamin = "LakiLaki",
                GolonganDarah = "B",
                Alamat = "Jl. Diponegoro No. 10",
                Agama = "Katolik",
                StatusPerkawinan = "Cerai",
                Pekerjaan = "Wiraswasta",
                Kewarganegaraan = "Indonesia"
            });

            biodataList.Add( new Biodata
            {
                NIK = 1234567892,
                Nama = "Andi Soraya",
                TempatLahir = "Semarang",
                TanggalLahir = new DateTime(1992, 5, 20),
                JenisKelamin = "Perempuan",
                GolonganDarah = "AB",
                Alamat = "Jl. Asia Afrika No. 5",
                Agama = "Kristen",
                StatusPerkawinan = "BelumMenikah",
                Pekerjaan = "Mahasiswa",
                Kewarganegaraan = "Indonesia"
            });

            biodataList.Add(new Biodata
            {
                NIK = 1234567893,
                Nama = "Rudi",
                TempatLahir = "Bali",
                TanggalLahir = new DateTime(1995, 7, 10),
                JenisKelamin = "LakiLaki",
                GolonganDarah = "A",
                Alamat = "Jl. Pahlawan No. 3",
                Agama = "Hindu",
                StatusPerkawinan = "BelumMenikah",
                Pekerjaan = "Pegawai Swasta",
                Kewarganegaraan = "Indonesia"
            });

            biodataList.Add(new Biodata
            {
                NIK = 1234567894,
                Nama = "Siti",
                TempatLahir = "Bandung",
                TanggalLahir = new DateTime(1993, 9, 25),
                JenisKelamin = "Perempuan",
                GolonganDarah = "O",
                Alamat = "Jl. Asia Afrika No. 10",
                Agama = "Islam",
                StatusPerkawinan = "BelumMenikah",
                Pekerjaan = "Pegawai Negeri",
                Kewarganegaraan = "Indonesia"
            });

            biodataList.Add(new Biodata
            {
                NIK = 1234567895,
                Nama = "Budi",
                TempatLahir = "Yogyakarta",
                TanggalLahir = new DateTime(1991, 11, 30),
                JenisKelamin = "LakiLaki",
                GolonganDarah = "B",
                Alamat = "Jl. Pemuda No. 1",
                Agama = "Islam",
                StatusPerkawinan = "BelumMenikah",
                Pekerjaan = "Wiraswasta",
                Kewarganegaraan = "Indonesia"
            });

            biodataList.Add(new Biodata
            {
                NIK = 1234567896,
                Nama = "Rina",
                TempatLahir = "Medan",
                TanggalLahir = new DateTime(1994, 12, 5),
                JenisKelamin = "Perempuan",
                GolonganDarah = "AB",
                Alamat = "Jl. Merdeka No. 10",
                Agama = "Kristen",
                StatusPerkawinan = "BelumMenikah",
                Pekerjaan = "Mahasiswa",
                Kewarganegaraan = "Indonesia"
            });

            biodataList.Add(new Biodata
            {
                NIK = 1234567897,
                Nama = "Roni",
                TempatLahir = "Makassar",
                TanggalLahir = new DateTime(1996, 2, 10),
                JenisKelamin = "LakiLaki",
                GolonganDarah = "A",
                Alamat = "Jl. Diponegoro No. 5",
                Agama = "Islam",
                StatusPerkawinan = "BelumMenikah",
                Pekerjaan = "Pegawai Swasta",
                Kewarganegaraan = "Indonesia"
            });

            biodataList.Add(new Biodata
            {
                NIK = 1234567898,
                Nama = "Zaidan",
                TempatLahir = "Semarang",
                TanggalLahir = new DateTime(2003, 12, 5),
                JenisKelamin = "LakiLaki",
                GolonganDarah = "AB",
                Alamat = "Jl. Merdeka No. 10",
                Agama = "Kristen",
                StatusPerkawinan = "BelumMenikah",
                Pekerjaan = "Ustadz",
                Kewarganegaraan = "Indonesia"
            });

            biodataList.Add(new Biodata
            {
                NIK = 1234567899,
                Nama = "Layla",
                TempatLahir = "Jakarta",
                TanggalLahir = new DateTime(2004, 2, 10),
                JenisKelamin = "Perempuan",
                GolonganDarah = "A",
                Alamat = "Jl. Diponegoro No. 5",
                Agama = "Islam",
                StatusPerkawinan = "BelumMenikah",
                Pekerjaan = "Penghibur",
                Kewarganegaraan = "Indonesia"
            });

            biodataList.Add(new Biodata
            {
                NIK = 1234567900,
                Nama = "Rizky",
                TempatLahir = "Makassar",
                TanggalLahir = new DateTime(2005, 2, 10),
                JenisKelamin = "LakiLaki",
                GolonganDarah = "A",
                Alamat = "Jl. Diponegoro No. 5",
                Agama = "Islam",
                StatusPerkawinan = "BelumMenikah",
                Pekerjaan = "Pegawai Swasta",
                Kewarganegaraan = "Indonesia"
            });
            
            biodataList.Add(new Biodata
            {
                NIK = 1234567901,
                Nama = "Rizal",
                TempatLahir = "Palembang",
                TanggalLahir = new DateTime(1996, 2, 10),
                JenisKelamin = "LakiLaki",
                GolonganDarah = "A",
                Alamat = "Jl. Diponegoro No. 5",
                Agama = "Kristen",
                StatusPerkawinan = "BelumMenikah",
                Pekerjaan = "Pegawai Swasta",
                Kewarganegaraan = "Indonesia"
            });

            biodataList.Add(new Biodata
            {
                NIK = 1234567902,
                Nama = "Farhan",
                TempatLahir = "Yogyakarta",
                TanggalLahir = new DateTime(2003, 2, 10),
                JenisKelamin = "LakiLaki",
                GolonganDarah = "O",
                Alamat = "Jl. Borobudur No. 5",
                Agama = "Islam",
                StatusPerkawinan = "Menikah",
                Pekerjaan = "Programmer",
                Kewarganegaraan = "Indonesia"
            });

            biodataList.Add(new Biodata
            {
                NIK = 1234567903,
                Nama = "Axel Santadi Warih",
                TempatLahir = "Jakarta",
                TanggalLahir = new DateTime(1945, 8, 8),
                JenisKelamin = "LakiLaki",
                GolonganDarah = "A",
                Alamat = "Jl. Bulungan No. 12",
                Agama = "Islam",
                StatusPerkawinan = "BelumMenikah",
                Pekerjaan = "Tukang Ojek Online",
                Kewarganegaraan = "Indonesia"
            });

            biodataList.Add(new Biodata
            {
                NIK = 1234567904,
                Nama = "Muneki",
                TempatLahir = "Tokyo",
                TanggalLahir = new DateTime(2005, 2, 10),
                JenisKelamin = "LakiLaki",
                GolonganDarah = "A",
                Alamat = "Jl. Gojosatoru No. 5",
                Agama = "Kristen",
                StatusPerkawinan = "Menikah",
                Pekerjaan = "Animator",
                Kewarganegaraan = "Jepang"
            });

            biodataList.Add(new Biodata
            {
                NIK = 1234567905,
                Nama = "Roni",
                TempatLahir = "Makassar",
                TanggalLahir = new DateTime(1996, 2, 10),
                JenisKelamin = "LakiLaki",
                GolonganDarah = "A",
                Alamat = "Jl. Diponegoro No. 5",
                Agama = "Hindu",
                StatusPerkawinan = "BelumMenikah",
                Pekerjaan = "Pegawai Swasta",
                Kewarganegaraan = "Indonesia"
            });
            

            await db.InsertAllAsync(biodataList);
        }

        if (await db.Table<SidikJari>().CountAsync() == 0)
        {
            List<SidikJari> sidikJariList = new List<SidikJari>();
            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_1",
                nama = "John Doe"
            });

            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_2",
                nama = "Jack Daniels"
            });

            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_3",
                nama = "Andi Soraya"
            });

            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_4",
                nama = "Rudi"
            });

            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_5",
                nama = "Siti"
            });

            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_6",
                nama = "Budi"
            });

            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_7",
                nama = "Rina"
            });

            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_8",
                nama = "Roni"
            });

            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_9",
                nama = "Zaidan"
            });

            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_10",
                nama = "Layla"
            });

            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_11",
                nama = "Rizky"
            });

            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_12",
                nama = "Rizal"
            });
            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_13",
                nama = "Farhan"
            });
            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_14",
                nama = "Axel Santadi Warih"
            });
            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_15",
                nama = "Muneki"
            });
            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_16",
                nama = "Roni"
            });
            sidikJariList.Add(new SidikJari
            {
                berkas_citra = "berkas_citra_17",
                nama = "Roni"
            });
            await db.InsertAllAsync(sidikJariList);
        }

        // Membaca dan menampilkan data
        Console.WriteLine("Querying for biodata");

        var results = await db.Table<Biodata>().ToListAsync();
        var sidikJariResults = await db.Table<SidikJari>().ToListAsync();
        foreach (var s in results)
        {
            Console.WriteLine($"NIK: {s.NIK}, Nama: {s.Nama}, Alamat: {s.Alamat}, Agama: {s.Agama}, Status Perkawinan: {s.StatusPerkawinan}, Pekerjaan: {s.Pekerjaan}, Kewarganegaraan: {s.Kewarganegaraan}, Jenis Kelamin: {s.JenisKelamin}, Golongan Darah: {s.GolonganDarah}");
        }
        foreach (var s in sidikJariResults)
        {
            Console.WriteLine($"Berkas Citra: {s.berkas_citra}, Nama: {s.nama}");
        }


    }
}
