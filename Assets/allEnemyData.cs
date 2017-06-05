using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allEnemyData : MonoBehaviour {
    public static allEnemyData Static;
    public List<GameObject> allEnemyDatas;

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
        allEnemyDatas = serializeAllEnemyDatas();
    }

    List<GameObject> serializeAllEnemyDatas()
    {
        List<GameObject> list;
        GameObject[] array;
        //all = Resources.LoadAll("card",typeof(GameObject) );
        array = Resources.LoadAll<GameObject>("enemy");
        list = arrayToList(array);
        for (int i = 0; i < list.Count; i++)
        {
            list[i].GetComponent<npcScript>().ID = i;
        }
        return list;
    }

    List<GameObject> arrayToList(GameObject[] arrayGo)
    {
        List<GameObject> returnList = new List<GameObject>();
        foreach (var item in arrayGo)
        {
            returnList.Add(item);
        }
        return returnList;
    }

}
