using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class ThreeOfAKind : ROLE
{

    public override double initialValue => 100;
    public override Hand role { get => Hand.ThreeOfAKind; }
    public override string RoleText { get => "Three Of A Kind"; }

}
