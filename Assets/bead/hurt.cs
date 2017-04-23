using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurt : beadScript {

    public override void attackComboFunction() {
        if (gamemanager.Static.findEnemy() == null) {
            return;
        }
        gamemanager.Static.enemyAttackPlayerScript(gamemanager.Static.findEnemy().GetComponent<npcScript>().damage );
        gamemanager.Static.combo = 0;
    }
}
