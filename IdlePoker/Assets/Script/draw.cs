using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;

public class draw : BASE {
    //値型 ... intやdoubleやstringなど。
    //①宣言と同時にインスタンスが生成される。
    //②変数を渡した時に値がコピーされる。
    /*
     * 参照方 ... int[]などの配列や、ほとんどのクラス
     * ①明示的にインスタンス化が必要
     * ②変数を渡した時に参照がコピーされる。
     */

    public List<Tramp> tramps = new List<Tramp>();
    public TextMeshProUGUI[] TrampTexts;
    public TextMeshProUGUI RoleText;
    public Image[] TrampImages;
    private void Awake()
    {
        //trampsに52枚代入していく
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                tramps.Add(new Tramp((Mark)i,(Number)j));
            }
        }
        //スクリプトをボタン自身に貼り付けている場合
        gameObject.GetComponent<Button>().onClick.AddListener(ShowChosenTramp);
    }

    void ShowChosenTramp()
    {
        //使った数字を記録していく
        List<int> UsedNumbers = new List<int>();
        List<Tramp> ResultTramps = new List<Tramp>();
        for (int i = 0; i < TrampTexts.Length; i++)
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
        //結果を表示する
        ROLE role = Judge.JudgeHand(ResultTramps);
        role.GetChip();
        RoleText.text = role.RoleText;
        ShowNumber(ResultTramps);
    }
    void ShowNumber(List<Tramp> tramps)
    {
        for (int i = 0; i < tramps.Count; i++)
        {
            TrampTexts[i].text = (((int)tramps[i].number)+2).ToString();
        }
    }
    private void Update()
    {

    }

    //Delegate 委譲
    //関数をあたかも変数のように扱う（取得・代入）
}

