using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lottery : MonoBehaviour {
    public static lottery Static;
    public List<GameObject> lotteryTotal;

    public short cost;

	// Use this for initialization
	void Start () {
        if (Static != null) {
            Destroy(this);
        }
        else {
            Static = this;
        }
    }
	
    public void startRandom() {
        //
        if (playerData.Static.magicStone < cost) {
            return;
        }

        playerData.Static.magicStone -= cost;
         playerData.Static.playerCardData.Add( lotteryTotal[  itemAndEnemyProcessor.randomSetThingsType(lotteryTotal ) -1  ].GetComponent<CardData>() );
        //Debug.Log(playerData.Static.playerCardData[playerData.Static.playerCardData.Count - 1].Type);
        Debug.Log(playerData.Static.playerCardData.Count );
    }

	// Update is called once per frame
	void Update () {
		
	}
}
