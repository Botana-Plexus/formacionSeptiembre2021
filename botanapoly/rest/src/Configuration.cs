using System;
using System.Collections.Generic;
using System.Linq;
using controller;
using database;
using model;
using rest.service;

namespace rest{
    public class Configuration{
        private static Configuration _instance;
        private static object _lock = new();

        private readonly GameStateControlFlow<TurnState, TurnAction> _states;
        private readonly IMatchRepository _matchRepository;
        private readonly IApiKeyStore _apiKeyStore;
        private readonly IConnectionFactory _connectionFactory;

        private protected Configuration()
        {
            var actions = new[]
            {
                TurnAction.ROLL_1_2,
                TurnAction.ROLL_3,
                TurnAction.GIVE_UP,
                TurnAction.PAY_RENT,
                TurnAction.MOVEMENT,
                TurnAction.PAY_TO_CARD,
                TurnAction.CARD_ACTION,
                TurnAction.BUY_PROPERTY,
                TurnAction.SELL_PROPERTY,
                TurnAction.RECEIVE_FROM_CARD,
                TurnAction.DECREASE_EDIFICATION_LEVEL,
                TurnAction.INCREASE_EDIFICATION_LEVEL
            };
            var states = new Dictionary<TurnState, List<TurnState>>()
            {
                {
                    TurnState.INITIALIZED, new TurnState[]
                    {
                        TurnState.ROLLED,
                        TurnState.FINALIZED,
                        TurnState.FINALIZED,
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.INITIALIZED
                    }.ToList()
                },
                {
                    TurnState.ROLLED, new TurnState[]
                    {
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.FINALIZED,
                        TurnState.FINALIZED,
                        TurnState.ROLLED,
                        TurnState.FINALIZED,
                        TurnState.NULL,
                        TurnState.FINALIZED,
                        TurnState.ROLLED,
                        TurnState.FINALIZED,
                        TurnState.ROLLED,
                        TurnState.NULL
                    }.ToList()
                },
                {
                    TurnState.FINALIZED, new TurnState[]
                    {
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.NULL,
                        TurnState.NULL
                    }.ToList()
                }
            };
            _states = new GameStateControlFlow<TurnState, TurnAction>(actions.ToList(), states);
            _connectionFactory = new SqlServerConnectionFactory("localhost", "botanapoly", "pruebas", "pruebas");
            _matchRepository = new MatchRepositorySqlServerDb(_connectionFactory);
            _apiKeyStore = new ApiKeyStoreMock(_matchRepository);
            foreach (var user in _matchRepository.getUsers(u => true)) _apiKeyStore.register(string.Format("asda1sda{0}sd", user.Id), user.Id);
        }

        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                    lock (_lock)
                    {
                        if (_instance == null) _instance = new Configuration();
                    }

                return _instance;
            }
        }

        public GameStateControlFlow<TurnState, TurnAction> States => _states;

        public IMatchRepository MatchRepository => _matchRepository;

        public IApiKeyStore ApiKeyStore => _apiKeyStore;

        public IConnectionFactory ConnectionFactory => _connectionFactory;
    }
}