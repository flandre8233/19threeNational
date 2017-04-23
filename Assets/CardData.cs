using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public int Index;

    [Range(1,99)]
    public short level;

    public type Type;

    public string cardName { get; set; }

    public int HP { get; set; }
    public int ATK { get; set; }
    public int restone { get; set; }

    public int skill { get; set; }

    public float Probability { get; set; }

    public GameObject bigPic;
    public GameObject smallPic;

}