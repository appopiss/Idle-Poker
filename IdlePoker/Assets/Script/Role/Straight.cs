using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class Straight : ROLE
{

    public override double initialValue => 5000;
    public override Hand role { get => Hand.Straight; }
    public override string RoleText { get => "Straight"; }

}
