using controller;

namespace model{
    public class PlayerInfo : ModelEntity{
        public PlayerType type { get; set; }
        public double balance { get; set; }
    }
}