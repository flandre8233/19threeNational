using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lottery : MonoBehaviour {
    public static lottery Static;
    public List<GameObject> lotteryTotal;

    public short cost;

	// Use this for initialization
	void Start () {
        lotteryTotal = serializeAllCard();
        if (Static != null) {
            Destroy(this);
        }
        else {
            Static = this;
        }
    }
    public  List<float> lotteryPro = new List<float>();
    public void startRandom() {
        //
        if (playerData.Static.magicStone < cost) {
            return;
        }


        lotteryPro.Clear();
        foreach (var item in lotteryTotal)
        {
            lotteryPro.Add(item.GetComponent<CardData>().Probability );
        }

        playerData.Static.magicStone -= cost;
         playerData.Static.playerCardData.Add( lotteryTotal[itemAndEnemyProcessor.RandomProbabilitySystem(lotteryPro) - 1  ].GetComponent<CardData>() );
        //Debug.Log(playerData.Static.playerCardData[playerData.Static.playerCardData.Count - 1].Type);
        Debug.Log(playerData.Static.playerCardData.Count );
    }


	// Update is called once per frame
	void Update () {
		
	}

    List<GameObject> serializeAllCard()
    {
        List<GameObject> list;
        GameObject[] array;
        //all = Resources.LoadAll("card",typeof(GameObject) );
        array = Resources.LoadAll<GameObject>("card");
        list = arrayToList(array);
        for (int i = 0; i < list.Count; i++)
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
