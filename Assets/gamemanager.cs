using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour {
    public static gamemanager Static;
    public short combo;
    public short totalClick;
    public type[] allowAttackBeadType;
    public int beadExistTime;

    public int playerHP;
    public int playerMaxHP;
    public int playerRestoreHP;
    public bool isDead;

    public int fireDamage;
    public int waterDamage;
    public int windDamage;

    public bool isWin = false;
    public bool isLoss = false;

    // Use this for initialization
    void Start() {
        playerHP = playerMaxHP;
        isWin = false;
        isLoss = false;
        if (Static != null) {
            Destroy(this);
        }
        else {
            Static = this;
        }

    }



    // Update is called once per frame
    void Update() {

    }

    public void enemyAttackPlayerScript( int damage) {
        playerHP -= damage;
        if (deadAliveCheck(playerHP) ) {
            isLoss = true;
        }
        
    }

    public void attackEnemy(int damage) {
        if (GameObject.FindGameObjectWithTag("enemy") == null) {
            return;
        }
        GameObject enemy = GameObject.FindGameObjectWithTag("enemy");

        enemy.GetComponent<npcScript>().HP -= damage;
        if (deadAliveCheck(enemy.GetComponent<npcScript>().HP) ) {
            Destroy(enemy);
            isWin = true;
        }
        
    }

    public void checkLife() {

        if (playerHP > playerMaxHP) {
            playerHP = playerMaxHP;
        }
        else if (playerHP < 0) {
            playerHP = 0;
        }


        //deadAliveCheck();

    }

    public bool deadAliveCheck(int HP) {
        if (HP > 0) {
            //event : hp = 0  gameover
            return false;
        }

        HP = 0;
        //isDead = true;
        //OnPlayerDead();
        return true;

    }

    public void OnPlayerDead() {

    }


}
