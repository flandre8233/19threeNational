using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class allCharData : MonoBehaviour {
    public static allCharData Static;
    public List<GameObject> allCardData;

    public object[] all;


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
        allCardData = serializeAllCard();
    }

    List<GameObject> serializeAllCard()
    {
        List<GameObject> list;
        GameObject[] array;
        //all = Resources.LoadAll("card",typeof(GameObject) );
        array = Resources.LoadAll<GameObject>("card");
        list = arrayToList(array);
        for (int i = 0;  i < list.Count; i++)
        {
            list[i].GetComponent<CardData>().Index = i;
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
