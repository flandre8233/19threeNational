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

    public GameObject damageDisplayObject;

    public GameObject parent;

    public void spawnNumberDisplay(Vector3 where, int number, int type)
    {
        //GameObject go = Instantiate(damageDisplayObject, where, Quaternion.identity);
        GameObject go = Instantiate(damageDisplayObject, parent.transform );
        go.GetComponent<damageDisplay>().spawnDamageDisplay(number, type);
    }

    // Use this for initialization
    void Start() {
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
        if (Input.GetKeyUp(KeyCode.L) )
        {
            spawnNumberDisplay(new Vector3(),495,0);
        }
    }

    public shrinkManager enemyShrink;
    public shrinkManager playerShrink;

    public void enemyAttackPlayerScript( int damage) {
        playerShrink.startShrink();
        playerHP -= damage;
        if (deadAliveCheck(playerHP) ) {
            isLoss = true;
        }
        
    }

    public GameObject findEnemy() {
        if (GameObject.FindGameObjectWithTag("enemy") == null) {
            return null;
        }
        return GameObject.FindGameObjectWithTag("enemy");
    }

    public void attackEnemy(int damage,type Type) {
        if (findEnemy() == null) {
            return;
        }
        GameObject enemy = findEnemy();

        enemyShrink.startShrink();
        int realDamage = (int)(damageIncludeCombo(damage) * checkTypeInhibition(enemy.GetComponent<npcScript>().type, Type));
        enemy.GetComponent<npcScript>().HP -= realDamage;
        switch (Type)
        {
            case type.fire:
                spawnNumberDisplay(new Vector3(), realDamage, 4);
                break;
            case type.water:
                spawnNumberDisplay(new Vector3(), realDamage, 2);
                break;
            case type.wind:
                spawnNumberDisplay(new Vector3(), realDamage, 3);
                break;
        }
        if (deadAliveCheck(enemy.GetComponent<npcScript>().HP) ) {
            Destroy(enemy);
            checkFloor();
        }
        
    }

    int damageIncludeCombo(int damage)
    {
        int number = 0;
        float comboIncrease = 1.2f;
        number = (int) (damage * (combo + comboIncrease) );

        return number;
    }

    float checkTypeInhibition(type enemyType, type Type)
    {
        switch (Type)
        {
            case type.fire:
                switch (enemyType)
                {
                    case type.fire:
                        return 1;
                    case type.water:
                        return 0.5f;
                    case type.wind:
                        return 2;
                }
                break;
            case type.water:
                switch (enemyType)
                {
                    case type.fire:
                        return 2;
                    case type.water:
                        return 1;
                    case type.wind:
                        return 0.5f;
                }
                break;
            case type.wind:
                switch (enemyType)
                {
                    case type.fire:
                        return 0.5f;
                    case type.water:
                        return 2;
                    case type.wind:
                        return 1;
                }
                break;
        }
        return 1;
    }


    void checkFloor()
    {
        if (levelManager.Static.currentFloor < allLevelData.Static.allLevelDataList[levelManager.Static.currentLevelIndex].floorDetails.Count )
        {
            levelManager.Static.nextFloor();
        }
        else
        {
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
