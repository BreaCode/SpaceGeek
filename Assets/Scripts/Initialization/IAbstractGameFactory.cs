
namespace GeekSpace
{
    internal interface IAbstractGameFactory
    {
        IInputInitialisation SetInput(IInputInitialisation inputInitialisation);
        void CreatePlayer();
        void CreateEnemy();

    }
}