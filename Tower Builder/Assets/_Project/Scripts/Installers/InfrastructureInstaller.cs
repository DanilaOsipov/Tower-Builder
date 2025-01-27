using Zenject;
using Services;
using Services.Implemented;

namespace Installers
{
    public class InfrastructureInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IAssetsService>().To<ResourcesAssetsService>().AsSingle();
            Container.Bind<IViewService>().To<UnityViewService>().AsSingle();
        }
    }
}