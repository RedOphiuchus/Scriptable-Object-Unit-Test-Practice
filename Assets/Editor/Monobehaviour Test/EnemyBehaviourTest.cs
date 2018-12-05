using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class EnemyBehaviourTest
{
    [UnityTest]
    public IEnumerator ColorChangeTest()
    {
        //Arrange
        EnemyBehaviour testEB = new GameObject().AddComponent<EnemyBehaviour>();
        testEB.gameObject.AddComponent<MeshRenderer>();
        Material testMat = new Material(Shader.Find("Standard"));
        testEB.GetComponent<Renderer>().material = testMat;
        IntReference maxHP = new IntReference();
        IntReference damage = new IntReference();
        testEB.MakeDamageEvent();
        GameEvent deathEvent = ScriptableObject.CreateInstance<GameEvent>();
        testEB.onDeath = deathEvent;
        testEB.maxHP = maxHP;
        testEB.damage = damage;

        //Act
        testEB.Flash();
        yield return null;

        //Assert
        Assert.AreEqual(Color.red, testEB.GetComponent<MeshRenderer>().material.color);
    }
}
