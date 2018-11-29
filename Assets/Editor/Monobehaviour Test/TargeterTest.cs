using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class TargeterTest
{
    [UnityTest]
    public IEnumerator TargetFoundTest()
    {
        //Arrange

        //Set up the Targeter
        Targeter testTargeter = new GameObject().AddComponent<Targeter>();
        testTargeter.gameObject.AddComponent<GameEventListener>();
        BoolReference isTargeting = new BoolReference();
        isTargeting.Value = false;
        IntReference targetHP = new IntReference();
        IntReference targetMaxHP = new IntReference();
        testTargeter.isTargeting = isTargeting;
        testTargeter.targetHP = targetHP;
        testTargeter.targetMaxHP = targetMaxHP;

        //Set up the target
        MonoBehaviour[] Potentials = new MonoBehaviour[1];
        EnemyBehaviour target = new GameObject().AddComponent<EnemyBehaviour>(); //Enemy Behaviour is a Mono Behaviour that impliments ITargetable
        target.attackSpeed = new FloatReference();
        target.maxHP = new IntReference();
        target.damage = new IntReference();
        target.enemyObjectPool = ScriptableObject.CreateInstance<ObjectPool>();
        target.MakeDamageEvent();
        target.onDeath = ScriptableObject.CreateInstance<GameEvent>();
        Potentials[0] = target;

        //Act
        testTargeter.SetTestBehaviours(Potentials);
        testTargeter.SetTarget();

        yield return null;

        testTargeter.UpdateBar();

        //Assert
        Assert.AreEqual(true, isTargeting.Value);
    }

    [UnityTest]
    public IEnumerator TargetNotFoundTest()
    {
        //Arrange

        //Set up the Targeter
        Targeter testTargeter = new GameObject().AddComponent<Targeter>();
        testTargeter.gameObject.AddComponent<GameEventListener>();
        BoolReference isTargeting = new BoolReference();
        isTargeting.Value = false;
        IntReference targetHP = new IntReference();
        IntReference targetMaxHP = new IntReference();
        testTargeter.isTargeting = isTargeting;
        testTargeter.targetHP = targetHP;
        testTargeter.targetMaxHP = targetMaxHP;

        MonoBehaviour[] Potentials = new MonoBehaviour[1];
        Potentials[0] = testTargeter;

        //Act
        testTargeter.SetTestBehaviours(Potentials);
        testTargeter.SetTarget();
        testTargeter.UpdateBar();

        yield return null;

        //Assert
        Assert.AreEqual(false, isTargeting.Value);

    }
}
