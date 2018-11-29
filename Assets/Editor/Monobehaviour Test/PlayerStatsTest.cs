using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class PlayerStatsTest
{
    [UnityTest]
    public IEnumerator MaxHealthTest()
    {
        //Arrange
        PlayerStats testPlayer = new GameObject().AddComponent<PlayerStats>();
        IntReference MaxHP = new IntReference();
        IntReference HP = new IntReference();
        testPlayer.Construct(MaxHP, HP);

        //Act
        MaxHP.Value = 100;
        testPlayer.InitializeFullHealth();
        yield return null;

        //Assert
        Assert.AreEqual(MaxHP.Value, HP.Value);
    }
}
