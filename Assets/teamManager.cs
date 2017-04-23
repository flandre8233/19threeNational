﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamManager : MonoBehaviour {
    public GameObject[] charBoard = new GameObject[3];
    public Transform charDisplayBoard;
    short teamNo = 0;
    

	// Use this for initialization
	void Start () {
        getItemDetails(teamNo);
        getTeamTotalAbility();
    }

    
    void getItemDetails(short teamNo ) {
        for (int i = 0; i < charBoard.Length; i++) {
            GameObject go = allCharData.Static.allCardData[playerData.Static.teamDetails[teamNo, i].GetComponent<CardData>().Index];
            charBoard[i] = createCardBig(go,charBoard[i].GetComponent<RectTransform>() );
            //charBoard[i] = playerData.Static.teamDetails[teamNo, i];
        }
    }

    GameObject createCardBig(GameObject spawnObject, RectTransform Rect) {
        GameObject go = Instantiate(spawnObject, charDisplayBoard);
        go.GetComponent<RectTransform>().anchorMin = Rect.anchorMin;
        go.GetComponent<RectTransform>().anchorMax = Rect.anchorMax;
        go.GetComponent<RectTransform>().anchoredPosition = Rect.anchoredPosition;
        go.GetComponent<RectTransform>().sizeDelta = Rect.sizeDelta;
        go.GetComponent<CardData>().bigPic.GetComponent<RectTransform>().sizeDelta = Rect.sizeDelta;
        go.GetComponent<CardData>().bigPic.SetActive(true);

        Destroy(Rect.gameObject);

        return go;
    }

    void getTeamTotalAbility() {
        gamemanager.Static.playerMaxHP =0;
        gamemanager.Static.playerRestoreHP = 0;
        gamemanager.Static.fireDamage = 0;
        gamemanager.Static.waterDamage = 0;
        gamemanager.Static.windDamage = 0;

        short i = 0;
        foreach (var item in charBoard) {
            gamemanager.Static.playerMaxHP += item.GetComponent<CardData>().HP;
            gamemanager.Static.playerRestoreHP += item.GetComponent<CardData>().restone;
            gamemanager.Static.allowAttackBeadType[i] = item.GetComponent<CardData>().Type;

            i++;
            switch (item.GetComponent<CardData>().Type) {
                case type.fire:
                    gamemanager.Static.fireDamage = item.GetComponent<CardData>().ATK;
                    break;
                case type.water:
                    gamemanager.Static.waterDamage = item.GetComponent<CardData>().ATK;
                    break;
                case type.wind:
                    gamemanager.Static.windDamage = item.GetComponent<CardData>().ATK;
                    break;
                case type.restone:
                    break;
                case type.hurt:
                    break;
                default:
                    break;
            }

        }

        gamemanager.Static.playerHP = gamemanager.Static.playerMaxHP;

    }

}