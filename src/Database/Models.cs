using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using SQLite;

public enum JenisKelamin
{
    LakiLaki,
    Perempuan
}

public enum StatusPerkawinan
{
    BelumMenikah,
    Menikah,
    Cerai
}

[Table("Biodata")]
public class Biodata
{
    [PrimaryKey, MaxLength(16)]
    public string NIK { get; set; }

    [MaxLength(100), DefaultValue(null)]
    public string Nama { get; set; }

    [MaxLength(50), DefaultValue(null)]
    public string TempatLahir { get; set; }

    [DefaultValue(null)]
    public DateTime? TanggalLahir { get; set; }

    [DefaultValue(null)]
    public JenisKelamin? JenisKelamin { get; set; }

    [MaxLength(5), DefaultValue(null)]
    public string GolonganDarah { get; set; }

    [MaxLength(255), DefaultValue(null)]
    public string Alamat { get; set; }

    [MaxLength(50), DefaultValue(null)]
    public string Agama { get; set; }

    [DefaultValue(null)]
    public StatusPerkawinan? StatusPerkawinan { get; set; }

    [MaxLength(100), DefaultValue(null)]
    public string Pekerjaan { get; set; }

    [MaxLength(50), DefaultValue(null)]
    public string Kewarganegaraan { get; set; }

    public static string NormalizeNama(string nama)
    {
        if (string.IsNullOrEmpty(nama))
            return nama;

        // Remove numbers
        nama = Regex.Replace(nama, @"\d", "");

        // Remove excessive spaces
        nama = Regex.Replace(nama, @"\s+", " ").Trim();

        // Convert to title case
        nama = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nama.ToLower());

        return nama;
    }

    public static bool IsNamaCorrupt(string nama)
    {
        // Check for presence of numbers or non-standard capitalization
        if (string.IsNullOrEmpty(nama))
            return false;
        return Regex.IsMatch(nama, @"\d") || (Regex.IsMatch(nama, @"[A-Z]") && Regex.IsMatch(nama, @"[a-z]"));
    }
}

[Table("SidikJari")]
public class SidikJari
{
    [PrimaryKey]
    public string BerkasCitra { get; set; }

    [MaxLength(255), DefaultValue(null)]
    public string Nama { get; set; }

    // Methods to handle potential corrupt Nama in SidikJari
    public static string NormalizeNama(string nama)
    {
        return Biodata.NormalizeNama(nama);
    }

    public static bool IsNamaCorrupt(string nama)
    {
        return Biodata.IsNamaCorrupt(nama);
    }

    public static string GenerateAlayName(string originalName)
    {
        var random = new Random();
        int choice = random.Next(5);

        switch (choice)
        {
            case 0:
                // Kombinasi huruf besar-kecil
                return new string(originalName.Select((c, i) => i % 2 == 0 ? char.ToLower(c) : char.ToUpper(c)).ToArray());
            case 1:
                // Penggunaan angka
                return originalName.Replace('a', '4').Replace('i', '1').Replace('e', '3').Replace('o', '0').Replace('t', '7');
             case 2:
                // Penyingkatan (Menghilangkan huruf vokal kecuali sebagai huruf awal kata, maksimal 2 per kata)
                return string.Join(" ", originalName.Split(' ').Select(word =>
                {
                    if (word.Length > 1)
                    {
                        int count = 0;
                        return word[0] + new string(word.Skip(1).Where(c => !"aiueoAIUEO".Contains(c) || count++ < 2).ToArray());
                    }
                    return word;
                }));
            case 3:
                // Kombinasi ketiganya
                var shortName = string.Join(" ", originalName.Split(' ').Select(word =>
                {
                    if (word.Length > 1)
                    {
                        int count = 0;
                        return word[0] + new string(word.Skip(1).Where(c => !"aiueoAIUEO".Contains(c) || count++ < 2).ToArray());
                    }
                    return word;
                }));

                var withNumbers = shortName.Replace('a', '4').Replace('i', '1').Replace('e', '3').Replace('o', '0').Replace('t', '7');

                return new string(withNumbers.Select((c, i) => i % 2 == 0 ? char.ToLower(c) : char.ToUpper(c)).ToArray());
            default:
                // Kata orisinil
                return originalName;
        }
    }
}
