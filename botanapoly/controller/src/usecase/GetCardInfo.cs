using database;
using model;

namespace controller{
    public class GetCardInfo : IUseCaseFunctionality<CardInfo> {

        private readonly IMatchRepository _matchRepository;
        private readonly CardInfo _cardInfo;

        public GetCardInfo(IMatchRepository matchRepository, CardInfo cardInfo)
        {
            _matchRepository = matchRepository;
            _cardInfo = cardInfo;
        }

        public CardInfo execute()
        {
            return _matchRepository.getCardInfo(_cardInfo);
        }
    }
}