using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour {
    public int HP;
    public int MaxHP;
    public float attackCD;
    public int damage;

	// Use this for initialization
	void Start () {
        HP = MaxHP;
	}
	
	// Update is called once per frame
	void Update () {
        if (!inSpawnCD) {
            StartCoroutine(Example());
        }
    }

    bool inSpawnCD = false;
    IEnumerator Example() {
        inSpawnCD = true;
        yield return new WaitForSeconds(attackCD);
        attack();
        inSpawnCD = false;
    }

    void attack() {
        gamemanager.Static.enemyAttackPlayerScript(damage);
    }

}
