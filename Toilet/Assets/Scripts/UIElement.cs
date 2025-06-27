using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public abstract class UIElement : BaseObject
    {
        public RectTransform ThisRectTransfom { get; private set; }

        public override void InitializeInternal()
        {
            base.InitializeInternal();
            ThisRectTransfom = GetComponent<RectTransform>();
        }

        private void OnEnable()
        {
            OnEnabled();
        }

        private void OnGUI()
        {
            Refresh();
        }

        public void Register2UI()
        {
            //ThisRectTransfom.SetParent(DynamicUIParent.Object, true);
        }

        public abstract void Refresh();
        public abstract void OnEnabled();
    }
}