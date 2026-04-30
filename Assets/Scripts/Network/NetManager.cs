using System.Collections.Generic;
using Mirror;
using Utils.Services;
using Zenject;

namespace Network
{
    public class NetManager : NetworkManager
    {
        private List<IService> _services;

        [Inject]
        private void Construct([Inject(Id = "NetworkServiceServer")] List<IService> services)
        {
            _services = services;
        }

        public override void OnStartServer()
        {
            base.OnStartServer();

            foreach (var service in _services)
            {
                service.InitService();
            }
        }
    }
}