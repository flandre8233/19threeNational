using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : beadScript
{
    public override int attackTypeDamage() {
        return gamemanager.Static.waterDamage;
    }

}
