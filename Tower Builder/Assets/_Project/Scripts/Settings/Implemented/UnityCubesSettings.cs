using Providers;
using Providers.Implemented;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Settings.Implemented
{
    [Serializable]
    public class UnityCubesSettings : ICubesSettings
    {
        [SerializeField] private List<ScriptableObjectAssetProvider> _cubesPrefabs;

        IReadOnlyList<IAssetProvider> ICubesSettings.CubesPrefabs => _cubesPrefabs;
    }
}