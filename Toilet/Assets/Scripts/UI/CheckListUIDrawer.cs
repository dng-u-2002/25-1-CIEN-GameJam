using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class CheckListUIDrawer : UIElement
    {
        [SerializeField] CheckListItemDrawer ItemDrawerPrefab;
        [SerializeField] RectTransform ItemContainer;
        public List<CheckListItemDrawer> ItemDrawers;

        public bool IsShowing { get; private set; }

        public void Initialize(CheckList list)
        {
            ItemDrawers = new List<CheckListItemDrawer>();
            foreach (var item in ItemDrawers)
            {
                Destroy(item.gameObject);
            }
            ItemDrawers = new List<CheckListItemDrawer>();
            foreach (var item in list.Items)
            {
                var drawer = Instantiate(ItemDrawerPrefab, ItemContainer);
                drawer.Initialize(item);
                ItemDrawers.Add(drawer);
            }
        }

        IEnumerator _Move2UnShowPosition()
        {
            Vector3 nowPosition = ThisRectTransfom.localPosition;
            Vector3 targetPosition = new Vector3(402, -764, 0);

            float duration = 0.5f;
            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / duration;
                ThisRectTransfom.localPosition = Vector3.Lerp(nowPosition, targetPosition, t);
                yield return null;
            }
            ThisRectTransfom.localPosition = targetPosition;
        }
        IEnumerator _Move2ShowPosition()
        {
            Vector3 nowPosition = ThisRectTransfom.localPosition;
            Vector3 targetPosition = new Vector3(402, -113, 0);
            float duration = 0.5f;
            float elapsedTime = 0f;
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / duration;
                ThisRectTransfom.localPosition = Vector3.Lerp(nowPosition, targetPosition, t);
                yield return null;
            }
            ThisRectTransfom.localPosition = targetPosition;
        }
        Coroutine Mover;
        void SetShow(bool flag)
        {
            IsShowing = flag;


            if (IsShowing == true)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            if (Mover != null)
            {
                StopCoroutine(Mover);
            }
            if (IsShowing)
            {
                Mover = StartCoroutine(_Move2ShowPosition());
            }
            else
            {
                Mover = StartCoroutine(_Move2UnShowPosition());
            }
        }

        public override void OnEnabled()
        {
        }

        public override void Refresh()
        {
        }

        private void Start()
        {

            SetShow(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                SetShow(!IsShowing);
            }
        }
    }
}