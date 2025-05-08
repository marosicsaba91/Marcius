using System.IO;
using UnityEngine;

public static class ObjectSaver
{
    // Tetszőleges objektum mentése fájlba
    public static void SaveToFile(string filePath, object data)
    {
        // Elérési útvonal létrehozása
        string path = FullPath(filePath);

        // Adat szerializálás JSON stringbe
        string json = JsonUtility.ToJson(data);

        // JSON string írása fájlba
        File.WriteAllText(path, json);
    }

    // Lekérdezés: Létezik az adott mentési fájl?
    public static bool HaveFileToLoad(string filePath)
    {
        string path = FullPath(filePath);
        return File.Exists(path);
    }

    // Mentett fájl betöltésse: Visszaalakítás C# objektummá:  Deszerializáció
    public static T LoadFromFile<T>(string filePath)
    {
        // Elérési útvonal létrehozása
        string path = FullPath(filePath);

        // ha a file nem létezik,
        if (!File.Exists(path))
        {
            // akkor a generikus típus alapértelmezett értékével térünk vissza:
            return default;
        }

        // A file beolvasásam JSON string-be
        string json = File.ReadAllText(path);

        // Deszerializálás és visszatérés az adattal
        return JsonUtility.FromJson<T>(json);
    }

    // Adott mentési fájl törlése
    public static void DeleteFile(string filePath)
    {
        string path = FullPath(filePath);
        File.Delete(path);
    }

    // Az összes mentett fájl tölése
    public static void DeleteSaveDirectory()
    {
        DirectoryInfo dir = new DirectoryInfo(Application.persistentDataPath);
        // Minden File törlése
        foreach (FileInfo file in dir.GetFiles())
        {
            file.Delete();
        }
        // Minden mappa törlése
        foreach (DirectoryInfo innerDir in dir.GetDirectories())
        {
            innerDir.Delete(true);
        }
    }


    // Elérési útvonal
    static string FullPath(string filePath)
    {
        return Path.Combine(Application.persistentDataPath, filePath + ".json");
    }
}