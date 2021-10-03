using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace model{
    public class BoardInfo : ModelEntity{
        private List<int> _squareIds;
        private double _initialBalance;

        public BoardInfo(int id ,List<int> squareIds, double initialBalance) : base(id)
        {
            _squareIds = squareIds;
            _initialBalance = initialBalance;
        }

        public List<int> SquareIds
        {
            get => _squareIds;
            set => _squareIds = value;
        }

        public double InitialBalance
        {
            get => _initialBalance;
            set => _initialBalance = value;
        }
    }
}