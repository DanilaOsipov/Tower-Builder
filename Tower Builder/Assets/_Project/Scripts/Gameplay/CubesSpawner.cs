using Services;
using Settings;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Gameplay
{
    public class CubesSpawner : MonoBehaviour
    {
        private IAssetsService _assetsService;
        private IViewService _viewService;
        private ICubesSettings _cubesSettings;

        public event Action<IEnumerable<Cube>> OnCubesSpawned = delegate { };

        [Inject]
        private void Construct(IAssetsService assetsService,
                               IViewService viewService,
                               ICubesSettings cubesSettings)
        {
            _assetsService = assetsService;
            _viewService = viewService;
            _cubesSettings = cubesSettings;
        }

        private void Awake()
        {
            var cubes = new List<Cube>(_cubesSettings.CubesPrefabs.Count);
            foreach (var provider in _cubesSettings.CubesPrefabs)
            {
                _assetsService.Load<Cube>(provider, (prefab) => _viewService.Instantiate(prefab, transform, (cube) =>
                {
                    cubes.Add(cube);
                    if (cubes.Count == _cubesSettings.CubesPrefabs.Count)
                        OnCubesSpawned(cubes);
                }));
            }
        }
    }
}