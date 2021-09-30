using System.Collections.Generic;

namespace model{
    public class CollectionInfo : ModelEntity {
        private List<SquareInfo> _squares;

        public CollectionInfo(int id, List<SquareInfo> squares) : base(id)
        {
            _squares = squares;
        }

        public List<SquareInfo> Squares
        {
            get => _squares;
            set => _squares = value;
        }

        public int Id1 => _id;
    }
}