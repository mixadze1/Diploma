using System;
using _Scripts.Algorithms.Sort;
using _Scripts.Application;

namespace _Scripts.Handlers
{
    public interface IAlgorithmHandler
    {
        void ChangeDuration(int durationMS);
        event Action<int> OnChangeDurationMs;
        event Action<IAlgorithmInfo> OnChangeAlgorithm;
    }
}