using System.Collections.ObjectModel;

namespace model{
    public class BoardInfo : ModelEntity{
        public Collection<CollectionInfo> collections { get; set; }
    }
}