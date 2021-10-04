using controller;

namespace model{
    public class CardInfo : ModelEntity{
        private int _boardId;
        private string _text;
        private string _set;
        private CardType _type;
        private int _value;

        public CardInfo(int id, int boardId, string text, string set, CardType type, int value) : base(id)
        {
            _boardId = boardId;
            _text = text;
            _set = set;
            _type = type;
            _value = value;
        }

        public int BoardId
        {
            get => _boardId;
            set => _boardId = value;
        }

        public string Text
        {
            get => _text;
            set => _text = value;
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

        public int Value
        {
            get => _value;
            set => _value = value;
        }
    }
}