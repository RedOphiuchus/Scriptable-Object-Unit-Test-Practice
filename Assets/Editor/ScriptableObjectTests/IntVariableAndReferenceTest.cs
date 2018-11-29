using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;

public class IntVariableAndReferenceTest {
    [TestCase(0)]
    [TestCase(-200)]
    [TestCase(200)]
    public void IntVariableCreationAndAccessTest(int value)
    {
        //Arrange
        IntVariable testInt = ScriptableObject.CreateInstance<IntVariable>();

        //Act
        testInt.value = value;

        //Assert
        Assert.AreEqual(value, testInt.value);
    }

    [TestCase(100,50,5000, 2, 50, 150, 101, 99)]
    [TestCase(50,100,5000,0,-50,150,51,49)]
    [TestCase(-10,20,-200, 0, -30, 10, -9, -11)]
    [TestCase(-10,-5,50,2,-5,-15,-9,-11)]
    public void IntVariableMathCheck(int op1, int op2, int expMult, int expDiv, int expSub, int expAdd, int expInc, int expDec)
    {
        //Arrange
        IntVariable testInt1 = ScriptableObject.CreateInstance<IntVariable>();
        IntVariable testInt2 = ScriptableObject.CreateInstance<IntVariable>();
        testInt1.value = op1;
        testInt2.value = op2;

        int testMult;
        int testDiv;
        int testSub;
        int testAdd;
        int testInc;
        int testDec;


        //Act
        testMult = testInt1.value * testInt2.value;
        testDiv = testInt1.value / testInt2.value;
        testSub = testInt1.value - testInt2.value;
        testAdd = testInt1.value + testInt2.value;
        testInc = ++testInt1.value;
        testInt1.value = op1;
        testDec = --testInt1.value;

        //Assert
        Assert.AreEqual(expMult, testMult);
        Assert.AreEqual(expDiv, testDiv);
        Assert.AreEqual(expSub, testSub);
        Assert.AreEqual(expAdd, testAdd);
        Assert.AreEqual(expInc, testInc);
        Assert.AreEqual(expDec, testDec);
    }

    [TestCase(0)]
    [TestCase(-5)]
    [TestCase(100)]
    public void IntReferenceConstantValueTest(int value)
    {
        //Arrange
        IntReference testBool = new IntReference();

        //Act
        testBool.Value = value;

        //Assert
        Assert.AreEqual(value, testBool.Value);
    }

    [TestCase(0)]
    [TestCase(-5)]
    [TestCase(100)]
    public void IntReferenceBoolVariableValueTest(int value)
    {
        //Arrange
        IntReference testBool = new IntReference(ScriptableObject.CreateInstance<IntVariable>());

        //Act
        testBool.Value = value;

        //Assert
        Assert.AreEqual(value, testBool.Value);
    }
}
