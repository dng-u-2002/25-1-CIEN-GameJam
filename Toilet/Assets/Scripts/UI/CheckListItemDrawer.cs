using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace UI
{
    public class CheckListItemDrawer : UIElement
    {
        [SerializeField] CheckListItem ReferencedItem;

        [SerializeField] TMP_Text MainText;
        [SerializeField] UnityEngine.UI.Toggle CheckToggle;

        public bool IsChecked
        {
            get => CheckToggle.isOn;
        }

        public void Initialize(CheckListItem item)
        {
            ReferencedItem = item;
            MainText.text = item.Text;
            CheckToggle.onValueChanged.AddListener(OnCheckToggleChanged);
        }

        void OnCheckToggleChanged(bool isChecked)
        {
            // Handle the toggle change, e.g., update the corresponding CheckListItem
            // This could involve notifying a manager or updating a scriptable object
            Debug.Log($"Check state changed: {isChecked}");
        }

        public override void OnEnabled()
        {
        }

        public override void Refresh()
        {
        }
    }
}