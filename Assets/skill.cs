using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill : MonoBehaviour {
    //public Button[] buttonArray;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void skill1(int buttonNo) {
        changeBead(teamManager.Static.charCard[buttonNo].GetComponent<CardData>().Type );
        switch (teamManager.Static.charCard[buttonNo].GetComponent<CardData>().Type) {
            case type.fire:
                break;
            case type.water:
                break;
            case type.wind:
                break;
            case type.restone:
                break;
            case type.hurt:
                break;
            default:
                break;
        }

    }

    void changeBead(type Type) {
        GameObject[] goArray = GameObject.FindGameObjectsWithTag("bead");
        Debug.Log(goArray.Length);
        for (int i = 0; i < goArray.Length; i++) {

        
            switch (Type) {
                case type.fire:
                    boardManager.Static.createBead(boardManager.Static.canSpawnType[0],goArray[i].GetComponent<beadScript>().boardIndex );
                    Destroy(goArray[i] );
                    break;
                case type.water:
                    boardManager.Static.createBead(boardManager.Static.canSpawnType[1], goArray[i].GetComponent<beadScript>().boardIndex);
                    Destroy(goArray[i]);
                    break;
                case type.wind:
                    boardManager.Static.createBead(boardManager.Static.canSpawnType[2], goArray[i].GetComponent<beadScript>().boardIndex);
                    Destroy(goArray[i]);
                    break;
                case type.restone:
                    boardManager.Static.createBead(boardManager.Static.canSpawnType[3], goArray[i].GetComponent<beadScript>().boardIndex);
                    Destroy(goArray[i]);
                    break;
                case type.hurt:
                    boardManager.Static.createBead(boardManager.Static.canSpawnType[4], goArray[i].GetComponent<beadScript>().boardIndex);
                    Destroy(goArray[i]);
                    break;
                default:
                    break;
            }
        }
            
    }

}
