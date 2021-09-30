using System.Collections.Generic;
using System.Linq;
using model;

namespace controller{
    public class Controller {

        public MatchInfo executeAction(UserInfo user, int matchId, TurnAction action, Dictionary<string, object> args)
        {
            return null;
        }

        public MatchInfo createMatch(UserInfo user, Dictionary<string, object> args)
        {
            return null;
        }

        public MatchInfo joinMatch(UserInfo user, int matchId)
        {
            return null;
        }

        public MatchInfo leaveMatch(UserInfo user, int matchId)
        {
            return null;
        }

        public MatchInfo observe(UserInfo user, int matchId)
        {
            return null;
        }

        public MatchInfo[] listMatches()
        {
            return null;
        }

        public BoardInfo[] getAvailableBoardTemplates()
        {
            return null;
        }
    }
}