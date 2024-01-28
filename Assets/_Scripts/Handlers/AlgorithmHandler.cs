using System;
using System.Collections.Generic;
using _Scripts.Algorithms.Sort;
using _Scripts.Entities;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Handlers
{
    public class AlgorithmHandler : MonoBehaviour, IAlgorithmHandler
    {
        [SerializeField] private Button _stopSortButton;
        [SerializeField] private Button _sortButton;

        private List<AlgorithmEntity> _allEntities = new();
        
        private AlgorithmBase _currentAlgorithm;
        
        private GenerateEntitiesHandler _generateEntitiesHandler;
        private AmountElemenetsHandler _amountElementHandler;
        
        public event Action<int> OnChangeDurationMs;
        public event Action<IAlgorithmInfo> OnChangeAlgorithm;

        [Inject]
        private void Construct(FastSortAlgorithm fastSortAlgorithm, AmountElemenetsHandler amountElemenetsHandler, GenerateEntitiesHandler generateEntitiesHandler)
        {
            _amountElementHandler = amountElemenetsHandler;
            _generateEntitiesHandler = generateEntitiesHandler;
            _currentAlgorithm = fastSortAlgorithm;
            _sortButton.onClick.AddListener(Sort);
            _stopSortButton.onClick.AddListener(StopSort);
        }

        private void Awake() => 
            OnChangeAlgorithm?.Invoke(_currentAlgorithm);

        private IEnumerable<AlgorithmEntity> CreateEntities()
        {
            return _generateEntitiesHandler.GenerateRandomValueEntities(_amountElementHandler.GetAmountElements(), this.transform);
        }

        public void ChangeCurrentAlgorithm(AlgorithmBase algorithmBase)
        {
            _currentAlgorithm = algorithmBase;
            OnChangeAlgorithm?.Invoke(_currentAlgorithm);
        }

        private void Sort()
        {
            StopSort();
            
            var entities = CreateEntities();
            _allEntities.AddRange(entities);
            _currentAlgorithm.Sort(_allEntities.ToArray());
            
            Debug.Log($"Sort completed, name : {_currentAlgorithm.GetNameAlgorithm()}");
        }

        private void StopSort()
        {
            _currentAlgorithm.StopSort();
            ReclaimEntities();
        }

        private void ReclaimEntities()
        {
            foreach (var e in _allEntities)
            {
                Destroy(e.gameObject);
            }
            _allEntities.Clear();
        }

        public void ChangeDuration(int durationMS) => 
            OnChangeDurationMs?.Invoke(durationMS);
    }
}
    