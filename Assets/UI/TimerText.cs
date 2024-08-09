using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerText : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI textTimer;
   

   public void UpdateTime(float time)
   {
    int minutes = Mathf.FloorToInt(time / 60f);
    int seconds = Mathf.FloorToInt(time - minutes * 60);
         textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
   }
}
