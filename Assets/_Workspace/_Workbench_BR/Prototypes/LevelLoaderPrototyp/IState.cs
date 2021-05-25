namespace LunarLander.Prototypes.BR.LevelLoaderProtyp
{
    public interface IState
    {
        void OnEnter();

        void OnUpdate();

        void OnExit();
    }
}