using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class TwoPair : ROLE
{

    public override double initialValue => 10;
    public override Hand role { get => Hand.TwoPair; }
    public override string RoleText { get => "Two Pair"; }

}
