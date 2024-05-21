using System;
using System.ComponentModel;
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
    [PrimaryKey]
    public int NIK { get; set; }
    [MaxLength(100), DefaultValue(null)]
    public string Nama { get; set; }
    [MaxLength(50),DefaultValue(null)]
    public string TempatLahir { get; set; }
    [DefaultValue(null)]
    public DateTime? TanggalLahir { get; set; }
    // enum jenis kelamin (Laki-Laki, Perempuan)
    [Ignore, DefaultValue(null)]
    public string JenisKelamin { get; set; }
    [MaxLength(5), DefaultValue(null)]
    public string GolonganDarah { get; set; }
    [MaxLength(255), DefaultValue(null)]
    public string Alamat { get; set; }
    [MaxLength(50), DefaultValue(null)]
    public string Agama { get; set; }
    [Ignore,DefaultValue(null)]
    public string StatusPerkawinan { get; set; }
    [MaxLength(100), DefaultValue(null)]
    public string Pekerjaan { get; set; }
    [MaxLength(50), DefaultValue(null)]
    public string Kewarganegaraan { get; set; }
}

public class SidikJari
{
    [PrimaryKey]
    public string berkas_citra { get; set; }
    [MaxLength(255), DefaultValue(null)]
    public string nama { get; set; }
}