using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonView : MonoBehaviour, ISelectHandler, IDeselectHandler,IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image shadow;
    [SerializeField] Button button;

    Vector3 buttonPosition;

    void Start()
    {
        buttonPosition = button.GetComponent<RectTransform>().position;
    }

    

    public void OnSelect(BaseEventData eventData)
    {
        shadow.enabled = false;
        button.GetComponent<RectTransform>().position = new Vector3(buttonPosition.x, buttonPosition.y - 10, buttonPosition.z);
    }

    public void OnDeselect(BaseEventData eventData)
    {
        shadow.enabled = true;
        button.GetComponent<RectTransform>().position = buttonPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        shadow.enabled = false;
        button.GetComponent<RectTransform>().position = new Vector3(buttonPosition.x, buttonPosition.y - 10, buttonPosition.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        shadow.enabled = true;
        button.GetComponent<RectTransform>().position = buttonPosition;
    }
}



