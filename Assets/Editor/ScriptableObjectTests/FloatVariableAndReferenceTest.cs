using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class FloatVariableAndReferenceTest
{

    [TestCase(0)]
    [TestCase(-200)]
    [TestCase(200)]
    [TestCase(.005f)]
    [TestCase(1000.05f)]
    public void FloatVariableCreationAndAccessTest(float value)
    {
        //Arrange
        FloatVariable testInt = ScriptableObject.CreateInstance<FloatVariable>();

        //Act
        testInt.value = value;

        //Assert
        Assert.AreEqual(value, testInt.value);
    }

    [TestCase(100, 50, 5000, 2, 50, 150)]
    [TestCase(50, 100, 5000, .5f, -50, 150)]
    [TestCase(-10, 20, -200, -.5f, -30, 10)]
    [TestCase(-10, -5, 50, 2, -5, -15)]
    [TestCase(.5f, 10, 5, .05f, -9.5f, 10.5f)]
    public void IntVariableMathCheck(float op1, float op2, float expMult, float expDiv, float expSub, float expAdd)
    {
        //Arrange
        FloatVariable testInt1 = ScriptableObject.CreateInstance<FloatVariable>();
        FloatVariable testInt2 = ScriptableObject.CreateInstance<FloatVariable>();
        testInt1.value = op1;
        testInt2.value = op2;

        float testMult;
        float testDiv;
        float testSub;
        float testAdd;


        //Act
        testMult = testInt1.value * testInt2.value;
        testDiv = testInt1.value / testInt2.value;
        testSub = testInt1.value - testInt2.value;
        testAdd = testInt1.value + testInt2.value;

        //Assert
        Assert.AreEqual(expMult, testMult);
        Assert.AreEqual(expDiv, testDiv);
        Assert.AreEqual(expSub, testSub);
        Assert.AreEqual(expAdd, testAdd);
    }

    [TestCase(0)]
    [TestCase(-5)]
    [TestCase(100)]
    public void FloatReferenceConstantValueTest(float value)
    {
        //Arrange
        FloatReference testBool = new FloatReference();

        //Act
        testBool.Value = value;

        //Assert
        Assert.AreEqual(value, testBool.Value);
    }

    [TestCase(0)]
    [TestCase(-5)]
    [TestCase(100)]
    public void FloatReferenceBoolVariableValueTest(float value)
    {
        //Arrange
        FloatReference testBool = new FloatReference(ScriptableObject.CreateInstance<FloatVariable>());

        //Act
        testBool.Value = value;

        //Assert
        Assert.AreEqual(value, testBool.Value);
    }
}
