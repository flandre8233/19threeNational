using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour {
    public static playerData Static;
    public List<CardData> playerCardData = new List<CardData>();

    public CardData[,] teamDetails = new CardData[1,3];

    public int coin;
    public int magicStone;
    public int moneyPayTotal;

    void testCharSelection() {
        playerData.Static.teamDetails[0, 0] = playerData.Static.playerCardData[0];
        playerData.Static.teamDetails[0, 1] = playerData.Static.playerCardData[1];
        playerData.Static.teamDetails[0, 2] = playerData.Static.playerCardData[2];
    }

    private void Awake() {
        if (Static != null) {
            Destroy(gameObject);
        }
        else {
            Static = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        testCharSelection();
    }
}
