using System;
using SQLite;

public class FingerprintService
{
    private readonly SQLiteConnection _connection;

    public FingerprintService(string dbPath)
    {
        try{
            _connection = new SQLiteConnection(dbPath);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public FingerprintService(SQLiteConnection connection)
    {
        _connection = connection;
    }

    public string GetNamaByBerkasCitra(string berkasCitra)
    {
        var query = $"SELECT Nama FROM SidikJari WHERE BerkasCitra = ?";
        var result = _connection.ExecuteScalar<string>(query, berkasCitra);
        
        return result;
    }
    
    public List<Biodata> GetBiodataByNama(string nama)
    {
        string query = $"SELECT * FROM Biodata WHERE Nama = ?";
        var biodatas = _connection.Query<Biodata>(query, nama);

        return biodatas;
    }
   
   public List<SidikJari> GetAllBerkasCitra()
    {
        string query = $"SELECT BerkasCitra FROM SidikJari";
        var berkasCitraList = _connection.Query<SidikJari>(query);

        return berkasCitraList;
    }

}