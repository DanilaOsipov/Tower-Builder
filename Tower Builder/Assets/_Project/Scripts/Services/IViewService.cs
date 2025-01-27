using System;
using UnityEngine;

namespace Services
{
    public interface IViewService
    {
        void Instantiate(UnityEngine.Object original, Transform parent, Action<UnityEngine.Object> callback);
        void Instantiate<T>(T original, Transform parent, Action<T> callback) where T : UnityEngine.Object;
    }
}