using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        if (Physics.Raycast(new Vector3(),new Vector3(0,0,5), out hit, 100.0f))
        {
            Debug.Log(hit.collider.gameObject.name);
            hit.collider.gameObject.transform.localScale += new Vector3(1,1,1);
        }

    }
}
