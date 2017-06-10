using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_main : MonoBehaviour {
    public Text card_count;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        card_count.text = "You have " + playerData.Static.playerCardData.Count + " Card";
    }
}
