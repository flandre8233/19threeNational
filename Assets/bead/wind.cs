using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind : beadScript {
    public override int attackTypeDamage() {
        return gamemanager.Static.windDamage;
    }

}
