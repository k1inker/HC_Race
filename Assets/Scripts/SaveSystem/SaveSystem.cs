using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveSystem
{
    private static string _pathScore = Application.persistentDataPath + "/score.hc";
    public static void SaveScore(int score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(_pathScore, FileMode.Create))
        {
            formatter.Serialize(stream, score);
        }
    }
    public static int LoadScore()
    {
        int data = 0;
        if (File.Exists(_pathScore))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(_pathScore, FileMode.Open);

            data = (int)formatter.Deserialize(stream);
            stream.Close();
        }
        // if this is first opening
        else
        { 
            SaveScore(data);
        }
        return data;
    }
}
