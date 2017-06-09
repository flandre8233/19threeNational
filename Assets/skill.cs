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

    public int[] curCD;

    public void controllSkillCD()
    {
        for (int i = 0; i < teamManager.Static.charCard.Length; i++)
        {
            CardData item = teamManager.Static.charCard[i].GetComponent<CardData>();
            if (checkCD(i) )
            {
                item.smallPic.GetComponent<Image>().color = new Color(1,1,1,1);
            }
            else
            {
                item.smallPic.GetComponent<Image>().color = new Color(0.6f, 0.6f, 0.6f, 1);
            }
        }

    }

    public void CDBoost()
    {
        for (int i = 0; i < curCD.Length; i++)
        {
            curCD[i]++;
        }

    }

    bool checkCD(int No)
    {
        CardData item = teamManager.Static.charCard[No].GetComponent<CardData>();
        Debug.Log(item.skillCD);
        bool result = false;
        if (item.skillCD > curCD[No] )
        {
            result = false;
        }
        else
        {
            result = true;
        }
        return result;
    }

    public void skill1(int buttonNo)
    {
        if (teamManager.Static.charCard[buttonNo].GetComponent<CardData>().cardSkill != null && checkCD(buttonNo) )
        {
            teamManager.Static.charCard[buttonNo].GetComponent<CardData>().cardSkill.Invoke();
            curCD[buttonNo] = 0;
            controllSkillCD();
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
