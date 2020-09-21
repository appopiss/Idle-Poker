using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class TextUpdate : BASE {

	int score;
	int _cardNumber;
    public int cardNumber { get => _cardNumber; }
	TextMeshProUGUI scoreText;

    // Use this for initialization
	void Awake () {
		StartBASE();
        //AddListener...押した時の処理を追加する。
		gameObject.GetComponent<Button>().onClick.AddListener(() =>
		{
			score++;
		});
        //参照をセットする。
		scoreText = gameObject.GetComponentInChildren<TextMeshProUGUI>();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//textを更新するよ
		scoreText.text = score.ToString();
	}
}
