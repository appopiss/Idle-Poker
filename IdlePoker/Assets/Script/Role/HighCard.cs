using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using System.Runtime.InteropServices;

public class HighCard : ROLE {

    


    public override void GetChip()
    {
        main.SR.chip += 1 * main.MultipleUpgrade.Multiplier();
    }
    public override Hand role { get => Hand.Nothing; }
    public override string RoleText { get => "HighCard of " + HighCardNum(CurrentHighNumber); }
    int CurrentHighNumber;
    //コンストラクタ...インスタンス化した時に必ず呼ばれる関数
    public HighCard(int number)
    {
        CurrentHighNumber = number;
    }
    string HighCardNum(int number)
    {
        if (number < 9)
        {
            int tempNum = number + 2;
            string highNum = tempNum.ToString();
            return highNum;
        }
        else if (number == 9)
        {
            return "Jack";
        }
        else if (number == 10)
        {
            return "Queen";
        }
        else if (number == 11)
        {
            return "King";
        }
        else
        {
            return "Ace";
        }

    }
}
