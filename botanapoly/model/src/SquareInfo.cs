using System.Collections.Generic;
using controller;

namespace model{
    public class SquareInfo : ModelEntity{
        
        private SquareType _squareType;
        private BoardInfo _boardInfo;
        private string _title;
        private int _order;
        private double _buyCost;
        private double _sellCost;
        private double _edificationLevelBuyCost;
        private double _edificationLevelSellCost;
        private List<double> _rentCost;
        private CollectionInfo _collectionInfo;
        private int _destination;
        private PlayerInfo _owner;
        private int _currentEdificationLevel;

        public SquareInfo(int id, SquareType squareType, BoardInfo boardInfo, string title, int order, double buyCost, double sellCost, double edificationLevelBuyCost, double edificationLevelSellCost, List<double> rentCost, CollectionInfo collectionInfo, int destination, PlayerInfo owner, int currentEdificationLevel) : base(id)
        {
            _squareType = squareType;
            _boardInfo = boardInfo;
            _title = title;
            _order = order;
            _buyCost = buyCost;
            _sellCost = sellCost;
            _edificationLevelBuyCost = edificationLevelBuyCost;
            _edificationLevelSellCost = edificationLevelSellCost;
            _rentCost = rentCost;
            _collectionInfo = collectionInfo;
            _destination = destination;
            _owner = owner;
            _currentEdificationLevel = currentEdificationLevel;
        }

        public SquareType SquareType
        {
            get => _squareType;
            set => _squareType = value;
        }

        public BoardInfo BoardInfo
        {
            get => _boardInfo;
            set => _boardInfo = value;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
        }

        public int Order
        {
            get => _order;
            set => _order = value;
        }

        public double BuyCost
        {
            get => _buyCost;
            set => _buyCost = value;
        }

        public double SellCost
        {
            get => _sellCost;
            set => _sellCost = value;
        }

        public double EdificationLevelBuyCost
        {
            get => _edificationLevelBuyCost;
            set => _edificationLevelBuyCost = value;
        }

        public double EdificationLevelSellCost
        {
            get => _edificationLevelSellCost;
            set => _edificationLevelSellCost = value;
        }

        public List<double> RentCost
        {
            get => _rentCost;
            set => _rentCost = value;
        }

        public CollectionInfo CollectionInfo
        {
            get => _collectionInfo;
            set => _collectionInfo = value;
        }

        public int Destination
        {
            get => _destination;
            set => _destination = value;
        }

        public PlayerInfo Owner
        {
            get => _owner;
            set => _owner = value;
        }

        public int CurrentEdificationLevel
        {
            get => _currentEdificationLevel;
            set => _currentEdificationLevel = value;
        }
    }
}