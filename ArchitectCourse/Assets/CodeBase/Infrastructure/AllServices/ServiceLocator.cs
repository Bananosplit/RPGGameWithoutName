using Assets.CodeBase.Infrastructure.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.Infrastructure.AllServices {
    public class ServiceLocator {

        private static ServiceLocator instance;
        public static ServiceLocator Container => instance ??= instance = new ServiceLocator();

        public void RegisterSingle<TService>(TService implementation) where TService : IService
            => Implementation<TService>.ServiceInstance = implementation;

        public TService Single<TService>() => Implementation<TService>.ServiceInstance;


        private static class Implementation<TService> {
            public static TService ServiceInstance;
        }
    }
}
