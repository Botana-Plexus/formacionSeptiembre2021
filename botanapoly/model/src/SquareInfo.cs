using System.Collections.Generic;
using controller;

namespace model{
    public class SquareInfo : ModelEntity{
        public EdificationLevel edificationLevel { get; set; }
        public PlayerInfo owner { get; set; }
        public CollectionInfo collection { get; set; }
    }
}