using Assets.CodeBase.Data;

namespace Assets.CodeBase.Infrastructure.AllServices.PersistentProgress {
    public interface IPersistentProgress : IService {
        public PlayerProgress Progress { get; set; }
    }
}