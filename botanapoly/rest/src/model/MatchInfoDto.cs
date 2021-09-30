namespace rest{
    public class MatchInfoDto {
        public string _name { get; set; }
        public int? _maxPlayers { get; set; }
        public int? _maxDuration { get; set; }
        public string _password { get; set; }
        public int _boardId { get; set; }
    }
}