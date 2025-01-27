using Providers;
using Providers.Implemented;
using System;
using UnityEngine;

namespace Services.Implemented
{
    public class ResourcesAssetsService : IAssetsService
    {
        void IAssetsService.Load(IAssetProvider assetHelper, Action<UnityEngine.Object> callback)
        {
            (this as IAssetsService).Load<UnityEngine.Object>(assetHelper, callback);
        }

        void IAssetsService.Load<T>(IAssetProvider assetHelper, Action<T> callback)
        {
            var resourcesAssetHelper = assetHelper as ResourcesAssetProvider;
            var resourceRequest = Resources.LoadAsync<T>(resourcesAssetHelper.AssetPath);
            resourceRequest.completed += (_) => callback(resourceRequest.asset as T);
        }
    }
}