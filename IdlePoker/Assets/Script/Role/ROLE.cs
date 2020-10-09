using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public class ROLE : BASE {
    public void GetChip()
    {
        main.SR.chip += (initialValue + SumAdd()) * SumMul();
    }
    public virtual Hand role { get; }
    public virtual double initialValue { get; }
    //画面の役を表示するテキスト
    public virtual string RoleText { get => role.ToString(); }
    public MULTIPLE_UPGRADE regularUpgrade;
    public List<Func<double>> mulMultiplier = new List<Func<double>>();
    public List<Func<double>> addMultiplier = new List<Func<double>>();
    double SumMul()
    {
        double temp = 1.0;
        for (int i = 0; i < mulMultiplier.Count; i++)
        {
            temp *= mulMultiplier[i]();
        }
        return temp;
    }
    double SumAdd()
    {
        double temp = 0;
        for (int i = 0; i < addMultiplier.Count; i++)
        {
            temp += addMultiplier[i]();
        }
        return temp;
    }
}

