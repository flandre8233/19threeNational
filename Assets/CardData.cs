﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int skill;

    public float Probability { get; set; }

    public GameObject bigPic;
    public GameObject smallPic;

}