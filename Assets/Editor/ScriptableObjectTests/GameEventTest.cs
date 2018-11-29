using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class GameEventTest
{
    bool eventInvoked = false;
    int testInt = 0;

    public void testFnc()
    {
        eventInvoked = true;
    }

    public void testIntFnc(int val)
    {
        testInt = val;
    }

    [UnityTest]
    public IEnumerator GameEventRaiseTest()
    {
        //Arrange
        GameEvent testEvent = ScriptableObject.CreateInstance<GameEvent>();
        GameEventListener testListener = new GameObject().AddComponent<GameEventListener>();
        testEvent.RegisterListener(testListener);
        //response is usually created by editor
        testListener.response = new UnityEngine.Events.UnityEvent();
        testListener.response.AddListener(testFnc);

        //Act
        testEvent.Raise();

        yield return null;

        //Assert
        Assert.AreEqual(true, eventInvoked);
    }

    [UnityTest]
    public IEnumerator GameEventIntRaiseTest()
    {
        //Arrange
        GameEvent testEvent = ScriptableObject.CreateInstance<GameEvent>();
        GameEventListener testListener = new GameObject().AddComponent<GameEventListener>();
        testEvent.RegisterListener(testListener);
        //intResponse is usually created by editor
        testListener.intResponse = new IntEvent();
        testListener.intResponse.AddListener(testIntFnc);

        //Act
        testEvent.Raise(42);

        yield return null;

        //Assert
        Assert.AreEqual(42, testInt);
    }

    [UnityTest]
    public IEnumerator GameEventListenerRemoveTest()
    {
        //Arrange
        GameEvent testEvent = ScriptableObject.CreateInstance<GameEvent>();
        GameEventListener testListener = new GameObject().AddComponent<GameEventListener>();
        testEvent.RegisterListener(testListener);
        //response is usually created by the editor
        testListener.response = new UnityEngine.Events.UnityEvent();
        testListener.response.AddListener(testFnc);
        testListener.gameEvent = testEvent;

        //Act 
        //I believe the OnDisabled callback doesn't run in
        //edit mode tests so we're just going to directly
        //Unregister the listener here.
        //testListener.gameObject.SetActive(false);
        //testListener.enabled = false;
        testEvent.UnRegisterListener(testListener);
        
        yield return null;

        testEvent.Raise();

        yield return null;

        //Assert
        Assert.AreEqual(false, eventInvoked);
    }

    [TearDown]
    public void AfterEachTest()
    {
        eventInvoked = false;
        testInt = 0;
    }
}
