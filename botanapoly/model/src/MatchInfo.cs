using System.Collections.Generic;
using controller;

namespace model{
    public class MatchInfo : ModelEntity{
        public PlayerInfo host { get; set; }
        public bool visibility { get; set; }
        public long hash { get; set; }
        public MatchTemplateInfo matchTemplateInfo { get; set; }
        public BoardInfo boardInfo { get; set; }
        public MatchState matchState { get; set; }
        public List<PlayerInfo> players { get; set; }
    }
}