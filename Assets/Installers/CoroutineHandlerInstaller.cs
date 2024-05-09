using SecondExample.Scripts;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class CoroutineHandlerInstaller : MonoInstaller
    {
        [SerializeField] private CoroutineHandler _coroutineHandlerPrefab;
        
        public override void InstallBindings()
        {
            BindInstance();
        }

        private void BindInstance()
        {
            CoroutineHandler coroutineHandler = Container.InstantiatePrefabForComponent<CoroutineHandler>(_coroutineHandlerPrefab);
            Container.Bind<CoroutineHandler>().FromInstance(coroutineHandler).AsSingle();
        }
    }
}