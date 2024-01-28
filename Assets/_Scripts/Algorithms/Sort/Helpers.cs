using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace _Scripts.Algorithms.Sort
{
    public static class Helpers
    {
        private static readonly Dictionary<float, WaitForSeconds> _waitDictionary = new();

        public static WaitForSeconds GetWait(float time)
        {
            if (_waitDictionary.TryGetValue(time, out WaitForSeconds wait))
                return wait;

            _waitDictionary[time] = new WaitForSeconds(time);
            return _waitDictionary[time];
        }

        public static void ExceptionTaskHandler(Task task)
        {
            if (task.Exception != null)
            {
                foreach (var exception in task.Exception.Flatten().InnerExceptions)
                {
                    Debug.LogError(exception);
                }
            }
        }
    }
}