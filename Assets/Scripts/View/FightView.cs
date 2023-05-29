
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class FightView : MonoBehaviour
    {
        [SerializeField] private Crane _crane;
        [SerializeField] private Toggle _toggle;

        private void OnEnable()
        {
            _toggle.onValueChanged.AddListener(ToggleResist);
        }

        private void ToggleResist(bool value)
        {
            _crane.IsFight = value;
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveListener(ToggleResist);
        }
        
    }
