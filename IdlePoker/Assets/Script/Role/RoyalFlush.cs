using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class RoyalFlush : ROLE
{

    public override double initialValue => 90000000000;
    public override Hand role { get => Hand.RoyalFlush; }
    public override string RoleText { get => "Royal Flush"; }

}
