using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class inGameCanvasManager : MonoBehaviour {
    public Text floorDisplay;


    public void setFloorDisplay()
    {
        floorDisplay.text = levelManager.Static.currentFloor+1 +" / " + (allLevelData.Static.allLevelDataList[levelManager.Static.currentLevelIndex].floorDetails.Count+1) ;
    }

    private void Update()
    {
        setFloorDisplay();
    }

}
