using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using static UsefulMethod;

public enum Hand
{
    RoyalFlush,
    StraightFlush,
    FourOfAKind,
    AFullHouse,
    Flush,
    Straight,
    ThreeOfAKind,
    TwoPair,
    APair,
    Nothing
}
public class Judge {
   
    public static int[] alignmentNum(List<Tramp> hands)
    {
        int[] newHands = new int[hands.Count];
        for (int i = 0; i < hands.Count; i++)
        {
            newHands[i] = (int)hands[i].number;
        }
        bool IsChange = true;
        while (IsChange)
        {
            IsChange = false;
            for (int i = 0; i < newHands.Length - 1; i++)
            {
                if (newHands[i] < newHands[i+1])
                {
                    int tempNum = newHands[i];
                    newHands[i] = newHands[i + 1];
                    newHands[i + 1] = tempNum;
                    IsChange = true;
                }

            }
        }
        return newHands;
    }

    public static int[] KindsNum(List<Tramp> hands)
    {

        List<int> kindsNum = new List<int>();
        int count = 1;
        int[] tempArray =  alignmentNum(hands);
        int[] newHands = new int[] { 0, 0, 0, 0, 0, -1 };
        for (int i = 0; i < tempArray.Length; i++)
        {
            newHands[i] = tempArray[i];
        }
        for (int i = 0; i < newHands.Length - 1; i++)
        {
            if(newHands[i] == newHands[i + 1])
            {
                count++;
            }
            else
            {
                kindsNum.Add(count);
                count = 1;
            }
        }
        return kindsNum.ToArray();
    }

    static bool IsStraight(List<Tramp> hands)
    {
        int[] numbers = alignmentNum(hands);
        //Aから始まる時
        if(numbers[0] == (int)Number.A &&
           numbers[1] == (int)Number.five &&
           numbers[2] == (int)Number.four &&
           numbers[3] == (int)Number.three &&
           numbers[4] == (int)Number.two
            )
        {
            return true; 
        }

        //それ以外の時
        bool isStraight = true;
        for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] - 1 != numbers[i + 1])
                {
                    isStraight = false;
                    break;
                }
            }

         return isStraight;
    }

    static bool Isflush(List<Tramp> hands)
    {
        bool isflush = true;
        for (int i = 0; i < hands.Count - 1; i++)
        {
            if(hands[i].markId != hands[i + 1].markId)
            {
                isflush = false;
            }
        }
        return isflush;
    }

    static int Max(int[] hands)
    {
        int maxNum = 0;
        for (int i = 0; i < hands.Length; i++)
        {
            if(hands[i] > maxNum)
            {
                maxNum = hands[i];
            }
                
        }
        return maxNum;
    }

    static int Min(int[] hands)
    {
        int minNum = 9999;
        for (int i = 0; i < hands.Length; i++)
        {
            if (hands[i] < minNum)
            {
                minNum = hands[i];
            }

        }
        return minNum;
    }

    static bool IsRoyalStraightFlush(List<Tramp> hands)
    {
        return 
        IsStraight(hands) &&
        Isflush(hands) &&
        Max(alignmentNum(hands)) == (int)Number.A &&
        Min(alignmentNum(hands)) == (int)Number.ten;
    }

    static bool IsStraightFrash(List<Tramp> hands)
    {
        return
        IsStraight(hands) &&
        Isflush(hands);
    }


    public static ROLE JudgeHand(List<Tramp> hands)
    {
        if (KindsNum(hands).Length == 5)
        {
            if (IsRoyalStraightFlush(hands))
            {
                Debug.Log("Royal Flush!!!");
                return new NULL_ROLL();
            }

            else if (IsStraightFrash(hands))
            {
                Debug.Log("Straight Flash!!");
                return new NULL_ROLL();
            }

            else if (Isflush(hands))
            {
                Debug.Log("Flush!!");
                return new NULL_ROLL();
            }

            else if (IsStraight(hands))
            {
                Debug.Log("Straight!!");
                return new NULL_ROLL();
            }

            else
            {
                int highCard = Max(alignmentNum(hands));
                return new HighCard(highCard);
            }
        }

        else if(KindsNum(hands).Length == 2)
        {
            if(KindsNum(hands)[0] == 1 || KindsNum(hands)[0] == 4)
            {
                Debug.Log("Four of a kind!!!");
                return new NULL_ROLL();
            }
            else
            {
                Debug.Log("A Full House!!!");
                return new NULL_ROLL();
            }
        }

        else if(KindsNum(hands).Length == 3)
        {
            if(Max(KindsNum(hands)) == 3)
            {
                Debug.Log("Three of a kind!!!");
                return new NULL_ROLL();
            }
            else
            {
                Debug.Log("Two Pair!!!");
                return new NULL_ROLL();
            }
        }

        else
        {
            Debug.Log("A Pair!!!");
            return new NULL_ROLL();
        }

    }
}


