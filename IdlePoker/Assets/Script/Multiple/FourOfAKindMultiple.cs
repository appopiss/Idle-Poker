using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class FourOfAKindMultiple : MULTIPLE_UPGRADE{

	public override Hand hand => Hand.FourOfAKind;

	// Use this for initialization
	void Start()
	{
		Judge.roleContainer.fourOfAKind.addMultiplier.Add(() => level * 1.0);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
