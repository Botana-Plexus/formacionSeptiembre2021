using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace model{
    public class BoardInfo : ModelEntity{
        private List<SquareInfo> _squares;
        private double _initialBalance;

        public BoardInfo(int id ,List<SquareInfo> squares, double initialBalance) : base(id)
        {
            _squares = squares;
            _initialBalance = initialBalance;
        }

        public List<SquareInfo> Squares
        {
            get => _squares;
            set => _squares = value;
        }

        public double InitialBalance
        {
            get => _initialBalance;
            set => _initialBalance = value;
        }
    }
}