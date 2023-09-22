using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public GenericDictionary<ObjectType, Pool> objectPools = new GenericDictionary<ObjectType, Pool>();
    public static PoolManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        foreach (var pool in objectPools)
        {
            pool.Value.InitPool(() =>
            {
                var obj = Instantiate(pool.Value.objectPrefabs[UnityEngine.Random.Range(0, pool.Value.objectPrefabs.Count)]);
                if (pool.Value.objectsHolderParent != null) { obj.transform.SetParent(pool.Value.objectsHolderParent); }
                return obj; ;
            },
            obj => { obj.SetActive(true); },
            obj => { obj.SetActive(false); },
            obj => { Destroy(obj); },
            pool.Value.startAmount, 25);

            List<GameObject> tmp = new List<GameObject>();
            foreach (var objPrefab in pool.Value.objectPrefabs)
            {
                for (int i = 0; i < pool.Value.startAmount; i++)
                {
                    tmp.Add(GetFromPool(pool.Key));
                }
            }
            foreach (var element in tmp)
            {
                ReleaseToPool(pool.Key, element);
            }
        }
    }

    public GameObject GetFromPool(ObjectType objectType)
    {
        if (objectPools.TryGetValue(objectType, out Pool returnedPool))
        {
            return returnedPool.objectPool.Get();
        }

        Debug.LogError($"Cannot get an object of type {objectType} from the Pool! Returned null!");
        return null;
    }

    public void ReleaseToPool(ObjectType objectType, GameObject objectToRelease)
    {
        if (objectPools.TryGetValue(objectType, out Pool returnedPool))
        {
            returnedPool.objectPool.Release(objectToRelease);
            return;
        }

        Debug.LogError($"Cannot release an {objectToRelease.name} of type {objectType} back to the Pool!");
    }
}

[System.Serializable]
public class Pool
{
    public List<GameObject> objectPrefabs;
    public Transform objectsHolderParent;
    public int startAmount = 10;

    public ObjectPool<GameObject> objectPool { get; set; }

    public void InitPool(Func<GameObject> createAction, Action<GameObject> onGetAction,
        Action<GameObject> onReleaseAction, Action<GameObject> onDestroyAction, int defaultSize, int maxSize)
    {
        objectPool = new ObjectPool<GameObject>(createAction, onGetAction, onReleaseAction, onDestroyAction, true, defaultSize, maxSize);
    }
}

public enum ObjectType
{
    SQUARE_PROJECTILE
}