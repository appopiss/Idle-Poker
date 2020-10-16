using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System.Linq;

namespace Tests
{
    public class ReloadTest
    {
        List<Tramp> tramps = new List<Tramp>();
        // A Test behaves as an ordinary method
        [Test]

        
        public void ReloadTestSimplePasses()
        {
            
            // Use the Assert class to test conditions
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    tramps.Add(new Tramp((Mark)i, (Number)j, null));
                    tramps[i * 13 + j].backSprite = null;
                }
            }

            List<Tramp> error = new List<Tramp>();
            error.Add(tramps[0]);
            error.Add(tramps[0]);
            error.Add(tramps[0]);
            error.Add(tramps[0]);
            error.Add(tramps[0]);

            for (int i = 0; i < 10000; i++)
            {
                Debug.Log(TrueAmount(error));
               // Debug.Log(TrueAmount(ShowChosenTramp()));
                //Assert.AreEqual(5, TrueAmount(ShowChosenTramp()));
            }
            
        }
        List<Tramp> ShowChosenTramp()
        {
            //使った数字を記録していく
            List<int> UsedNumbers = new List<int>();
            List<Tramp> ResultTramps = new List<Tramp>();
            for (int i = 0; i < 5; i++)
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

        int TrueAmount(List<Tramp> tramps)
        {
            return tramps.Distinct().ToList().Count;
           
        }

        /*string ResultToString(List<Tramp> tramps)
        {
            return string.Join("     ", tramps);
            
        }*/

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator ReloadTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}
