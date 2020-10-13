using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using System.Runtime.InteropServices;
using TMPro;

public class HighCard: ROLE {

    public TextMeshProUGUI highCardChip;
    public override double initialValue => 1;
    public override Hand role { get => Hand.HighCard; }
    public override string RoleText { get => "High Card"; }



    /*int CurrentHighNumber;
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

    }*/
}
