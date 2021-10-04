using System.Collections.Generic;
using controller;

namespace model{
    public class SquareInfo : ModelEntity{
        private SquareType _squareType;
        private int _boardId;
        private string _title;
        private int _order;
        private int _buyCost;
        private int _sellCost;
        private int _edificationLevelBuyCost;
        private int _edificationLevelSellCost;
        private List<int> _rentCost;
        private int _collectionId;
        private int _destination;
        private int? _ownerId;
        private int? _currentEdificationLevel;

        public SquareInfo(int id, SquareType squareType, int boardId, string title, int order, int buyCost, int sellCost, int edificationLevelBuyCost, int edificationLevelSellCost, List<int> rentCost, int collectionId, int destination, int? ownerId, int? currentEdificationLevel) : base(id)
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

        public int BuyCost
        {
            get => _buyCost;
            set => _buyCost = value;
        }

        public int SellCost
        {
            get => _sellCost;
            set => _sellCost = value;
        }

        public int EdificationLevelBuyCost
        {
            get => _edificationLevelBuyCost;
            set => _edificationLevelBuyCost = value;
        }

        public int EdificationLevelSellCost
        {
            get => _edificationLevelSellCost;
            set => _edificationLevelSellCost = value;
        }

        public List<int> RentCost
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