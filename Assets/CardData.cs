using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[System.Serializable]
public class CardData : MonoBehaviour
{
    public int Index;

    [Range(1,99)]
    public short level;

    public type Type;

    public string cardName;

    public int HP;
    public int ATK;
    public int restone;

    public int skillCD;

    public float Probability;

    
    public GameObject bigPic;
    public GameObject smallPic;

    public UnityEvent cardSkill;





}