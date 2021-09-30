using System.Collections.Generic;

namespace controller{
    public class RunningMatchStateCommand : AbstractStateCommand<TurnState, TurnAction>{
        public RunningMatchStateCommand() : base(TurnState.ROLLED, new Dictionary<TurnAction, TurnState>()
        {
            {TurnAction.ROLL_1_2, TurnState.NULL},
            {TurnAction.ROLL_3, TurnState.NULL},
            {TurnAction.GIVE_UP, TurnState.FINALIZED},
            {TurnAction.INCREASE_EDIFICATION_LEVEL, TurnState.NULL},
            {TurnAction.DECREASE_EDIFICATION_LEVEL, TurnState.ROLLED},
            {TurnAction.PAY_RENT, TurnState.FINALIZED},
            {TurnAction.MOVEMENT, TurnState.FINALIZED},
            {TurnAction.PAY_TO_CARD, TurnState.FINALIZED},
            {TurnAction.RECEIVE_FROM_CARD, TurnState.FINALIZED},
            {TurnAction.CARD_ACTION, TurnState.FINALIZED},
            {TurnAction.BUY_PROPERTY, TurnState.FINALIZED},
            {TurnAction.SELL_PROPERTY ,TurnState.ROLLED}
        })
        {
        }
    }
}