using controller;

namespace model{
    public class CardInfo : ModelEntity{
        private int _boardId;
        private string _text;
        private string _set;
        private int _type;
        private double _value;

        public CardInfo(int id, int boardId, string text, string set, int type, double value) : base(id)
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

        public int Type
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