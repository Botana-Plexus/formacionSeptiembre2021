using System;
using System.Collections.Generic;

namespace controller{
    public class GameStateControlFlow<S, A>{
        private List<A> _enabledActions;
        private Dictionary<S, List<S>> _stateFlow;

        public GameStateControlFlow(List<A> enabledActions, Dictionary<S, List<S>> stateFlow)
        {
            _enabledActions = enabledActions;
            _stateFlow = stateFlow;
        }

        public List<A> EnabledActions => _enabledActions;

        public Dictionary<S, List<S>> StateFlow => _stateFlow;

        public S execute(S currentState, A action)
        {
            if (_enabledActions.Contains(action)) return _stateFlow[currentState][_enabledActions.IndexOf(action)];
            throw new NullReferenceException();
        }
    }
}