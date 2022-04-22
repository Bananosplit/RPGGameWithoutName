using Assets.CodeBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.Infrastructure.AllServices.PersistentProgress {
    public class PersistentProgress : IPersistentProgress {

        private PlayerProgress progress;


        public PlayerProgress GetProgress()
        {
            return progress;
        }

        public void SetProgress(PlayerProgress value)
        {
            progress = value;
        }
    }
}
