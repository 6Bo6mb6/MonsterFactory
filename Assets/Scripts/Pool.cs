using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class Pool<T> where T : MonoBehaviour
{
    public T Prefab { get; private set; }
    public bool AutoExpand { get; set; }
    public Transform Container { get; }

    private List<T> _pool;

    public Pool(T prefab, int count) 
    {
        Prefab = prefab;
        Container = null;
    }

    public Pool(T prefab, int count, Transform container)
    {
        Prefab = prefab;
        Container = container;

        CreatePool(count);
    }

    public bool HasFreeElement(out T element) 
    {
        foreach (var mono in _pool) 
        {
            if (!mono.gameObject.activeInHierarchy) 
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement() 
    {
        if (HasFreeElement(out var element))
            return element;

        if (AutoExpand)
           return CreateObject(true);

        throw new Exception($"There is no free element in pool of type{typeof(T)}");
    }

    private void CreatePool(int count) 
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++) 
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isAtiveByDefault = false) 
    {
        var createdObject = Object.Instantiate(Prefab, Container);
        createdObject.gameObject.SetActive(isAtiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }

}
