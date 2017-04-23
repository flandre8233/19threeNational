using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : beadScript
{
    public override int attackTypeDamage() {
        return gamemanager.Static.fireDamage;
    }

}
