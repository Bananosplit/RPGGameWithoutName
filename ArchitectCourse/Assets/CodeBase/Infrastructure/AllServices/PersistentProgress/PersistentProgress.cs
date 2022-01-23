using Assets.CodeBase.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.CodeBase.Infrastructure.AllServices.PersistentProgress {
    public class PersistentProgress : IPersistentProgress {
        public PlayerProgress Progress { get; set; }
    }
}
