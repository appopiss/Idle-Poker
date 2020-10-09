using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class StraightFlush : ROLE
{

    public override double initialValue => 725000000;
    public override Hand role { get => Hand.StraightFlush; }
    public override string RoleText { get => "Straight Flush"; }

}
