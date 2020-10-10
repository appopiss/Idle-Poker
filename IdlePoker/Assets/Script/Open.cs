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

	public void Initialize()
    {
		IsTurned = false;

    }

	RectTransform thisRect;
	public Sprite frontSprite;
	Image thisImage;

	IEnumerator OpenTramp()
    {
        if (IsTurned)
        {
			yield break;
        }
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

		IsTurned = true;
	}


}