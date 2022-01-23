using Assets.CodeBase.Data;

namespace Assets.CodeBase.Infrastructure.AllServices.LoadService {

    public interface ISaveLoadService : IService {

        PlayerProgress LoadProgress();
        void SaveProgress();
    }
}