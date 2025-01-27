using System;
using UnityEngine;

namespace Services.Implemented
{
    public class UnityViewService : IViewService
    {
        void IViewService.Instantiate(UnityEngine.Object original, Transform parent, Action<UnityEngine.Object> callback)
        {
            (this as IViewService).Instantiate<UnityEngine.Object>(original, parent, callback);
        }

        void IViewService.Instantiate<T>(T original, Transform parent, Action<T> callback)
        {
            var asyncInstantiateOperation = UnityEngine.Object.InstantiateAsync(original, parent);
            asyncInstantiateOperation.completed += (_) => callback(asyncInstantiateOperation.Result[0]);
        }
    }
}