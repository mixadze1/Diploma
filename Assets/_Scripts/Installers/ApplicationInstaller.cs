using _Scripts.Algorithms.Sort;
using _Scripts.Application;
using _Scripts.Factories;
using _Scripts.Handlers;
using _Scripts.Services.RandomService;
using UnityEngine;
using Zenject;

namespace _Scripts.Installers
{
    public class ApplicationInstaller : MonoInstaller
    {
        [SerializeField] private FactoryEntity _factoryEntity;
        [SerializeField] private AlgorithmHandler _algorithmHandler;
        [SerializeField] private AmountElemenetsHandler _amountElementsHandler;

        public override void InstallBindings()
        {
            BindAlgorithmHandler();
            BindFastAlgorithm();
            BindFactoryEntity();
            BindAmountEntitiesHandler();
            BindGenerateEntitiesHandler();
            BindRandomService();
        }

        private void BindRandomService() => 
            Container.BindInterfacesTo < RandomService>().AsSingle();

        private void BindGenerateEntitiesHandler() => 
            Container.Bind<GenerateEntitiesHandler>().AsSingle();

        private void BindAmountEntitiesHandler()
        {
            Container.Bind<AmountElemenetsHandler>().FromInstance(_amountElementsHandler);
        }

        private void BindFactoryEntity() => 
            Container.Bind<FactoryEntity>().FromInstance(_factoryEntity);


        private void BindFastAlgorithm() => 
            Container.Bind<FastSortAlgorithm>().AsSingle();

        private void BindAlgorithmHandler() => 
            Container.BindInterfacesTo<AlgorithmHandler>().FromInstance(_algorithmHandler);
    }
}