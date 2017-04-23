using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum type
{
    fire,
    water,
    wind,
    restone

}

public class bagManager : MonoBehaviour {
    public static bagManager Static;
    











	// Use this for initialization
	void Start () {
        if (Static != null) {
            Destroy(this);
        }
        else {
            Static = this;
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
