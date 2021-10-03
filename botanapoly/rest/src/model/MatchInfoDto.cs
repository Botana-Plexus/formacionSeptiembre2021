namespace rest{
    public class MatchInfoDto{
        public string Name { get; set; }
        public int MaxPlayers { get; set; }
        public int? MaxDuration { get; set; }
        public string Password { get; set; }
        public int BoardId { get; set; }
    }
}