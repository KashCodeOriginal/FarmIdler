using Infrastructure.Factory.Model;
using UnityEngine;

namespace Infrastructure.Factory.AbstractFactory
{
    public interface IAbstractFactory : IAbstractFactoryInfo, IFactory
    {
        public GameObject CreateInstance(GameObject prefab, Vector3 spawnPoint);
    }
}

