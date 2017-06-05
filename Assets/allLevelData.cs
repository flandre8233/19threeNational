using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allLevelData : MonoBehaviour {
    public static allLevelData Static;

    public List<levelData> allLevelDataList;


    private void Awake()
    {
        if (Static != null)
        {
            Destroy(this);
        }
        else
        {
            Static = this;
        }
    }
}
