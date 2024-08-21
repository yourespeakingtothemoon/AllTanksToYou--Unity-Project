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
    [SerializeField] public DataPersistenceManager dataPersistenceManager;
    public void SetSelectedObject(GameObject obj)
    {
        selectedObject = obj;
    }
    // Start is called before the first frame update
    void Start()
    {
        Transform buttonTransform = canvas.transform;
        //create button for each object in levelObjectDB
        foreach (LevelObjectLiteral obj in levelObjectDB.levelObjects)
        {
//instantiate each button without overlap

            Button button = Instantiate(buttonPrefab, canvas.transform);
            
            button.onClick.AddListener(() => SetSelectedObject(obj.prefab));
            button.GetComponentInChildren<Text>().text = obj.name;
            
        }
        //count the number of buttons
        int buttonCount = buttonTransform.childCount;
        //set buttons in a grid
        for (int i = 0; i < buttonCount; i++)
        {
            buttonTransform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -i * 30);
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
            levelData.AddObject(selectedObject.name, mousePos.x, mousePos.y, mousePos.z);
        }
        }
    }

    public void SaveLevel()
    {
        dataPersistenceManager.SaveLevelData(levelData);
    }

}
