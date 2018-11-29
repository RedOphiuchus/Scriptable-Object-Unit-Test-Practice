using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class ObjectPoolerTest
{
    [UnityTest]
    public IEnumerator AddToListTest()
    {
        ObjectPool objectPool = ScriptableObject.CreateInstance<ObjectPool>();

        for (int i = 0; i < 3; i++)
        {
            objectPool.Add(new GameObject().AddComponent<EnemyBehaviour>());

            yield return null;

            Assert.AreEqual(i + 1, objectPool.list.Count);
        }
    }

    [UnityTest]
    public IEnumerator SpawnNewWhenFullList()
    {
        ObjectPool objectPool = ScriptableObject.CreateInstance<ObjectPool>();
        objectPool.prefab = new GameObject();
        objectPool.prefab.AddComponent<EnemyBehaviour>();
        objectPool.Direction = new Quaternion(0f, 0f, 0f, 0f);
        objectPool.Location = new Vector3(0f, 0f, 0f);

        for(int i = 0; i < 3; i++)
        {
            objectPool.CreateObject();
        }

        yield return null;

        Assert.AreEqual(3, objectPool.list.Count);
    }

    [UnityTest]
    public IEnumerator ActivateDeactivatedMemberInsteadOfCreateNew()
    {
        ObjectPool objectPool = ScriptableObject.CreateInstance<ObjectPool>();
        objectPool.prefab = new GameObject();
        objectPool.prefab.AddComponent<EnemyBehaviour>();
        objectPool.Direction = new Quaternion(0f, 0f, 0f, 0f);
        objectPool.Location = new Vector3(0f, 0f, 0f);

        objectPool.CreateObject();
        objectPool.list[0].gameObject.SetActive(false);

        yield return null;

        objectPool.CreateObject();

        yield return null;

        Assert.AreEqual(1, objectPool.list.Count);
        Assert.AreEqual(true, objectPool.list[0].isActiveAndEnabled);

    }
}
