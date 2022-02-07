namespace GeekSpace
{
    internal interface IAbstractGameFactoryMultyPlayer:IAbstractGameFactory
    {
        IInputInitialisation SetInputTwo(IInputInitialisation inputInitialisation);
    }
}