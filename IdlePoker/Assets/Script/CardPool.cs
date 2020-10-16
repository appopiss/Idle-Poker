using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using static BASE;
using TMPro;
using PlayFab.GroupsModels;

public class CardPool : BASE {

	public List<Tramp> tramps = new List<Tramp>();
	public Sprite[] TrampSprites;
	public Sprite TrampBackSide;

	// Use this for initialization
	void Awake () {
		SetUpTramp();
	}

	void SetUpTramp()
    {
		//trampsに52枚代入していく
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 13; j++)
			{
				tramps.Add(new Tramp((Mark)i, (Number)j, TrampSprites[i * 13 + j]));
				tramps[i * 13 + j].backSprite = TrampBackSide;
			}
		}
	}

    public List<Tramp> ChooseCards(int sum_tramp)
    {
        //使った数字を記録していく
        List<int> UsedNumbers = new List<int>();
        List<Tramp> ResultTramps = new List<Tramp>();
        for (int i = 0; i < sum_tramp; i++)
        {
            Tramp chosenTramp;
            int rand;
            int count = 0;
            while (count <= 1000)
            {
                count++;
                rand = UnityEngine.Random.Range(0, tramps.Count);
                bool isStacked = false;
                for (int j = 0; j < UsedNumbers.Count; j++)
                {
                    if (rand == UsedNumbers[j])
                    {
                        isStacked = true;
                    }
                }
                if (!isStacked)
                {
                    UsedNumbers.Add(rand);
                    chosenTramp = tramps[rand];
                    ResultTramps.Add(chosenTramp);
                    break;
                }
            }
        }

        return ResultTramps;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
