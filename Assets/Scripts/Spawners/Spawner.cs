using System.Collections;
using UnityEngine;
using UnityEngine.Pool;


public class Spawner<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;

    protected ObjectPool<T> Pool;

    protected virtual void Awake()
    {
        Pool = new ObjectPool<T>(
            createFunc: () => OnInstantiate(),
            actionOnGet: (pooledObject) => OnGet(pooledObject),
            actionOnRelease: (pooledObject) => OnRelease(pooledObject),
            actionOnDestroy: (pooledObejct) => OnDestroyObject(pooledObejct)
            );
    }

    protected virtual T OnInstantiate()
    {
        T newObject = Instantiate(_prefab);

        return newObject;
    }

    protected virtual void OnGet(T pooledObject)
    {
        pooledObject.gameObject.SetActive(true);
    }

    protected virtual void OnRelease(T pooledObject)
    {
        pooledObject?.gameObject.SetActive(false);
    }

    protected virtual void OnDestroyObject(T pooledObject)
    {
        Destroy(pooledObject);
    }

    protected virtual void Release(T pooledObject)
    {
        Pool.Release(pooledObject);
    }
}