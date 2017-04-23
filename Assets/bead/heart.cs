using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heart : beadScript {

    public override void attackComboFunction() {
        //回血這裡
        gamemanager.Static.playerHP += gamemanager.Static.playerRestoreHP;
        gamemanager.Static.combo++;
        gamemanager.Static.checkLife();
        //Debug.Log("heart");
        //base.attackComboFunction();
    }

}
