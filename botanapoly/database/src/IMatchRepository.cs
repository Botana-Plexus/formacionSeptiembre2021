using System;
using System.Collections.Generic;
using model;

namespace database{
    public interface IMatchRepository : IRepository<MatchInfo, int>{
        SquareInfo findSquare(int matchId, int squareId);
        List<SquareInfo> findAllSquares(int matchId, Func<SquareInfo, bool> filter);
        SquareInfo saveOrUpdateSquare(int matchId, SquareInfo squareInfo);
        void deleteSquare(int matchId, SquareInfo squareInfo);
        bool existsSquare(int matchId, int squareId);
        bool existsSquare(int matchId, SquareInfo squareInfo);

        BoardInfo updateBoard(BoardInfo boardInfo);
    }
}