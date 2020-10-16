using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;
using TMPro;
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

    public TextMeshProUGUI RoleText;
    public Image[] TrampImages;
    public Open[] TrampOpens;
    public RectTransform[] TrampRects;
    public CardPool cardPool;
    public Toggle autoOpenToggle;
    int SumTramp() { return TrampImages.Length; } 
    private void Awake()
    {
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

    bool IsReloading;
    IEnumerator Reload()
    {
        IsReloading = true;
        for (int i = 0; i < TrampOpens.Length; i++)
        {
            TrampOpens[i].Initialize();
            //画面外に飛ばす
            TrampRects[i].anchoredPosition = hidePosision + new Vector2(i * 158,0);
        }

        List<Tramp> resultTramps = cardPool.ChooseCards(SumTramp());

        for (int i = 0; i < resultTramps.Count; i++)
        {

            
            TrampImages[i].sprite = resultTramps[i].backSprite;
        }

        for (int i = 0; i < resultTramps.Count; i++)
        {

            yield return new WaitForSecondsRealtime(0.5f);

            TrampRects[i].anchoredPosition = initialPosision + new Vector2(i * 158, 0);
            TrampOpens[i].frontSprite = null;
            TrampOpens[i].frontSprite = resultTramps[i].sprite;
        }

        while (!IsAllTurned())
        {
            yield return null;
        }

        ROLE role = Judge.JudgeHand(resultTramps);
        role.GetChip();
        RoleText.text = role.RoleText;
        IsReloading = false;
    }

    IEnumerator FullOpen()
    {
        for (int i = 0; i < TrampOpens.Length; i++)
        {
            if (TrampOpens[i].IsTurned) { continue; }
            yield return StartCoroutine(TrampOpens[i].OpenTramp());
        }
    }

    /*void AutoOpen()
    {
        if (IsReloading) { return; }
        if(IsAllTurned)
        if (autoOpenToggle.isOn)
        {
            StartCoroutine(FullOpen());
        }
        


    }*/



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(FullOpen());
        }

        if (IsReloading)
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

