using System.Collections.Generic;
using controller;

namespace model{
    public class SquareInfo : ModelEntity{
        
        private SquareType _squareType;
        private int _boardId;
        private string _title;
        private int _order;
        private double _buyCost;
        private double _sellCost;
        private double _edificationLevelBuyCost;
        private double _edificationLevelSellCost;
        private List<double> _rentCost;
        private int _collectionId;
        private int _destination;
        private int? _ownerId;
        private int? _currentEdificationLevel;

        public SquareInfo(int id, SquareType squareType, int boardId, string title, int order, double buyCost, double sellCost, double edificationLevelBuyCost, double edificationLevelSellCost, List<double> rentCost, int collectionId, int destination, int? ownerId, int? currentEdificationLevel) : base(id)
        {
            _squareType = squareType;
            _boardId = boardId;
            _title = title;
            _order = order;
            _buyCost = buyCost;
            _sellCost = sellCost;
            _edificationLevelBuyCost = edificationLevelBuyCost;
            _edificationLevelSellCost = edificationLevelSellCost;
            _rentCost = rentCost;
            _collectionId = collectionId;
            _destination = destination;
            _ownerId = ownerId;
            _currentEdificationLevel = currentEdificationLevel;
        }

        public SquareType SquareType
        {
            get => _squareType;
            set => _squareType = value;
        }

        public int Boardid
        {
            get => _boardId;
            set => _boardId = value;
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

        public int CollectionId
        {
            get => _collectionId;
            set => _collectionId = value;
        }

        public int Destination
        {
            get => _destination;
            set => _destination = value;
        }

        public int? OwnerId
        {
            get => _ownerId;
            set => _ownerId = value;
        }

        public int? CurrentEdificationLevel
        {
            get => _currentEdificationLevel;
            set => _currentEdificationLevel = value;
        }
    }
}