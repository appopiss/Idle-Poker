using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ReloadTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ReloadTestSimplePasses()
        {
            List<Tramp> tramps = new List<Tramp>();
            // Use the Assert class to test conditions
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    tramps.Add(new Tramp((Mark)i, (Number)j, null));
                    tramps[i * 13 + j].backSprite = null;
                }
            }
        }

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
