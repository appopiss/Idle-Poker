using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class Flush : ROLE
{

    public override double initialValue => 20000;
    public override Hand role { get => Hand.Flush; }
    public override string RoleText { get => "Flush"; }

}
