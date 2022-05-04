using Assets.CodeBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.Infrastructure.AllServices.PersistentProgress {
    public interface ISavedProgressReader: ISavedProgress
    {
        void LoadProgress(PlayerProgress progress);
    }

    public interface ISavedProgress
    {
        void SaveProgress(PlayerProgress progress);
    }
}
