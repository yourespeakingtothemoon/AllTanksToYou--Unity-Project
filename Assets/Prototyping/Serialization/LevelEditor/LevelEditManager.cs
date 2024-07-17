using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEditManager : MonoBehaviour
{
    public LevelData levelData = new LevelData();
    [SerializeField]public LevelObjectDB levelObjectDB;

    public GameObject selectedObject;

    [SerializeField] public Button buttonPrefab;
    [SerializeField]public Canvas canvas;

    public void SetSelectedObject(GameObject obj)
    {
        selectedObject = obj;
    }
    // Start is called before the first frame update
    void Start()
    {
        //create button for each object in levelObjectDB
        foreach (LevelObjectLiteral obj in levelObjectDB.levelObjects)
        {

            Button button = Instantiate(buttonPrefab, canvas.transform);
            
            button.onClick.AddListener(() => SetSelectedObject(obj.prefab));
            button.GetComponentInChildren<Text>().text = obj.name;
            
        }
        
    }

    // spawn selected object at mouse click
    void Update()
    {
        if (selectedObject == null)
        {
            return;
        }
        else{
        if (Input.GetMouseButtonDown(0))
        {
          

           Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            
            mousePos.y = 0.5f;
            Instantiate(selectedObject, mousePos, Quaternion.identity);
            levelData.levelObjects.Add(new LevelObjectData(selectedObject.name, mousePos));
        }
        }
    }

}
