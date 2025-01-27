using System;
using UnityEngine;

namespace Settings.Implemented
{
    [Serializable]
    public class UnityBuildAreaSettings : IBuildAreaSettings
    {
        [SerializeField] private int _maxTowersCount = 1;

        int IBuildAreaSettings.MaxTowersCount => _maxTowersCount;
    }
}