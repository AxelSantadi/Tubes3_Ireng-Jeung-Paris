// See https://aka.ms/new-console-template for more information

using StimaAlgorithm;

string key = "ABABAABA";
string reference = "ABCABAB ABABABAABAC";

int x = StimaAlgorithm.KMPAlgorithm.Find(key,reference);

string result = $"found at {x}";

Console.WriteLine(result);
