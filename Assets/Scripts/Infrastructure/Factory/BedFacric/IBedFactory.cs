using System.Threading.Tasks;
using UnityEngine;

public interface IBedFactory : IBedFactoryInfo
{
    public Task<GameObject> CreateInstance(Vector3 spawnPoint);
    public void DestroyInstance(GameObject instance);
    public void DestroyAllInstances();
}