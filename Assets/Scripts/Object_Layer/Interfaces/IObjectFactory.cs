using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Generic factory interface for object creation and management
/// </summary>
/// <typeparam name="T">The type of object this factory creates</typeparam>
public interface IObjectFactory<T>
{
    PoolStats GetPoolStats();
    Task<T> SpawnObject();
    void RecycleObject(T obj);
    void ResetFlyPool();
}

public struct PoolStats
{
    public int totalObjects;
    public int activeObjects;
    public int maxPoolSize;

    public PoolStats(int total, int active, int maxSize)
    {
        totalObjects = total;
        activeObjects = active;
        maxPoolSize = maxSize;
    }
    public int GetAvailableCount()
    {
        return totalObjects - activeObjects;
    }
}
