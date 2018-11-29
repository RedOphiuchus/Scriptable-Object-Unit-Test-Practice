using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class BooleanVariableAndReferenceTest {

	[TestCase(true)]
    [TestCase(false)]
    public void BooleanVariableCreationAndAccessTest(bool value)
    {
        //Arrange
        BoolVariable testBool = ScriptableObject.CreateInstance<BoolVariable>();

        //Act
        testBool.value = value;

        //Assert
        Assert.AreEqual(value, testBool.value);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void BooleanReferenceConstantValueTest(bool value)
    {
        //Arrange
        BoolReference testBool = new BoolReference();

        //Act
        testBool.Value = value;

        //Assert
        Assert.AreEqual(value, testBool.Value);
    }

    [TestCase(true)]
    [TestCase(false)]
    public void BooleanReferenceBoolVariableValueTest(bool value)
    {
        //Arrange
        BoolReference testBool = new BoolReference(ScriptableObject.CreateInstance<BoolVariable>());

        //Act
        testBool.Value = value;

        //Assert
        Assert.AreEqual(value, testBool.Value);
    }
}
