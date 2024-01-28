using _Scripts.Algorithms.Sort;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Scripts.Handlers
{
    public class AlgorithmNameVisualization : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameAlgorithm;
        private IAlgorithmHandler _algorithmHandler;

        [Inject]
        private void Construct(IAlgorithmHandler algorithmHandler)
        {
            _algorithmHandler = algorithmHandler;
            _algorithmHandler.OnChangeAlgorithm += OnChangeAlgorithm;
        }

        private void OnChangeAlgorithm(IAlgorithmInfo info)
        {
            _nameAlgorithm.text = info.GetNameAlgorithm();
        }
    }
}