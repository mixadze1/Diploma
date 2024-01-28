using _Scripts.Handlers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Application
{
    public class DurationAlgorithmHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _viewValueSlider;
        [SerializeField] private Slider _slider;
        
        private IAlgorithmHandler _algorithmHandler;

        private const string DurationSaveKey = "duration_save_key";

        [Inject]
        private void Construct(IAlgorithmHandler algorithmHandler)
        {
            _algorithmHandler = algorithmHandler;
            SetMinMaxSlider();
            LoadSaveDuration();
            _slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void LoadSaveDuration()
        {
            var value = GetDurationSave();
            OnValueChanged(value);
            _slider.value = value;
        }

        private void SetMinMaxSlider()
        {
            _slider.maxValue = 1500f;
        }

        private void OnValueChanged(float value)
        {
            _viewValueSlider.text = $"Duration sort: {(int)value}ms.";
            _algorithmHandler.ChangeDuration((int)value);
            SaveValue(value);
        }

        private void SaveValue(float value) => 
            PlayerPrefs.SetFloat(DurationSaveKey, value);

        private float GetDurationSave() => 
            PlayerPrefs.GetFloat(DurationSaveKey, 250f);
    }
}