using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSkillData : MonoBehaviour {

    public void testSkill()
    {
        Debug.Log("diu");
    }

    public void beadSpawnSpeedUp02secondAnd5second()
    {
        skill.Static.beadSpawnSpeedUp(0.2f,5);
    }

    public void destroyHurtBead()
    {
        destroySpecificBead(type.hurt);
    }

    public void fireToWind()
    {
        changeSpecificBead(type.fire,type.wind);
    }

    public void fireToWater()
    {
        changeSpecificBead(type.fire, type.water);
    }

    public void waterToFire()
    {
        changeSpecificBead(type.water, type.fire);
    }

    public void waterToWind()
    {
        changeSpecificBead(type.water, type.wind);
    }

    public void windToFire()
    {
        changeSpecificBead(type.wind, type.fire);
    }

    public void windToWater()
    {
        changeSpecificBead(type.wind, type.water);
    }

    public void allToFire()
    {
        changeAllBead(type.fire);
    }
    public void allToWater()
    {
        changeAllBead(type.water);
    }
    public void allToWind()
    {
        changeAllBead(type.wind);
    }

    void replaceBead(type toType , GameObject bead)
    {
        switch (toType)
        {
            case type.fire:
                boardManager.Static.createBead(boardManager.Static.canSpawnType[0], bead.GetComponent<beadScript>().boardIndex);
                Destroy(bead);
                break;
            case type.water:
                boardManager.Static.createBead(boardManager.Static.canSpawnType[1], bead.GetComponent<beadScript>().boardIndex);
                Destroy(bead);
                break;
            case type.wind:
                boardManager.Static.createBead(boardManager.Static.canSpawnType[2], bead.GetComponent<beadScript>().boardIndex);
                Destroy(bead);
                break;
            case type.restone:
                boardManager.Static.createBead(boardManager.Static.canSpawnType[3], bead.GetComponent<beadScript>().boardIndex);
                Destroy(bead);
                break;
            case type.hurt:
                boardManager.Static.createBead(boardManager.Static.canSpawnType[4], bead.GetComponent<beadScript>().boardIndex);
                Destroy(bead);
                break;
            default:
                break;
        }
    }

    void destroySpecificBead(type Type )
    {
        GameObject[] goArray = GameObject.FindGameObjectsWithTag("bead");
        Debug.Log(goArray.Length);
        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].GetComponent<beadScript>().type == Type)
            {
                boardManager.Static.delDataObject(
                goArray[i].GetComponent<beadScript>().boardIndex);
            }
        }
    }

    void changeSpecificBead(type Type, type toType)
    {
        GameObject[] goArray = GameObject.FindGameObjectsWithTag("bead");
        Debug.Log(goArray.Length);
        for (int i = 0; i < goArray.Length; i++)
        {
            if (goArray[i].GetComponent<beadScript>().type == Type)
            {

                Debug.Log("gggg");
                replaceBead(toType,goArray[i]);
            }
        }

    }

    void changeAllBead(type Type)
    {
        GameObject[] goArray = GameObject.FindGameObjectsWithTag("bead");
        Debug.Log(goArray.Length);
        for (int i = 0; i < goArray.Length; i++)
        {
            replaceBead(Type, goArray[i]);
        }

    }

}
