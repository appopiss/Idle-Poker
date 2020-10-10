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

    public virtual Hand hand { get; }

    protected int level { get => main.SR.regularUpgrade_Level[(int)hand] ; set => main.SR.regularUpgrade_Level[(int)hand] = value; }
    protected int sharedLevel { get => main.SR.MultipleUpgrade_Level; set => main.SR.MultipleUpgrade_Level = value; }
    void Multiply()
    {
        level += 1;
        sharedLevel += 1;
    }

}
