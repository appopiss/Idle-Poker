using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
using System.Security.Policy;
using UnityEditor.iOS;

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
    public TextMeshProUGUI RoleText;
    public Image[] TrampImages;
    public Open[] TrampOpens;
    public RectTransform[] TrampRects;
    public Sprite[] TrampSprites;
    public Sprite TrampBackSide;
    

    private void Awake()
    {
        //trampsに52枚代入していく
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 13; j++)
            {
                tramps.Add(new Tramp((Mark)i,(Number)j, TrampSprites[i * 13 + j]));
                tramps[i * 13 + j].backSprite = TrampBackSide;
            }
        }

        TrampOpens = new Open[TrampImages.Length];
        TrampRects = new RectTransform[TrampImages.Length];

        for (int i = 0; i < TrampImages.Length; i++)
        {
            TrampOpens[i] = TrampImages[i].gameObject.GetComponent<Open>();
            TrampRects[i] = TrampImages[i].gameObject.GetComponent<RectTransform>();

        }

        StartCoroutine(Reload());
        //スクリプトをボタン自身に貼り付けている場合
        gameObject.GetComponent<Button>().onClick.AddListener(() => StartCoroutine(Reload()));
    }

    List<Tramp> ShowChosenTramp()
    {
        //使った数字を記録していく
        List<int> UsedNumbers = new List<int>();
        List<Tramp> ResultTramps = new List<Tramp>();
        for (int i = 0; i < TrampImages.Length; i++)
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

    //結果を表示する
    
    bool IsAllTurned()
    {
        for (int i = 0; i < TrampOpens.Length; i++)
        {
            if (!TrampOpens[i].IsTurned)
            {
                return false;   
            }
        }
        return true;

    }

    Vector2 initialPosision = new Vector2(89, -105);
    Vector2 hidePosision = new Vector2(89, -1105);

    bool IsPlaying;
    IEnumerator Reload()
    {
        IsPlaying = true;
        for (int i = 0; i < TrampOpens.Length; i++)
        {
            TrampOpens[i].Initialize();
            //画面外に飛ばす
            TrampRects[i].anchoredPosition = hidePosision + new Vector2(i * 158,0);
        }

        List<Tramp> resultTramps = ShowChosenTramp();

        for (int i = 0; i < resultTramps.Count; i++)
        {

            
            TrampImages[i].sprite = resultTramps[i].backSprite;
        }

        for (int i = 0; i < resultTramps.Count; i++)
        {

            yield return new WaitForSecondsRealtime(0.5f);

            TrampRects[i].anchoredPosition = initialPosision + new Vector2(i * 158, 0);
            TrampOpens[i].frontSprite = resultTramps[i].sprite;
        }

        while (!IsAllTurned())
        {
            yield return null;
        }

        ROLE role = Judge.JudgeHand(resultTramps);
        role.GetChip();
        RoleText.text = role.RoleText;
        IsPlaying = false;
    }
    private void Update()
    {
        if (IsPlaying)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }

    }
    //Delegate 委譲
    //関数をあたかも変数のように扱う（取得・代入）
}

