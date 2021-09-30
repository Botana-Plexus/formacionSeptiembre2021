using System.Collections.Generic;

namespace controller{
    public class TerminatedMatchStateCommand : AbstractStateCommand<MatchState, TurnAction> {
        public TerminatedMatchStateCommand() : base(MatchState.CREATED, new Dictionary<TurnAction, MatchState>()
        {
            {TurnAction.ROLL_1_2, MatchState.NULL},
            {TurnAction.ROLL_3, MatchState.NULL},
            {TurnAction.GIVE_UP, MatchState.NULL},
            {TurnAction.INCREASE_EDIFICATION_LEVEL, MatchState.NULL},
            {TurnAction.DECREASE_EDIFICATION_LEVEL, MatchState.NULL},
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