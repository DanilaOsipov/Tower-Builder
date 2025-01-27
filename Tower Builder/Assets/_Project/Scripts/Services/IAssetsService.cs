using Providers;
using System;

namespace Services
{
    public interface IAssetsService
    {
        void Load(IAssetProvider assetHelper, Action<UnityEngine.Object> callback);
        void Load<T>(IAssetProvider assetHelper, Action<T> callback) where T : UnityEngine.Object;
    }
}