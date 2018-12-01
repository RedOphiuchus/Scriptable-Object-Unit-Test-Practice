using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class KillCounterTest
{
    bool GameWon = false;

    [UnityTest]
    public IEnumerator KillCountIncrementTest()
    {
        //Arrange
        KillCounter testKC = new GameObject().AddComponent<KillCounter>();
        IntReference killCount = new IntReference();
        testKC.goal = int.MaxValue;
        testKC.kills = killCount;
        GameObject firstChild = new GameObject();
        Text killDisplay = new GameObject().AddComponent<Text>();
        firstChild.transform.SetParent(testKC.transform);
        killDisplay.transform.SetParent(testKC.transform);

        //Act
        testKC.incrementKillCount();

        yield return null;

        //Assert
        Assert.AreEqual(1, killCount.Value);
        Assert.AreEqual("1", killDisplay.text);

    }

    [UnityTest]
    public IEnumerator GameWinTest()
    {
        //Arrange
        KillCounter testKC = new GameObject().AddComponent<KillCounter>();
        IntReference killCount = new IntReference();
        testKC.goal = 1;
        testKC.kills = killCount;
        GameObject firstChild = new GameObject();
        Text killDisplay = new GameObject().AddComponent<Text>();
        GameEvent Win = ScriptableObject.CreateInstance<GameEvent>();
        testKC.Win = Win;
        GameEventListener winListen = new GameObject().AddComponent<GameEventListener>();
        winListen.response = new UnityEngine.Events.UnityEvent();
        winListen.response.AddListener(() => { GameWon = true; });
        Win.RegisterListener(winListen);
        firstChild.transform.SetParent(testKC.transform);
        killDisplay.transform.SetParent(testKC.transform);

        //Act
        testKC.incrementKillCount();

        yield return null;

        //Assert
        Assert.AreEqual(true, GameWon);
    }

    [TearDown]
    public void AfterEachTest()
    {
        GameWon = false;
    }
}
