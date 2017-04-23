using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class beadScript : MonoBehaviour, IPointerClickHandler
{
    public Vector2 boardIndex;
    public type type;
    

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

    bool inSpawnCD = false;
    IEnumerator Example() {
        inSpawnCD = true;
        yield return new WaitForSeconds(gamemanager.Static.beadExistTime);
        if (!gamemanager.Static.isWin && !gamemanager.Static.isLoss) {
            boardManager.Static.delDataObject(boardIndex);
        }
        inSpawnCD = false;
    }

    private void Start() {
        if (!inSpawnCD) {
            StartCoroutine(Example());
        }
    }

}
