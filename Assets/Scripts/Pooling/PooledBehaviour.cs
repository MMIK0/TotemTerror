using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PooledBehaviour : MonoBehaviour
{
    public int ID;
    public int poolGrowthAmount=1;
    public delegate void ReturnToPool(PooledBehaviour pooledBoi);
    public ReturnToPool OnReturnToPool;


    private void OnValidate()
    {
        if (ID == 0)
            ID = gameObject.GetInstanceID();
    }

    private void OnDisable()
    {
        OnReturnToPool.Invoke(this);
    }
    private void OnLevelWasLoaded(int level)
    {
        gameObject.SetActive(false);
    }
    public PooledBehaviour GetPooledObject()
    {
        Pool pool = Pool.GetOrCreatePool(this);
        PooledBehaviour pooledObject = pool.GetObjectFromPool();
        pooledObject.gameObject.SetActive(true);
        return pooledObject;
    }
    public PooledBehaviour GetPooledObject(Vector3 position)
    {
        PooledBehaviour pooledObject = GetPooledObject();
        pooledObject.transform.position = position;
        return pooledObject;
    }
    public void ReturnToPoolWithMagic()
    {
        gameObject.SetActive(false);
    }
}
