using controller;

namespace model{
    public class CardInfo : ModelEntity{
        private BoardInfo _board;
        private string _set;
        private CardType _type;
        private double _value;

        public CardInfo(int id, BoardInfo board, string set, CardType type, double value) : base(id)
        {
            _board = board;
            _set = set;
            _type = type;
            _value = value;
        }

        public BoardInfo Board
        {
            get => _board;
            set => _board = value;
        }

        public string Set
        {
            get => _set;
            set => _set = value;
        }

        public CardType Type
        {
            get => _type;
            set => _type = value;
        }

        public double Value
        {
            get => _value;
            set => _value = value;
        }
    }
}