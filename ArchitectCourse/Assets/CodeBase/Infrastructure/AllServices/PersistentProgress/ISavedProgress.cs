using Assets.CodeBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.Infrastructure.AllServices.PersistentProgress {
    public interface ISavedProgressReader: ISavedProgress
    {
        public void LoadProgress(PlayerProgress progress);
    }

    public interface ISavedProgress
    {
        public void SaveProgress(PlayerProgress progress);
    }
}
