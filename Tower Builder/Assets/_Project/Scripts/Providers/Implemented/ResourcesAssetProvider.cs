using UnityEngine;

namespace Providers.Implemented
{
    [CreateAssetMenu(fileName = "ResourcesAssetProvider", menuName = "Asset Provider/Resources Asset Provider")]
    public class ResourcesAssetProvider : ScriptableObjectAssetProvider
    {
        [SerializeField] private string _assetPath;

        public string AssetPath => _assetPath;
    }
}