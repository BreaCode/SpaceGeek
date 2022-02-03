
namespace GeekSpace
{
    internal interface IAbstractGameFactory
    {
        InputInitialization SetInput();
        void CreatePlayer();
        void CreateEnemy();

    }
}