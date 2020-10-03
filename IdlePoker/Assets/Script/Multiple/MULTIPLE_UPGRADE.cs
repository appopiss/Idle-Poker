using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class MULTIPLE_UPGRADE : BASE {
    // Use this for initialization
    protected void Awake()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Multiply);
        Debug.Log(level);
    }

    protected int level { get => main.SR.MultipleUpgrade_Level; set => main.SR.MultipleUpgrade_Level = value; }
    void Multiply()
    {
        level += 1;
    }

    public double Multiplier()
    {
        return 1.0 + level;
    }

}
