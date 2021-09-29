using System.Collections.Generic;

namespace controller{
    public abstract class AbstractStateCommand<S, A> : IStateCommand<S, A>{
        protected readonly Dictionary<S, S> mappings;
        protected readonly A action;

        protected AbstractStateCommand(A action, Dictionary<S, S> mappings)
        {
            this.mappings = mappings;
            this.action = action;
        }

        public bool validate(S currentState, A action)
        {
            return action.Equals(this.action) && mappings.ContainsKey(currentState);
        }

        public virtual S execute(S currentState, A action)
        {
            return mappings[currentState];
        }
    }
}