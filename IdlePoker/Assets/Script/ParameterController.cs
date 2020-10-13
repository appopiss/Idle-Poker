using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class ParameterController : BASE {

	public TextMeshProUGUI ChipText;
	public TextMeshProUGUI HighCardChip;
	public TextMeshProUGUI APairChip;
	public TextMeshProUGUI TwoPairChip;
	public TextMeshProUGUI ThreeOfAKindChip;
	public TextMeshProUGUI StraightChip;
	public TextMeshProUGUI FlushChip;
	public TextMeshProUGUI AFullHouseChip;
	public TextMeshProUGUI FourOfAKindChip;
	public TextMeshProUGUI StraightFlushChip;
	public TextMeshProUGUI RoyalFlushChip;
	// Use this for initialization
	void Awake () {
		StartBASE();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		ChipText.text = tDigit(main.SR.chip);
		HighCardChip.text = tDigit(Judge.roleContainer.highCard.Value()).ToString();
		APairChip.text = tDigit(Judge.roleContainer.aPair.Value()).ToString();
		TwoPairChip.text = tDigit(Judge.roleContainer.twoPair.Value()).ToString();
		ThreeOfAKindChip.text = tDigit(Judge.roleContainer.threeOfAKind.Value()).ToString();
		StraightChip.text = tDigit(Judge.roleContainer.straight.Value()).ToString();
		FlushChip.text = tDigit(Judge.roleContainer.flush.Value()).ToString();
		AFullHouseChip.text = tDigit(Judge.roleContainer.aFullHouse.Value()).ToString();
		FourOfAKindChip.text = tDigit(Judge.roleContainer.fourOfAKind.Value()).ToString();
		StraightFlushChip.text = tDigit(Judge.roleContainer.straightFlush.Value()).ToString();
		RoyalFlushChip.text = tDigit(Judge.roleContainer.royalFlush.Value()).ToString();
	}
}
