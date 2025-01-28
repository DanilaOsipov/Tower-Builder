using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Gameplay
{
    public class DragReceiver : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public UnityEvent<PointerEventData> OnBeginDrag = new();
        public UnityEvent<PointerEventData> OnDrag = new();
        public UnityEvent<PointerEventData> OnEndDrag = new();

        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData) => OnBeginDrag.Invoke(eventData);

        void IDragHandler.OnDrag(PointerEventData eventData) => OnDrag.Invoke(eventData);

        void IEndDragHandler.OnEndDrag(PointerEventData eventData) => OnEndDrag.Invoke(eventData);
    }
}