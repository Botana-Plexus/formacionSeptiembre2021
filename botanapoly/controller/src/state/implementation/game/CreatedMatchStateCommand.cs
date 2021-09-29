using System.Collections.Generic;

namespace controller {
    public class CreatedMatchStateCommand : AbstractStateCommand<MatchState, TurnAction>{
        public CreatedMatchStateCommand() : base(MatchState.CREATED, new Dictionary<TurnAction, MatchState>()
        {
            {TurnAction.ROLL_1_2, MatchState.RUNNING},
            {TurnAction.ROLL_3, MatchState.TERMINATED},
            {TurnAction.GIVE_UP, MatchState.TERMINATED},
            {TurnAction.INCREASE_EDIFICATION_LEVEL, MatchState.CREATED},
            {TurnAction.DECREASE_EDIFICATION_LEVEL, MatchState.CREATED},
            {TurnAction.PAY_RENT, MatchState.NULL},
            {TurnAction.MOVEMENT, MatchState.NULL},
            {TurnAction.PAY_TO_CARD, MatchState.NULL},
            {TurnAction.RECEIVE_FROM_CARD, MatchState.NULL},
            {TurnAction.CARD_ACTION, MatchState.NULL},
            {TurnAction.BUY_PROPERTY, MatchState.NULL},
            {TurnAction.SELL_PROPERTY ,MatchState.NULL}
        })
        {
        }
    }
}