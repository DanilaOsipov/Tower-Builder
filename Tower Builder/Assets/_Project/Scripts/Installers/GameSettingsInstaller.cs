using Settings.Implemented;
using UnityEngine;
using Zenject;

namespace Installers
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField] private UnityCubesSettings _cubes;
        [SerializeField] private UnityBuildAreaSettings _buildAreaSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_cubes).AsSingle();
            Container.BindInstance(_buildAreaSettings).AsSingle();
        }
    }
}