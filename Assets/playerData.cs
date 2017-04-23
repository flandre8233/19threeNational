using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerData : MonoBehaviour {
    public static playerData Static;
    public List<CardData> playerCardData = new List<CardData>();

    public int coin;
    public int magicStone;

    private void Awake() {
        if (Static != null) {
            Destroy(this);
        }
        else {
            Static = this;
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
