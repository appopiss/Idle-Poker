using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;
using UnityEditor;

public class Open : BASE
{

	// Use this for initialization
	void Awake()
	{
		thisRect = gameObject.GetComponent<RectTransform>();
		thisImage = gameObject.GetComponent<Image>();
		gameObject.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(OpenTramp()));
	}


	public bool IsTurned;
	public bool IsMoving;

	public void Initialize()
    {
		IsTurned = false;
		IsMoving = false;

    }

	RectTransform thisRect;
	public Sprite frontSprite;
	Image thisImage;

	public IEnumerator OpenTramp()
    {
        if (IsMoving) { yield break; }
        if (IsTurned)
        {
			yield break;
        }
		IsMoving = true;
        for (int i = 0; i < 15; i++)
        {
			thisRect.Rotate(new Vector3(0, 90 / 15));
			yield return new WaitForSecondsRealtime(0.25f / 15);
		}

		thisImage.sprite = frontSprite;

		for (int i = 0; i < 15; i++)
		{
			thisRect.Rotate(new Vector3(0, -90 / 15));
			yield return new WaitForSecondsRealtime(0.25f / 15);
		}
		IsMoving = false;
		IsTurned = true;
	}


}