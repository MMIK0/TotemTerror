using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    public static Dictionary<int, Pool> availablePools = new Dictionary<int, Pool>();
    PooledBehaviour pooledPrefab;
    private Queue<PooledBehaviour> pooledObjects = new Queue<PooledBehaviour>();

    public static Pool GetOrCreatePool(PooledBehaviour poolObject)
    {
        if (availablePools.ContainsKey(poolObject.ID))
            return availablePools[poolObject.ID];

        GameObject newPool = new GameObject();
        newPool.name = "Pool -- " + poolObject.name;
        Pool pool = newPool.AddComponent<Pool>();
        pool.pooledPrefab = poolObject;
        availablePools.Add(poolObject.ID, pool);
        return pool;
    }

    public PooledBehaviour GetObjectFromPool()
    {
        if (pooledObjects.Count < 1)
            ExpandPool();
        return pooledObjects.Dequeue();

    }
    private void ExpandPool()
    {
        for(int i = 0; i < pooledPrefab.poolGrowthAmount; i++)
        {
            PooledBehaviour newObject = Instantiate(pooledPrefab);
            newObject.OnReturnToPool += AddToObjectQueue;
            if(!newObject.gameObject.activeInHierarchy)//wierd work around so that you can pool disbled prefabs
                newObject.gameObject.SetActive(true);
            newObject.gameObject.SetActive(false);
        }
    }
    void AddToObjectQueue(PooledBehaviour pObject)
    {
        pooledObjects.Enqueue(pObject);
        StartCoroutine(SetPoolAsParent(pObject));
    }
    IEnumerator SetPoolAsParent(PooledBehaviour pooledBehaviour)
    {
        yield return new WaitForEndOfFrame();
        pooledBehaviour.gameObject.transform.SetParent(transform);
    }
}
