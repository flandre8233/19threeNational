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
    public int enterLevel;

    public bool lock_start = false;
    public bool first_scene_lock = true;

    void testCharSelection()
    {
        Debug.Log(playerCardData.Count);
        teamDetails[0, 0] = playerCardData[0];
        teamDetails[0, 1] = playerCardData[1];
        teamDetails[0, 2] = playerCardData[2];
        Debug.Log(
        teamDetails.GetLength(1));
    }

    private void Awake() {
        if (Static != null) {
            Destroy(gameObject);
            return;
        }
        else {
            Static = this;
            DontDestroyOnLoad(transform.gameObject);
        }
        testCharSelection();
    }
}
