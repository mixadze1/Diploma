using System;
using UnityEngine;

namespace _Scripts.Entities
{
    public class AlgorithmEntity : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        
        [SerializeField] private Material _materialDefault;
        [SerializeField] private Material _materialUse;
        
        private float _offset = 0.5f;
        private float _amount;

        public int Index { get; private set; }

        public int Value { get; private set; }

        private bool _isChange;

        private float _timer;
        private float _duration = 0.1f;

        public void Initialize(int value, int index, int amount)
        {
            _amount = amount;
            Value = value;
            Index = index;
            UpdateView(Value, index);
        }

        public void SetValue(int value)
        {
            Value = value;
            UpdateView(value, Index);
            _isChange = true;
            _meshRenderer.sharedMaterial = _materialUse;
        }

        private void FixedUpdate()
        {
            if (!_isChange)
                return;

            _timer += Time.fixedDeltaTime;
            if (_timer >= _duration)
            {
                _timer = 0;
                _isChange = false;
                _meshRenderer.sharedMaterial = _materialDefault;
            }
        }

        private void UpdateView(int value, int index)
        {
            this.gameObject.transform.localScale = new Vector3(1, value, 1);
            this.gameObject.transform.localPosition = new Vector3(index + _offset - _amount / 2, 0, 0);
        }
    }
}
