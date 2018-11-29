using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class LoseScreenTest
{
    [UnityTest]
    public IEnumerator TestLoseScreen()
    {
        //Arrange
        PlayerLose playerLose = new GameObject().AddComponent<PlayerLose>();
        GameObject testChild = new GameObject();
        testChild.transform.SetParent(playerLose.transform);
        testChild.SetActive(false);

        //Act
        playerLose.Lose();

        yield return null;

        Assert.AreEqual(true, testChild.activeInHierarchy);
        Assert.AreEqual(0, Time.timeScale);
    }
}
