using Assets.CodeBase.Data;

namespace Assets.CodeBase.Infrastructure.AllServices.PersistentProgress {
    public interface IPersistentProgress : IService {
        PlayerProgress GetProgress();
        void SetProgress(PlayerProgress value);
    }
}