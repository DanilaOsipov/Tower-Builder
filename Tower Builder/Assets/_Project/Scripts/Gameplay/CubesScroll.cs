using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Gameplay
{
    public class CubesScroll : MonoBehaviour
    {
        [SerializeField] private ScrollRect _scrollRect;
        [SerializeField] private CubesSpawner _cubesSpawner;
        private IEnumerable<Cube> _cubes;

        private void Awake()
        {
            _cubesSpawner.OnCubesSpawned += OnCubesSpawnedHandler;
        }

        private void OnDestroy()
        {
            _cubesSpawner.OnCubesSpawned -= OnCubesSpawnedHandler;
            foreach (var cube in _cubes)
            {
                if (cube.TryGetComponent<DragReceiver>(out var dragReceiver))
                {
                    dragReceiver.OnBeginDrag.RemoveListener(OnBeginDragHandler);
                    dragReceiver.OnDrag.RemoveListener(OnCubeDragHandler);
                    dragReceiver.OnEndDrag.RemoveListener(OnEndDragHandler);
                }
            }
        }

        private void OnCubesSpawnedHandler(IEnumerable<Cube> cubes)
        {
            _cubes = cubes;
            foreach (var cube in _cubes)
            {
                DragReceiver dragReceiver = cube.TryGetComponent(out dragReceiver) ? dragReceiver : cube.AddComponent<DragReceiver>();
                dragReceiver.OnBeginDrag.AddListener(OnBeginDragHandler);
                dragReceiver.OnDrag.AddListener(OnCubeDragHandler);
                dragReceiver.OnEndDrag.AddListener(OnEndDragHandler);
            }
        }

        private void OnBeginDragHandler(PointerEventData eventData)
        {
            _scrollRect.OnBeginDrag(eventData);
        }

        private void OnCubeDragHandler(PointerEventData eventData)
        {
            _scrollRect.OnDrag(eventData);
        }

        private void OnEndDragHandler(PointerEventData eventData)
        {
            _scrollRect.OnEndDrag(eventData);
        }
    }
}