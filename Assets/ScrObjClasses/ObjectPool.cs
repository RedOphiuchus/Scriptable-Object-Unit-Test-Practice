using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObjectPool : ScriptableObject 
{
	public GameObject prefab;
	public Vector3 Location;
	public Quaternion Direction;
	public List<EnemyBehaviour> list = new List<EnemyBehaviour>();

	public void Add(EnemyBehaviour newObj)
	{
		list.Add(newObj);
	}

	public void Remove(EnemyBehaviour oldObj)
	{
		list.Remove(oldObj);
	}

	public void CreateObject()
	{
		bool created = false;
		for(int i = 0; i < list.Count; i++)
		{
			if (!list[i].gameObject.activeSelf)
			{
				list[i].gameObject.SetActive(true);
				created = true;
				break;
			}
		}
		if(!created)
		{
			GameObject newObject = Instantiate(prefab, Location, Direction);
            Add(newObject.GetComponent<EnemyBehaviour>());
		}
	}

}
