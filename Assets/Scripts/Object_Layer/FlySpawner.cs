using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class FlySpawner : MonoBehaviour, IObjectFactory<GameObject>
{
    [Header("Fly Prefab")]
    [SerializeField] private GameObject flyPrefab;

    [Header("Object Pool")]
    [SerializeField] private int initialPoolSize = 10;
    [SerializeField] private int maxPoolSize = 50;
    [SerializeField] private bool allowPoolExpansion = true;
    private PoolStats poolStats;
    private List<GameObject> flyPool;

    [Header("Default Configuration")]
    public Transform defaultPivot;

    private void Start()
    {
        // Validate required components
        if (flyPrefab == null)
        {
            Debug.LogError("FlySpawner: Fly prefab is not assigned!");
            return;
        }

        if (defaultPivot == null)
        {
            Debug.LogWarning("FlySpawner: No default pivot assigned. Using spawner transform as pivot.");
            defaultPivot = transform;
        }
        poolStats = new PoolStats(0, 0, maxPoolSize);
        // Initialize the object pool
        InitializePool();
    }

    private void InitializePool()
    {
        flyPool = new List<GameObject>();
        for (int i = 0; i < initialPoolSize; i++)
        {
            CreatePooledFly();
        }
    }

    private GameObject CreatePooledFly()
    {
        GameObject flyInstance = Instantiate(flyPrefab, transform);
        flyInstance.gameObject.SetActive(false);
        flyPool.Add(flyInstance);
        poolStats.totalObjects++;
        return flyInstance;
    }

    // Implementation of IObjectFactory methods
    public PoolStats GetPoolStats()
    {
        return poolStats;
    }

    public async Task<GameObject> SpawnObject()
    {
        // Check for available flies in the pool
        GameObject flyObject = flyPool.FirstOrDefault(pooledFly => !pooledFly.gameObject.activeInHierarchy);
        if (flyObject == null)
        {
            if (allowPoolExpansion && flyPool.Count < maxPoolSize)
            {
                flyObject = CreatePooledFly();
                await Task.Yield(); // Ensure the object is fully initialized before use
            }
            else
            {
                Debug.LogWarning("FlySpawner: No available flies in the pool and expansion is not allowed or max size reached.");
                return null;
            }
        }
        flyObject.gameObject.SetActive(true);
        Fly flyScript = flyObject.GetComponent<Fly>();
        flyScript.StartMoving(defaultPivot);
        poolStats.activeObjects++;
        return flyObject;
    }

    public void RecycleObject(GameObject fly)
    {
        fly.GetComponent<Fly>().StopMoving();
        fly.gameObject.SetActive(false);
        poolStats.activeObjects--;
    }

    public void ResetFlyPool()
    {
        foreach (GameObject fly in flyPool)
        {
            Destroy(fly.gameObject);
        }
        flyPool.Clear();
        poolStats.activeObjects = 0;
        poolStats.totalObjects = 0;
        InitializePool();
    }

    /// Cleanup when the spawner is destroyed
    private void OnDestroy()
    {
        ResetFlyPool();
    }

    // Debugging methods to test spawning and resetting the pool
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetFlyPool();
            Debug.Log("Fly pool has been reset.");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            TestSpawn();
            Debug.Log("Spawned a fly object.");
        }
    }
    private async void TestSpawn()
    {
        GameObject obj = await SpawnObject();
    }
}
