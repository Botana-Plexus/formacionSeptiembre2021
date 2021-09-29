using System;

namespace model {
    
    [Serializable]
    public abstract class ModelEntity{    //TODO: change to long
        protected int id;

        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return id;
        }
    }
}