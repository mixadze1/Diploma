using System;
using System.Threading;
using System.Threading.Tasks;
using _Scripts.Entities;
using _Scripts.Handlers;
using UnityEngine;
using Zenject;

namespace _Scripts.Algorithms.Sort
{
    public abstract class AlgorithmBase : IDisposable, IAlgorithmInfo
    {
        private IAlgorithmHandler _algorithmHanlder;
        
        protected CancellationTokenSource CancellationTokenSource;
        protected int DurationInMs;

        [Inject]
        public void Initialize(IAlgorithmHandler algorithmHandler)
        {
            _algorithmHanlder = algorithmHandler;
            _algorithmHanlder.OnChangeDurationMs += OnChangeFlexibleValue;
        }

        private void OnChangeFlexibleValue(int durationMS)
        {
            Debug.Log($"Set duration :{durationMS}");
            DurationInMs = durationMS;
        }

        public abstract string GetNameAlgorithm();

        public abstract void Sort(AlgorithmEntity[] entities);

        public void Dispose()
        {
            CancellationTokenSource?.Cancel();
            _algorithmHanlder.OnChangeDurationMs -= OnChangeFlexibleValue;
        }

        public void StopSort() => 
            CancellationTokenSource?.Cancel();
    }

    public interface IAlgorithmInfo
    {
        string GetNameAlgorithm();
    }
}