using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class beadScript : MonoBehaviour, IPointerClickHandler
{
    public Vector2 boardIndex;
    public string type;
    

    public void OnPointerClick(PointerEventData eventData) { //work
        if (gamemanager.Static.isWin || gamemanager.Static.isLoss) {
            return;
        }

        // OnClick code goes here ...
        Debug.Log(boardIndex);
        gamemanager.Static.totalClick++;
        boardManager.Static.delDataObject(boardIndex);
        attackComboFunction();
        
    }

    public virtual void attackComboFunction() {
        if (checkIsAllowAttack()) {
            gamemanager.Static.combo++;
            gamemanager.Static.attackEnemy( attackTypeDamage() );
            //傷害
        }
        else {
            gamemanager.Static.combo = 0;
        }
    }

    public virtual int attackTypeDamage() {
        return 0;
    }

    bool checkIsAllowAttack() {
        foreach (var item in gamemanager.Static.allowAttackBeadType) {
            if (item == type) {
                return true;
            }
        }
        return false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    }
}
