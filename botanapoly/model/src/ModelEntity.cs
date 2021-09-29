using System;

namespace model {
    
    [Serializable]
    public abstract class ModelEntity{    //TODO: change to long
        protected readonly int _id;

        protected ModelEntity(int id)
        {
            _id = id;
        }

        public int Id => _id;
    }
}