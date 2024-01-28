using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Handlers
{
    public class AmountElemenetsHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _amountElement;
        [SerializeField] private Slider _amountElements;
        private IAlgorithmHandler _algorihmHandler;
        
        private const string AmountElementsKey = "amount_elements_key";

        [Inject]
        private void Construct(IAlgorithmHandler algorithmHandler)
        {
            _algorihmHandler = algorithmHandler;
            _amountElements.maxValue = 150;
            _amountElements.minValue = 10;

            LoadSave();
            _amountElements.onValueChanged.AddListener(OnValueChanged);
        }

        private void LoadSave()
        {
            var saveValue = GetAmountElements();
            OnValueChanged(saveValue);
            _amountElements.value = saveValue;
        }

        private void OnValueChanged(float value)
        {
            _amountElement.text = $"Amount elements: {(int)value}.";
            SaveAmountElements((int)value);
        }

        public int GetAmountElements() => 
            PlayerPrefs.GetInt(AmountElementsKey, 25);

        public void SaveAmountElements(int value) => 
            PlayerPrefs.SetInt(AmountElementsKey, value);
    }
}