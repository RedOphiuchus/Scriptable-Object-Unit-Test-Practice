using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class PlayerAttackTest
{
    [UnityTest]
    public IEnumerator AttackTest()
    {
        //Arrange
        PlayerAttack testAttack = new GameObject().AddComponent<PlayerAttack>();
        IntReference power = new IntReference();
        FloatReference attackSpeed = new FloatReference();
        power.Value = 25;
        testAttack.Construct(power, attackSpeed);

        EnemyBehaviour testEnemy = new GameObject().AddComponent<EnemyBehaviour>();
        testEnemy.MakeDamageEvent();
        IntReference maxEnemyHP = new IntReference();
        testEnemy.maxHP = maxEnemyHP;
        maxEnemyHP.Value = 50;
        testEnemy.FillHP();

        MonoBehaviour[] list = new MonoBehaviour[1];
        list[0] = testEnemy;

        //Act
        testAttack.AttackApplicableBehaviour(list);

        yield return null;

        //Assert
        Assert.AreEqual(25, testEnemy.GetHealth());
    }
	
}
