using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class FourOfAKind : ROLE
{

    public override double initialValue => 2000000;
    public override Hand role { get => Hand.FourOfAKind; }
    public override string RoleText { get => "Four of a Kind"; }

}
