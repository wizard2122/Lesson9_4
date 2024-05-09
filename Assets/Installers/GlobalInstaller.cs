using UnityEngine;
using Zenject;

namespace Installers
{
    public class GlobalInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLoader();
            BindInput();
        }

        private void BindLoader()
        {
            Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
            Container.Bind<SceneLoadMediator>().AsSingle();
        }

        private void BindInput()
        {
            if (SystemInfo.deviceType == DeviceType.Handheld)
                Container.BindInterfacesAndSelfTo<MobileInput>().AsSingle();
            else
                Container.BindInterfacesAndSelfTo<DesktopInput>().AsSingle();
        }
    }
}
