using System.Collections.Generic;

namespace model{
    public class CollectionInfo : ModelEntity {
        private List<int> _squareIds;

        public CollectionInfo(int id, List<int> squareIds) : base(id)
        {
            _squareIds = squareIds;
        }

        public List<int> SquareIds
        {
            get => _squareIds;
            set => _squareIds = value;
        }

        public int Id1 => _id;
    }
}