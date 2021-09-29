using System.Collections.Generic;
using controller;

namespace model{
    public class SquareInfo : ModelEntity{
        private readonly SquareType _type;
        private readonly BoardInfo _board;
        private readonly string _title;
        private readonly int _currentPlayerTurn;
        private readonly double _acquisitionCost;
        private readonly double _sellBankCost;
        private readonly int _edificationLevel;
        private readonly double _edificationLevelIncreaseCost;
        private readonly double _edificationLevelDecreaseCost;
        private readonly List<double> _rentCost;

        public SquareInfo(int id, SquareType type, BoardInfo board, string title, int currentPlayerTurn, double acquisitionCost, double sellBankCost, int edificationLevel, double edificationLevelIncreaseCost, double edificationLevelDecreaseCost, List<double> rentCost) : base(id)
        {
            _type = type;
            _board = board;
            _title = title;
            _currentPlayerTurn = currentPlayerTurn;
            _acquisitionCost = acquisitionCost;
            _sellBankCost = sellBankCost;
            _edificationLevel = edificationLevel;
            _edificationLevelIncreaseCost = edificationLevelIncreaseCost;
            _edificationLevelDecreaseCost = edificationLevelDecreaseCost;
            _rentCost = rentCost;
        }

        public SquareType Type => _type;

        public BoardInfo Board => _board;

        public string Title => _title;

        public int CurrentPlayerTurn => _currentPlayerTurn;

        public double AcquisitionCost => _acquisitionCost;

        public double SellBankCost => _sellBankCost;

        public int EdificationLevel => _edificationLevel;

        public double EdificationLevelIncreaseCost => _edificationLevelIncreaseCost;

        public double EdificationLevelDecreaseCost => _edificationLevelDecreaseCost;

        public List<double> RentCost => _rentCost;

    }
}