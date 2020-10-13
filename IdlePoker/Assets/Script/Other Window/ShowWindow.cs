using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;

public class ShowWindow : BASE {

	public RectTransform windowRects;
	public Canvas canvas;
	// Use this for initialization
	void Awake()
	{

		windowRects = new RectTransform();

		windowRects = canvas.gameObject.GetComponent<RectTransform>();

		gameObject.GetComponent<Button>().onClick.AddListener(() => ShowRoleUpgrade());
	}

	Vector2 showPosision = new Vector2(1564, 322);

	void ShowRoleUpgrade()
	{
		windowRects.anchoredPosition = showPosision;
	}
}
