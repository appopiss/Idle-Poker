using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public enum Mark
{
    spade,
    heart,
    diamond,
    club,
}
public enum Number
{
    two,
    three,
    four,
    five,
    six,
    seven,
    eight,
    nine,
    ten,
    J,
    Q,
    K,
    A,
}
public class Tramp : BASE {
    public Mark markId;
    public Number number;
    public Sprite sprite;
    public Sprite backSprite;
    //testだよ
    public Tramp(Mark markId, Number number, Sprite sprite)
    {
        this.markId = markId;
        this.number = number;
        this.sprite = sprite;
    }
}
