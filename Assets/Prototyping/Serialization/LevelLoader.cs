using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{ 
    [SerializeField] DataPersistenceManager dataPersistenceManager;
    [SerializeField] string LevelFilePath;
    [SerializeField] LevelObjectDB levelObjectDB;

    // Start is called before the first frame update
    void Start()
    {
        dataPersistenceManager = DataPersistenceManager.instance;
        GenerateLevel(dataPersistenceManager.LoadLevelData(LevelFilePath));
    }


    public void GenerateLevel(LevelData data)
    {
        foreach (LevelObject obj in data.levelObjects)
        {
            GameObject go = Instantiate(levelObjectDB.GetLevelObject(obj.name));
            go.transform.position = new Vector3(obj.x, obj.y, obj.z);
        }


    }
}
