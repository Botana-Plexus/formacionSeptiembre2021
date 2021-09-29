using System.Collections.Generic;
using controller;

namespace model{
    public class SquareInfo : ModelEntity{
        private  SquareType _type;
        private  BoardInfo _board;
        private  string _title;
        private  int _currentPlayerTurn;
        private  double _acquisitionCost;
        private  double _sellBankCost;
        private  int _edificationLevel;
        private  double _edificationLevelIncreaseCost;
        private  double _edificationLevelDecreaseCost;
        private  List<double> _rentCost;

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

        public SquareType Type
        {
            get => _type;
            set => _type = value;
        }

        public BoardInfo Board
        {
            get => _board;
            set => _board = value;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public int CurrentPlayerTurn
        {
            get => _currentPlayerTurn;
            set => _currentPlayerTurn = value;
        }

        public double AcquisitionCost
        {
            get => _acquisitionCost;
            set => _acquisitionCost = value;
        }

        public double SellBankCost
        {
            get => _sellBankCost;
            set => _sellBankCost = value;
        }

        public int EdificationLevel
        {
            get => _edificationLevel;
            set => _edificationLevel = value;
        }

        public double EdificationLevelIncreaseCost
        {
            get => _edificationLevelIncreaseCost;
            set => _edificationLevelIncreaseCost = value;
        }

        public double EdificationLevelDecreaseCost
        {
            get => _edificationLevelDecreaseCost;
            set => _edificationLevelDecreaseCost = value;
        }

        public List<double> RentCost
        {
            get => _rentCost;
            set => _rentCost = value;
        }
    }
}