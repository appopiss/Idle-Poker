﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class TwoPairMultiple : MULTIPLE_UPGRADE{


	// Use this for initialization
	void Start()
	{
		Judge.roleContainer.twoPair.addMultiplier.Add(() => level * 1.0);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
