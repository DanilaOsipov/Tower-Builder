using Providers;
using System.Collections.Generic;

namespace Settings
{
    public interface ICubesSettings
    {
        IReadOnlyList<IAssetProvider> CubesPrefabs { get; }
    }
}