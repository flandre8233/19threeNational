using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour {
    public static levelManager Static;


    public int currentFloor = 0;
    public int currentLevelIndex;

    public RectTransform monsterDisplayRectTransform;

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

    // Use this for initialization
    void Start () {
        //enterFloor();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.H) )
        {
            nextFloor();
        }
	}

    public void enterFloor()
    {
        Instantiate(allEnemyData.Static.allEnemyDatas[currentFloor], monsterDisplayRectTransform.transform);

    }

    void clearCurrentFloor()
    {
        foreach (var item in GameObject.FindGameObjectsWithTag("enemy"))
        {
            Destroy(item);
        }

    }

    public void nextFloor()
    {
        currentFloor++;
        clearCurrentFloor();
        enterFloor();
    }

}
