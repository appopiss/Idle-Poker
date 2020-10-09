using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class AFullHouse : ROLE
{

    public override double initialValue => 100000;
    public override Hand role { get => Hand.AFullHouse; }
    public override string RoleText { get => "A Full House"; }

}