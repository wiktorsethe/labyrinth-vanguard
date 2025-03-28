using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] private int amountToPool;
    [SerializeField] private GameObject objPrefab;

    private void Start()
    {
        for(int i=0; i<amountToPool; i++)
        {
            GameObject obj = Instantiate(objPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i=0; i<pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }
}
