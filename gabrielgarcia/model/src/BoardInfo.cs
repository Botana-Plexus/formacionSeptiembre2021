using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace model{
    public class BoardInfo : ModelEntity{
        private List<int> _squareIds;
        private string description;
        private int _initialBalance;

        public BoardInfo(int id, string description, List<int> squareIds, int initialBalance) : base(id)
        {
            _squareIds = squareIds;
            _initialBalance = initialBalance;
        }

        public List<int> SquareIds
        {
            get => _squareIds;
            set => _squareIds = value;
        }

        public string Description
        {
            get => description;
            set => description = value;
        }

        public int InitialBalance
        {
            get => _initialBalance;
            set => _initialBalance = value;
        }
    }
}