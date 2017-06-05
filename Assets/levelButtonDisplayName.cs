using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelButtonDisplayName : MonoBehaviour {
    public int levelIndex;

    private void Start()
    {
        if (allLevelData.Static == null)
        {
            GetComponentInChildren<Text>().text = "diu";
            return;
        }

        GetComponentInChildren<Text>().text = allLevelData.Static.allLevelDataList[levelIndex].levelName;
    }
}
