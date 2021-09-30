using System.Collections.Generic;

namespace controller {
    public abstract class AbstractStateCommand<S, A> : IStateCommand<S, A>{
        protected readonly Dictionary<A, S> _mappings;
        protected readonly S _initialState;

        protected AbstractStateCommand(S initialState, Dictionary<A, S> mappings)
        {
            this._initialState = initialState;
            this._mappings = mappings;
        }

        public bool validate(S currentState, A action)
        {
            return this._initialState.Equals(currentState) && this._mappings.ContainsKey(action);
        }

        public S execute(S currentState, A action)
        {
            return this._mappings[action];
        }

        public Dictionary<A, S> Mappings => _mappings;

        public S InitialState => _initialState;
    }
}