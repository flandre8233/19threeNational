using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lottert_UI_script : MonoBehaviour {
    public Text stone_count;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        stone_count.text = "You have " + playerData.Static.magicStone + " Magic Stone";
    }
}
