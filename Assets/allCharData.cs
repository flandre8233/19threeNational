using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allCharData : MonoBehaviour {
    public static allCharData Static;
    public List<GameObject> allCardData;


    private void Awake() {
        if (Static != null) {
            Destroy(this);
        }
        else {
            Static = this;
        }
    }
}
