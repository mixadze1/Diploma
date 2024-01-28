using System.Collections.Generic;
using _Scripts.AssetProviders;
using _Scripts.Entities;
using _Scripts.Factories;
using _Scripts.Services.RandomService;
using UnityEngine;

namespace _Scripts.Handlers
{
    public class GenerateEntitiesHandler
    {
        private FactoryEntity _factoryEntity;
        private IRandomService _randomService;

        private GenerateEntitiesHandler(FactoryEntity factoryEntity, IRandomService randomService)
        {
            _randomService = randomService;
            _factoryEntity = factoryEntity;
        }

        public IEnumerable<AlgorithmEntity> GenerateRandomValueEntities(int amount, Transform parent)
        {
            List<AlgorithmEntity> entities = new();
            for (int i = 0; i < amount; i++)
            {
                var instance = _factoryEntity.CreateEntity(AssetPath.Entity, parent);
                instance.Initialize(_randomService.Next(1, 100), i, amount);
                entities.Add(instance);
            }

            return entities;
        }
    }
}