using System;
using System.Text.RegularExpressions;
using Algorithm;
using SQLite;

namespace Database
{
public class Regex
{

    public static List<string> getAllNama() {
        string query = $"SELECT nama FROM Biodata";
        var namaList = FingerprintService.GetConnection().Query<Biodata>(query);

        List<string> result = new List<string>();
        foreach (Biodata item in namaList)
        {
            result.Add(item.Nama);
        };

        return result;
    }

    public static string FindClosestMatch(string alayName)
    {
        List<string> databaseNames = getAllNama();
        // Konversi alayName ke bentuk yang lebih normal
        string normalizedInput = NormalizeAlayName(alayName);

        string closestMatch = null;
        int minDistance = int.MaxValue;

        foreach (var dbName in databaseNames)
        {
            string normalizedDbName = NormalizeAlayName(dbName);
            int distance = Algorithm.levenshtein.LevenshteinDistance(normalizedInput, normalizedDbName);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestMatch = dbName;
            }
        }

        return closestMatch;
    }

    static string NormalizeAlayName(string alayName)
    {
        string patternNumbersToLetters = "1|4|6|0|3|7|5";
        alayName = System.Text.RegularExpressions.Regex.Replace(alayName, patternNumbersToLetters, match =>
        {
            switch (match.Value)
            {
                case "1": return "i";
                case "4": return "a";
                case "6": return "g";
                case "0": return "o";
                case "3": return "e";
                case "7": return "t";
                case "5": return "s";
                case "2": return "z";
                default: return match.Value;
            }
        }, RegexOptions.IgnoreCase);

        // Mengubah huruf besar ke kecil
        alayName = alayName.ToLower();

        // mengubah huruf pertama dari setiap kata di alayname menjadi huruf besar
        alayName = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(alayName);

        return alayName;
    }
}
}