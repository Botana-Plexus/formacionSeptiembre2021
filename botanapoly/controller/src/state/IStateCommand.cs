namespace controller{
    public interface IStateCommand<S, A>{
        bool validate(S currentState, A action);
        S execute(S currentState, A action);
    }
}