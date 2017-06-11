using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStatus : MonoBehaviour {
    public static gameStatus Static;
    public bool alreadyOpenTitle;



    private void Awake()
    {
        if (Static != null)
        {
            Destroy(this);
        }
        else
        {
            Static = this;
        }
    }
}
