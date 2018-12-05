using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class HealthBarTest
{
    [UnityTest]
    public IEnumerator HealthBarActivateTest()
    {
        //Arrange
        HealthBar HBTest = new GameObject().AddComponent<HealthBar>();
        Image HBImage = new GameObject().AddComponent<Image>();
        HBImage.type = Image.Type.Filled;
        HBImage.transform.SetParent(HBTest.transform);
        IntReference health = new IntReference();
        IntReference maxHealth = new IntReference();
        BoolReference visible = new BoolReference();
        HBTest.health = health;
        HBTest.maxHealth = maxHealth;
        HBTest.active = visible;

        //Act
        visible.Value = true;
        yield return null;
        HBTest.ActivateOrDeactivate();

        //Assert
        Assert.AreEqual(true, HBImage.gameObject.activeInHierarchy);
    }

    [UnityTest]
    public IEnumerator HealthBarDeactivateTest()
    {
        //Arrange
        HealthBar HBTest = new GameObject().AddComponent<HealthBar>();
        Image HBImage = new GameObject().AddComponent<Image>();
        HBImage.type = Image.Type.Filled;
        HBImage.transform.SetParent(HBTest.transform);
        IntReference health = new IntReference();
        IntReference maxHealth = new IntReference();
        BoolReference visible = new BoolReference();
        HBTest.health = health;
        HBTest.maxHealth = maxHealth;
        HBTest.active = visible;

        //Act
        visible.Value = false;
        yield return null;
        HBTest.ActivateOrDeactivate();

        //Assert
        Assert.AreEqual(false, HBImage.gameObject.activeInHierarchy);
    }

    [UnityTest]
    public IEnumerator HealthBarFillTest()
    {
        //Arrange
        HealthBar HBTest = new GameObject().AddComponent<HealthBar>();
        Image HBImage = new GameObject().AddComponent<Image>();
        HBImage.type = Image.Type.Filled;
        HBImage.transform.SetParent(HBTest.transform);
        IntReference health = new IntReference();
        IntReference maxHealth = new IntReference();
        BoolReference visible = new BoolReference();
        HBTest.SetHealthImage();
        HBTest.health = health;
        HBTest.maxHealth = maxHealth;
        HBTest.active = visible;

        //100% hp test

        //Act
        maxHealth.Value = 100;
        health.Value = 100;
        HBTest.UpdateHealthImage();
        yield return null;

        //Assert
        Assert.AreEqual(1f, HBImage.fillAmount);

        //75% hp test

        //Act
        health.Value = 75;
        HBTest.UpdateHealthImage();
        yield return null;

        //Assert
        Assert.AreEqual(.75f, HBImage.fillAmount);

        //0% hp test

        //Act
        health.Value = 0;
        HBTest.UpdateHealthImage();
        yield return null;

        //Assert
        Assert.AreEqual(0f, HBImage.fillAmount);
    }
}
