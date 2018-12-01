using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class PlayerStatsTest
{
    private bool GameOver = false;

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

    [UnityTest]
    public IEnumerator TakingDamageWorks()
    {
        //Arrange
        PlayerStats testPlayer = new GameObject().AddComponent<PlayerStats>();
        IntReference MaxHP = new IntReference();
        IntReference HP = new IntReference();
        testPlayer.Construct(MaxHP, HP);

        //Act
        MaxHP.Value = 100;
        testPlayer.InitializeFullHealth();
        testPlayer.TakeDamage(58);

        yield return null;

        //Assert
        Assert.AreEqual(42, HP.Value);
    }

    [UnityTest]
    public IEnumerator GameLossEventWorks()
    {
        //Arrange

        //Construct the player
        PlayerStats testPlayer = new GameObject().AddComponent<PlayerStats>();
        IntReference MaxHP = new IntReference();
        IntReference HP = new IntReference();
        testPlayer.Construct(MaxHP, HP);
        MaxHP.Value = 50;
        testPlayer.InitializeFullHealth();

        //Construct the Event
        GameEvent gameLoss = ScriptableObject.CreateInstance<GameEvent>();

        //Set the player's event to the new event
        testPlayer.Lose = gameLoss;

        //Construct the Event Listener
        GameEventListener lossChecker = new GameObject().AddComponent<GameEventListener>();
        lossChecker.response = new UnityEngine.Events.UnityEvent();
        lossChecker.response.AddListener(() => { GameOver = true; });

        //Register the listener to the event
        gameLoss.RegisterListener(lossChecker);

        //Act
        testPlayer.TakeDamage(50);
        yield return null;

        //Assert
        Assert.AreEqual(true, GameOver);
    }

    [TearDown]
    public void AfterEachTest()
    {
        GameOver = false;
    }
}
