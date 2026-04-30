using System.Collections.Generic;
using Logging;
using Network.PubSub;
using Mirror;
using Utils.Services;
using Zenject;

namespace Network
{
    public class NetworkServerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            List<IService>networkServicesServer = new List<IService>();
            
            NetworkBroker  networkBroker = new NetworkBroker();
            
            networkServicesServer.Add(networkBroker);
            
            Container.Bind<IBroker>()
                .FromInstance(networkBroker)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<IBrokerEvents>()
                .FromInstance(networkBroker)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<IPublisher>()
                .To<NetworkPublisher>()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<List<IService>>()
                .WithId("NetworkServiceServer")
                .FromInstance(networkServicesServer)
                .AsSingle().NonLazy();

            Container.Bind<Ilog>()
                .To<Logger>()
                .AsSingle();
        }
    }
}