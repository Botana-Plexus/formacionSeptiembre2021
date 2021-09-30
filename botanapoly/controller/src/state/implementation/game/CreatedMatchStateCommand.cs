using System.Collections.Generic;

namespace controller {
    public class CreatedMatchStateCommand : AbstractStateCommand<TurnState, TurnAction>{
        public CreatedMatchStateCommand() : base(TurnState.INITIALIZED, new Dictionary<TurnAction, TurnState>()
        {
            {TurnAction.ROLL_1_2, TurnState.INITIALIZED},
            {TurnAction.ROLL_3, TurnState.FINALIZED},
            {TurnAction.GIVE_UP, TurnState.FINALIZED},
            {TurnAction.INCREASE_EDIFICATION_LEVEL, TurnState.INITIALIZED},
            {TurnAction.DECREASE_EDIFICATION_LEVEL, TurnState.INITIALIZED},
            {TurnAction.PAY_RENT, TurnState.NULL},
            {TurnAction.MOVEMENT, TurnState.NULL},
            {TurnAction.PAY_TO_CARD, TurnState.NULL},
            {TurnAction.RECEIVE_FROM_CARD, TurnState.NULL},
            {TurnAction.CARD_ACTION, TurnState.NULL},
            {TurnAction.BUY_PROPERTY, TurnState.NULL},
            {TurnAction.SELL_PROPERTY ,TurnState.NULL}
        })
        {
        }
    }
}