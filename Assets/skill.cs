using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skill : MonoBehaviour
{
    public static skill Static;

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

    public void skill1(int buttonNo)
    {
        if (teamManager.Static.charCard[buttonNo].GetComponent<CardData>().cardSkill != null)
        {
            teamManager.Static.charCard[buttonNo].GetComponent<CardData>().cardSkill.Invoke();
        }

    }


    float orlSpawnCDTime;
    float ExistTime;
    public void beadSpawnSpeedUp(float time, float existTime)
    {
        ExistTime = existTime;
        orlSpawnCDTime = boardManager.Static.spawnCDTime;
        boardManager.Static.spawnCDTime = time;
        StartCoroutine(speedUp());
    }

    IEnumerator speedUp()
    {
        Debug.Log("diudiu");
        yield return new WaitForSeconds(ExistTime);
        boardManager.Static.spawnCDTime = orlSpawnCDTime;
    }

}
