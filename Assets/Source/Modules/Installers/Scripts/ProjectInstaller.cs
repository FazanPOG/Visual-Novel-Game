using Source.Modules.Services.Scripts;
using Source.Modules.Services.Scripts.Interfaces;
using Zenject;

namespace Source.Modules.Installers.Scripts
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindServices();
        }

        private void BindServices()
        {
            BindSceneLoaderService();
        }
        
        private void BindSceneLoaderService()
        {
            Container
                .Bind<ISceneLoaderService>()
                .To<SceneLoaderService>()
                .FromNew()
                .AsSingle();
        }
    }
}
