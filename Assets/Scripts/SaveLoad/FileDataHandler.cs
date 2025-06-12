using System;
using System.IO;
using UnityEngine;
// used to serialize data to file
public class FileDataHandler : MonoBehaviour
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath, string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        try
        {
            string dataToStore = JsonUtility.ToJson(data, true);
            using (FileStream fs = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.Write(dataToStore);
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadData = new GameData();
        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";
                using (FileStream fs = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        dataToLoad = sr.ReadToEnd();
                    }
                }
                loadData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        return loadData;
    }

    public void Delete()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
        }
    }
}
