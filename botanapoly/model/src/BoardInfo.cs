using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace model{
    public class BoardInfo : ModelEntity{
        private readonly List<SquareInfo> _squares;
        private readonly double _initialBalance;

        public BoardInfo(int id ,List<SquareInfo> squares, double initialBalance) : base(id)
        {
            _squares = squares;
            _initialBalance = initialBalance;
        }

        public List<SquareInfo> Squares => _squares;

        public double InitialBalance => _initialBalance;
    }
}