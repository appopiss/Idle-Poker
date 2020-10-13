using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class StraightFlushMultiple : MULTIPLE_UPGRADE{

	public override Hand hand => Hand.StraightFlush;

	// Use this for initialization
	void Start()
	{
		Judge.roleContainer.straightFlush.mulMultiplier.Add(() => Math.Pow(2, level));
	}

	// Update is called once per frame
	void Update()
	{

	}
}
