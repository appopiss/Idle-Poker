using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
//using MathNet.Numerics.Distributions;
using static System.Math;

public class UsefulMethod : MonoBehaviour
{

    /// <summary>
    /// テキストを指定するだけで，マウスオーバーでテキストを表示させる関数．
    /// </summary>
    public GameObject windowPre;
    public Transform windowTransform;
    public static GameObject window;

    public delegate void usefuleDelegate();

    public static void addWindow(string text, ref GameObject game)
    {
        game.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => setActive(window, text));
        entry2.callback.AddListener((x) => setFalse(window)); //ラムダ式の右側は追加するメソッドです。

        game.AddComponent<EventTrigger>().triggers.Add(entry);
        game.AddComponent<EventTrigger>().triggers.Add(entry2);

        //window.transform.GetChild(0).GetComponent<Text>().text = text;
    }
    public static void addWindowOver(string text, ref Button game)
    {
        game.gameObject.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry2.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((x) => setActive(window, text));
        entry2.callback.AddListener((x) => setFalse(window)); //ラムダ式の右側は追加するメソッドです。

        game.gameObject.AddComponent<EventTrigger>().triggers.Add(entry);
        game.gameObject.AddComponent<EventTrigger>().triggers.Add(entry2);

        //window.transform.GetChild(0).GetComponent<Text>().text = text;
    }
    public static void setOnPointerClick(ref GameObject game)
    {
        game.AddComponent<EventTrigger>().triggers = new List<EventTrigger.Entry>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        game.GetComponent<EventTrigger>().triggers.Add(entry);
    }

    public static void setActive(GameObject go, string text)
    {
        go.SetActive(true);
        go.transform.GetChild(0).GetComponent<Text>().text = text;
    }
    public static void setActive(GameObject go)
    {
        if (!go.activeSelf)
        {
            go.SetActive(true);
        }
    }

    public static void setActive(GameObject go, bool bo)
    {
        if (!go.activeSelf&&bo)
        {
            go.SetActive(true);
        }
    }

    public static void setFalse(GameObject go)
    {
        if (go.activeSelf)
        {
            go.SetActive(false);
        }
    }
    /// <summary>
    /// 桁数が大きいものを，アルファベット表記に変える関数
    /// </summary>
    public static string[] digit = new string[]
{
       "", "K","M","B","T","Qa","Qi","Sx","Sp","No","Dc","Ud","Dd","Td","Qad","Qid","Sxd","Spd","Ods","Nod","Vg","Uvg","Dvg","Tvg","Qavg","Qivg","Sxvg","Spvg","Ocvs","Novg",
       "Tg","Utg","Dtg","Ttg","Qatg","Qitg","Sxts","Sptg","Octg","Notg"
};
    public static string tDigit(double i)
    {
        string tempString;
        string showNum = "";
        double tempNum = i;
        string iString = tempNum.ToString("F");

        if (i == 1000)
        {
            return "1K";
        }

        if (i == 1000000)
        {
            return "1M";
        }

        if (i >= 1000)
        {
            int count = 0;
            int digitNum = (int)Math.Log10(i) + 1;
            while (true)
            {
                double syou = tempNum / 1000;
                tempNum = syou;
                count++;
                if (tempNum < 1)
                {
                    break;
                }

            }
            if (digitNum % 3 == 0)
            {
                tempString = iString.Substring(0, 6);
                showNum = tempString.Substring(0, 3) + "." + tempString.Substring(3, 1);
            }
            else if (digitNum % 3 == 1)
            {
                tempString = iString.Substring(0, 4);
                showNum = tempString.Substring(0, 1) + "." + tempString.Substring(1, 1);
            }
            else if (digitNum % 3 == 2)
            {
                tempString = iString.Substring(0, 5);
                showNum = tempString.Substring(0, 2) + "." + tempString.Substring(2, 1);
            }

            return showNum + digit[count - 1];

        }

        return ((int)i).ToString("F0");

    }
    public static string tDigit(double i,int j)
    {
        string tempString;
        string showNum = "";
        double tempNum = i;
        string iString = tempNum.ToString("F");

        if (i > 1000)
        {
            int count = 0;
            int digitNum = (int)Math.Log10(i) + 1;
            while (true)
            {
                double syou = tempNum / 1000;
                tempNum = syou;
                count++;
                if (tempNum < 1)
                {
                    break;
                }

            }
            if (digitNum % 3 == 0)
            {
                tempString = iString.Substring(0, 6);
                showNum = tempString.Substring(0, 3) + "." + tempString.Substring(3, 1);
            }
            else if (digitNum % 3 == 1)
            {
                tempString = iString.Substring(0, 4);
                showNum = tempString.Substring(0, 1) + "." + tempString.Substring(1, 1);
            }
            else if (digitNum % 3 == 2)
            {
                tempString = iString.Substring(0, 5);
                showNum = tempString.Substring(0, 2) + "." + tempString.Substring(2, 1);
            }

            return showNum + digit[count - 1];

        }

        switch(j){

            case 1:
            return i.ToString("F1");
            case 2:
                return i.ToString("F2");
            case 3:
                return i.ToString("F3");
            default:
                return "";
        }

    }
    public static string tDigitColor(double i, int? j = null)
    {
        string tempString;
        string showNum = "";
        double tempNum = i;
        string iString = tempNum.ToString("F");

        if (i > 1000)
        {
            int count = 0;
            int digitNum = (int)Math.Log10(i) + 1;
            while (true)
            {
                double syou = tempNum / 1000;
                tempNum = syou;
                count++;
                if (tempNum < 1)
                {
                    break;
                }

            }
            if (digitNum % 3 == 0)
            {
                tempString = iString.Substring(0, 6);
                showNum = tempString.Substring(0, 3) + "." + tempString.Substring(3, 1);
            }
            else if (digitNum % 3 == 1)
            {
                tempString = iString.Substring(0, 4);
                showNum = tempString.Substring(0, 1) + "." + tempString.Substring(1, 1);
            }
            else if (digitNum % 3 == 2)
            {
                tempString = iString.Substring(0, 5);
                showNum = tempString.Substring(0, 2) + "." + tempString.Substring(2, 1);
            }

            return showNum +"<color=\"yellow\">" +digit[count - 1];

        }

        switch (j)
        {

            case 1:
                return i.ToString("F1");
            case 2:
                return i.ToString("F2");
            case 3:
                return i.ToString("F3");
            default:
                return i.ToString("F0");
        }
    }
    public static void writeGyoretsu(int[,] ary)
    {
        string str = "";
        int FEcount = 0;
        foreach (int expInt in ary)
        {
            str = str + "," + expInt.ToString();
            FEcount++;
            if (FEcount % ary.GetLength(1) == 0)
            {
                str = str + "\n";
            }

        }
        Debug.Log(str);
    }
    public static void writeList(List<int> list)
    {
        string str = "";
        foreach (int num in list)
        {
            str = str + "," + num.ToString();
        }
        Debug.Log(str);
    }

    public static void writeList(List<double> list)
    {
        string str = "";
        foreach (double num in list)
        {
            str = str + "," + num.ToString("F1");
        }
        Debug.Log(str);
    }

    public static void writeArray(int[] Array)
    {
        string str = "";
        foreach (int num in Array)
        {
            str = str + "," + num.ToString("F1");
        }
        Debug.Log(str);
    }
    public static Vector2 normalize(Vector2 vector)
    {
        float x = vector.x;
        float y = vector.y;
        float normalizeFactor = 1.0f / Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
        if(float.IsNaN(normalizeFactor))
        {
            return new Vector2(0, 0);
        }
        Vector2 vector2 = new Vector2(x * normalizeFactor, y * normalizeFactor);
        return vector2;
    }

    public static float vectorAbs(Vector2 vector)
    {
        float x = vector.x;
        float y = vector.y;
        return Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
    }

    public static IEnumerator NewInvokeCor(usefuleDelegate Dele, float Time)
    {
        yield return new WaitForSeconds(Time);
        Dele();
    }

    //減算の処理
    public static bool IfCanSubSub(ref double Target, double Value)
    {
        if (Target >= Value)
        {
            Target -= Value;
            return true;
        }
        else
        {
            Debug.Log("値が大きすぎます");
            return false;
        }
    }



    //windowを出すコルーチン
    public static IEnumerator bigAndBig(GameObject targetUI)
    {
        targetUI.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
        targetUI.SetActive(true);
        for (float i = 0.5f; i <= 1.0f; i += 0.1f)
        {
            targetUI.GetComponent<RectTransform>().localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.01f);
        }
        targetUI.GetComponent<RectTransform>().localScale = Vector3.one;
    }

    //windowを消すコルーチン
    public static IEnumerator smallAndSmall(GameObject targetUI)
    {
        targetUI.GetComponent<RectTransform>().localScale = Vector3.one;
        for (float i = 1.0f; i >= 0.5f; i -= 0.1f)
        {
            targetUI.GetComponent<RectTransform>().localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.01f);
        }
        targetUI.SetActive(false);
        targetUI.GetComponent<RectTransform>().localScale = Vector3.one;
    }

    //windowを非アクティブにせず、消すコルーチン
    public static IEnumerator smallAndSmallActive(GameObject targetUI)
    {
        targetUI.GetComponent<RectTransform>().localScale = Vector3.one;
        for (float i = 1.0f; i >= 0.5f; i -= 0.1f)
        {
            targetUI.GetComponent<RectTransform>().localScale = new Vector3(i, i, i);
            yield return new WaitForSeconds(0.01f);
        }
        //targetUI.SetActive(false);
        targetUI.GetComponent<RectTransform>().localScale = Vector3.zero;
    }

    //ポジティブな音
    public static void playPositiveSound()
    {
        GameObject tempObject = GameObject.FindWithTag("mainCtrl");
        Main tempMain = tempObject.GetComponent<Main>();
        tempMain.SoundEffectSource.PlayOneShot(tempMain.sound.positiveClip);
    }

    //ネガティブな音
    public static void playNegativeSound()
    {
        GameObject tempObject = GameObject.FindWithTag("mainCtrl");
        Main tempMain = tempObject.GetComponent<Main>();
        tempMain.SoundEffectSource.PlayOneShot(tempMain.sound.negativeClip);
    }

    //なんでもいい音
    public static void playClip(AudioClip Clip)
    {
        GameObject tempObject = GameObject.FindWithTag("mainCtrl");
        Main tempMain = tempObject.GetComponent<Main>();
        tempMain.SoundEffectSource.PlayOneShot(Clip);
    }

    //
    public static Main GetMain()
    {
        GameObject mainCtrl = GameObject.FindGameObjectWithTag("mainCtrl");
        return mainCtrl.GetComponent<Main>();
    }

    //
    public static IEnumerator EasyForCor(usefuleDelegate dele, int num, float interval)
    {
        for (int i = 0; i < num; i++)
        {
            dele();
            yield return new WaitForSeconds(interval);
        }
    }

    //the difference of Datetime to float
    public static float DeltaTimeFloat(DateTime DT)
    {
        if(DT == null)
        {
            return 0;
        }

        float ans = ((float)DateTime.Now.Subtract(DT).Seconds
            + DateTime.Now.Subtract(DT).Minutes * 60
            + DateTime.Now.Subtract(DT).Hours * 3600
            + DateTime.Now.Subtract(DT).Days * 86400);

        if(ans >= 0)
        {
            return ans;
        }
        else
        {
            return 0;
        }
    }

    public static string DoubleTimeToDate(double Time, bool CoronMode = false)
    {
        int Day = 0;
        int Hour = 0;
        int Minute = 0;
        int Second = 0;
        string DayString = "";
        string HourString = "";
        string MinuteString = "";
        string SecondString = "";

        Day = (int)Math.Floor(Time / 86400);
        Hour = (int)Math.Floor((Time % 86400) / 3600);
        Minute = (int)Math.Floor((Time % 3600) / 60);
        Second = (int)Math.Floor((Time % 60));

        if (CoronMode)
        {
            Hour = (int)Math.Floor(Time / 3600);
            Minute = (int)Math.Floor((Time % 3600) / 60);
            Second = (int)Math.Floor((Time % 60));
            if (Hour > 0) { HourString = Hour.ToString("D2") + ":"; }
            MinuteString = Minute.ToString("D2") + ":";
            SecondString = Second.ToString("D2");
        }
        else
        {
            Day = (int)Math.Floor(Time / 86400);
            Hour = (int)Math.Floor((Time % 86400) / 3600);
            Minute = (int)Math.Floor((Time % 3600) / 60);
            Second = (int)Math.Floor((Time % 60));
            if (Day > 0) { DayString = Day.ToString() + "d"; }
            if (Hour > 0) { HourString = Hour.ToString() + "h"; }
            if (Minute > 0) { MinuteString = Minute.ToString() + "m"; }
            if (Second > 0) { SecondString = Second.ToString() + "s"; }
        }

        return DayString + HourString + MinuteString + SecondString;
    }

    public static float Pdf_Ed(double Ramda, double X)
    {
        return 1.0f - (float)Math.Pow(Math.E, (-1 * Ramda * X));
    }

    public static double ZC(double number)//ZC stands for "Zero Check";
    {
        return Math.Max(0.000000001, number);
    }

    public static double Domain(double Value, double Max, double Min)
    {
        double tempDouble = 0;
        //tempDouble = Math.Max(Value, Min);
        //tempDouble = Math.Min(Value, Max);
        tempDouble = Value <= Min ? Min : Value;
        tempDouble = Value >= Max ? Max : Value;
        return tempDouble;
    }

    //public static double LogNormalDistribution(double Mode,double Mean)
    //{
    //    return (LogNormal.Sample(1d / 3d * Math.Log(Mean * Mean * Mode), Math.Sqrt(2d / 3d * Math.Log(Mean / Mode))));
    //}


    /// <summary>
    /// Componentを全探索するので重い。
    /// 指定されたインターフェイスを実装したコンポーネントのリストを返す
    /// </summary>
    public static List<Component> FindObjectsOfInterface<T>() where T : class
    {
        var list = new List<Component>();
        foreach (var n in FindObjectsOfType<Component>())
        {
            var Interface = n as T;
            if (Interface != null)
            {
                list.Add(n);
            }
        }
        return list;
    }


    public static bool isRange(float range, GameObject targetObject, GameObject homeObject)
    {
        if (homeObject.GetComponent<RectTransform>().anchoredPosition.x > targetObject.GetComponent<RectTransform>().anchoredPosition.x - range
                    && homeObject.GetComponent<RectTransform>().anchoredPosition.x < targetObject.GetComponent<RectTransform>().anchoredPosition.x + range
                     && homeObject.GetComponent<RectTransform>().anchoredPosition.y > targetObject.GetComponent<RectTransform>().anchoredPosition.y - range
                    && homeObject.GetComponent<RectTransform>().anchoredPosition.y < targetObject.GetComponent<RectTransform>().anchoredPosition.y + range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool isRange(float range, Vector2 targetObject, GameObject homeObject)
    {
        if (homeObject.GetComponent<RectTransform>().anchoredPosition.x > targetObject.x - range
                    && homeObject.GetComponent<RectTransform>().anchoredPosition.x < targetObject.x + range
                     && homeObject.GetComponent<RectTransform>().anchoredPosition.y > targetObject.y - range
                    && homeObject.GetComponent<RectTransform>().anchoredPosition.y < targetObject.y + range)
        {
            return true;
        }
        else
        {
            return false;

        }
    }



    public static bool isRange(float range, Vector2 targetObject, Vector2 homeObject)
    {
        if (homeObject.x > targetObject.x - range
                    && homeObject.x < targetObject.x + range
                     && homeObject.y > targetObject.y - range
                    && homeObject.y < targetObject.y + range)
        {
            return true;
        }
        else
        {
            return false;

        }
    }


    /// <summary>
    /// delegateに代入して使うと、引数なしで第一引数の値がそのまま出力され、引数ありで第二引数が第一引数に代入される。
    /// </summary>
    public static Type Sync<Type>(ref Type Value, Type? Sub = null)
        where Type : struct
    {
        if (Sub == null)
        {
            return Value;
        }
        else
        {
            Value = (Type)Sub;
            return Value;
        }
    }

    /// <summary>
    /// 配列のサイズが第二引数のものと違ったら合わせる関数
    /// </summary>
    public static void InitializeArray<Type>(ref Type[] Obj, int Length)
    {
        if (Obj == null) { Obj = new Type[0]; }
        if (Obj.Length != Length)
        {
            Array.Resize(ref Obj, Length);
        }
    }

    public static void InstantiateIdle(Component IdleUnit, Transform Parent)
    {
        Component instaComponent;
        instaComponent = Instantiate(IdleUnit, Parent);
        if (IdleUnit is IIdleAction)
        {
            GetMain().idleActionCtrl.Add(instaComponent);
        }
    }

    // Use this for initialization
    void Start()
    {
        window = Instantiate(windowPre, windowTransform);
        window.name = "debaggudayo";
    }
    // Update is called once per frame
    void Update()
    {
        if (window != null)
        {
            if (Input.mousePosition.y >= 360 && Input.mousePosition.x >= 540)
            {
                window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition + new Vector3(-250.0f, -50.0f);
            }
            else if (Input.mousePosition.y >= 360 && Input.mousePosition.x < 540)
            {
                window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition + new Vector3(50.0f, -50.0f);
            }
            else if (Input.mousePosition.y < 360 && Input.mousePosition.x > 540)
            {
                window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition + new Vector3(-250.0f, -50.0f);
            }
            else if (Input.mousePosition.y < 360 && Input.mousePosition.x < 540)
            {
                window.GetComponent<RectTransform>().anchoredPosition = Input.mousePosition + new Vector3(50.0f, 50.0f);
            }
        }
    }
}