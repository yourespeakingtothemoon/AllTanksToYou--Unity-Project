using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour
{
   public static DataPersistenceManager instance { get; private set; }

   private void Awake()
   {
       if (instance != null)
       {
           Debug.LogError("Multiple instances of DataPersistenceManager found!");
       }
      instance = this;
   }

   public void SaveLevelData(LevelData data)
   {
        //data.levelVersion += 0.1f;
       string json = JsonUtility.ToJson(data);
       string filePath = Application.dataPath + SerializationUtils.MakeUniqueFileName(data.levelName) + ".json";

       System.IO.File.WriteAllText(Application.dataPath + "/levelData.json", json);
   }

    public LevelData LoadLevelData(string fileName)
    {
        string json = System.IO.File.ReadAllText(Application.dataPath + fileName);
        LevelData data = JsonUtility.FromJson<LevelData>(json);
        return data;
    }
}
