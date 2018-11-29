using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class WinScreenTest
{
    [UnityTest]
    public IEnumerator TestWinScreen()
    {
        //Arrange
        PlayerWin playerWin = new GameObject().AddComponent<PlayerWin>();
        GameObject testChild = new GameObject();
        testChild.transform.SetParent(playerWin.transform);
        testChild.SetActive(false);

        //Act
        playerWin.Win();

        yield return null;

        Assert.AreEqual(true, testChild.activeInHierarchy);
        Assert.AreEqual(0, Time.timeScale);
    }
}
