using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class APair : ROLE
{

    public override double initialValue => 2;
    public override Hand role { get => Hand.APair; }
    public override string RoleText { get => "A Pair"; }

}