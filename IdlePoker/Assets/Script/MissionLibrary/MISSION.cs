using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

//Gold10000のつもりで書く
public class MISSION : BASE {

    //ミッションの名前
    string _name => "\u25A0 " + Name();
    public virtual string Name() { return ""; }
    //ミッションの達成条件
    public virtual bool MissionCondition() { return false; }
    //スライダーの値
    public virtual float SliderValue() { return 1.0f; }
    public virtual string ProgressText() { return ""; }
    //UPDATE
    public void UpdateMission(TextMeshProUGUI NameText, Slider ProgressSlider,TextMeshProUGUI ProgressText)
    {
        NameText.text = _name;
        ProgressSlider.value = SliderValue();
        ProgressText.text = this.ProgressText();
    }
}

public class GoldGain : MISSION
{
    double requiredGold;
    public override string Name() { return "Gain Total Chip of " + tDigit(requiredGold); }
    //ミッションの達成条件
    public override bool MissionCondition() { return main.SR.chip >= requiredGold; }
    //スライダーの値
    public override float SliderValue() { return (float)(main.SR.chip / requiredGold); }
    public override string ProgressText()
    {
        return tDigit(main.SR.chip) + " / " + tDigit(requiredGold);
    }
    public GoldGain(double requiredGold)
    {
        this.requiredGold = requiredGold;
    }
}

public class AllCleared : MISSION
{
    public override string Name() { return "You Cleared All The Missions!"; }
    //ミッションの達成条件
    public override bool MissionCondition() { return false; }
    //スライダーの値
    public override float SliderValue() { return 1.0f; }
    public override string ProgressText()
    {
        return "Congrats!";
    }
}
