using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : beadScript {
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void attackComboFunction() {
        //回血這裡
        gamemanager.Static.playerHP += gamemanager.Static.playerRestoreHP;
        gamemanager.Static.combo++;
        gamemanager.Static.checkLife();
        //Debug.Log("heart");
        //base.attackComboFunction();
    }

}
