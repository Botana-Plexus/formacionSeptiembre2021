using System.Collections.Generic;

namespace controller{
    public class RunningMatchStateCommand : AbstractStateCommand<MatchState, TurnAction>{
        public RunningMatchStateCommand() : base(MatchState.CREATED, new Dictionary<TurnAction, MatchState>()
        {
            {TurnAction.ROLL_1_2, MatchState.NULL},
            {TurnAction.ROLL_3, MatchState.NULL},
            {TurnAction.GIVE_UP, MatchState.TERMINATED},
            {TurnAction.INCREASE_EDIFICATION_LEVEL, MatchState.NULL},
            {TurnAction.DECREASE_EDIFICATION_LEVEL, MatchState.NULL},
            {TurnAction.PAY_RENT, MatchState.TERMINATED},
            {TurnAction.MOVEMENT, MatchState.TERMINATED},
            {TurnAction.PAY_TO_CARD, MatchState.TERMINATED},
            {TurnAction.RECEIVE_FROM_CARD, MatchState.TERMINATED},
            {TurnAction.CARD_ACTION, MatchState.TERMINATED},
            {TurnAction.BUY_PROPERTY, MatchState.TERMINATED},
            {TurnAction.SELL_PROPERTY ,MatchState.RUNNING}
        })
        {
        }
    }
}