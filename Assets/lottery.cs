using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        CardData hitCard = lotteryTotal[itemAndEnemyProcessor.RandomProbabilitySystem(lotteryPro) - 1].GetComponent<CardData>();
         playerData.Static.playerCardData.Add(hitCard);
        //Debug.Log(playerData.Static.playerCardData[playerData.Static.playerCardData.Count - 1].Type);
        cardNameDisplay.text = "恭喜你中了：" + hitCard.cardName;
        cardImageDisplay.sprite = hitCard.bigPic.GetComponent<Image>().sprite;
        cardImageDisplay.SetNativeSize();
        cardImageDisplay.color = new Color(1,1,1,1);


        Debug.Log(playerData.Static.playerCardData.Count );
    }
    public Text cardNameDisplay;
    public Image cardImageDisplay;

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
