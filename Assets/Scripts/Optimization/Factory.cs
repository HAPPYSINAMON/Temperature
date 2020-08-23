using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory
{
    List<RecycleObject> pool = new List<RecycleObject>();
    int defaultPoolSize;
    /// <summary>
    /// 재활용할 Prefab
    /// </summary>
    RecycleObject prefab;

    public Factory(RecycleObject prefab, int defaultPoolSize = 5)
    {
        this.prefab = prefab;
        this.defaultPoolSize = defaultPoolSize;
    }

    /// <summary>
    /// Prefab 오브젝트풀에 추가
    /// </summary>
    void CreatePool()
    {
        for (int i = 0; i < defaultPoolSize; i++)
        {
            RecycleObject obj = GameObject.Instantiate(prefab) as RecycleObject;
            obj.gameObject.SetActive(false);
            pool.Add(obj);
        }
    }

    /// <summary>
    /// Prefab 가져오기
    /// </summary>
    /// <returns></returns>
    public RecycleObject Get()
    {
        if (pool.Count == 0)
        {
            CreatePool();
        }

        int lastIndex = pool.Count - 1;
        RecycleObject obj = pool[lastIndex];
        pool.RemoveAt(lastIndex);
        obj.gameObject.SetActive(true);

        return obj;
    }

    /// <summary>
    /// Prefab 반납
    /// </summary>
    /// <param name="obj"> 반납할 Prefab</param>
    public void Restore(RecycleObject obj)
    {
        obj.gameObject.SetActive(false);
        pool.Add(obj);
    }
}
