using System;
using System.Collections.Generic;
using System.Linq;
using controller;
using model;

namespace database.model{
    public class Parsers{

        public static MatchInfo parseMatch(object[] o)
        {
            return new MatchInfo((int) o[0], (string) o[1], -1, (int) o[2], (int) o[3], -1, (bool) o[5], (int) o[6], (int) o[7], (int) o[8], (int) o[9], new List<int>());
        }

        public static SquareInfo parseSquare(object[] o)
        {
            int? currentEdificationLevel = o.Length > 16 ? (int) o[17] : null;
            return new SquareInfo((int) o[0], (SquareType) o[1], (int) -1, (string) o[2], (int) o[3], (double) o[4], (double) o[5], (double) o[6], (double) o[7], new double[] {(double) o[8], (double) o[9], (double) o[10], (double) o[11], (double) o[12]}.ToList(), (int) o[13], (int) o[14], (int) o[16], currentEdificationLevel);
        }

        public static CardInfo parseCard(object[] o)
        {
            return new CardInfo((int) o[0], (int) -1, (string) o[1], "", (int) o[3], (int) o[2]);
        }

        public static BoardInfo parseBoard(object[] o)
        {
            return new BoardInfo((int)o[0], (string)o[1], new List<int>((int)o[3]), (double)o[2]);
        }

        public static PlayerInfo parsePlayer(object[] o)
        {
            return new PlayerInfo((int)o[0], (int)o[1], (int)o[2], (double)o[3], (int)o[5], (int)o[4], (int)o[7], (int)o[6], (double)o[8], (int)o[9]);
        }

        public static UserInfo parseUser(object[] o)
        {
            TimeSpan ts = DateTime.Parse((string) o[4]) - new DateTime(1970, 1, 1);
            return new UserInfo((int) o[0], (string) o[1], (string) o[2], (string) o[3], (long)ts.TotalSeconds);
        }
    }
}