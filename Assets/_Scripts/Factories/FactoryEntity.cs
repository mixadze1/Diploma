using _Scripts.AssetProviders;
using _Scripts.Entities;
using UnityEngine;

namespace _Scripts.Factories
{
    [CreateAssetMenu(menuName = "Factory/FactoryEntity" , fileName = "FactoryEntity")]
    public class FactoryEntity : AssetProvider
    {
        public AlgorithmEntity CreateEntity(string path, Transform parent) => 
            CreateGameObject<AlgorithmEntity>(path, parent);
    }
}