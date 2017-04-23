using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hpShow : MonoBehaviour {
    public Text playerHPtext;
    public Text enemyHPtext;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        playerHPtext.text = gamemanager.Static.playerMaxHP + " / " + gamemanager.Static.playerHP;
        enemyHPtext.text = gamemanager.Static.findEnemy().GetComponent<npcScript>().HP + " / " + gamemanager.Static.findEnemy().GetComponent<npcScript>().MaxHP;

    }
}
