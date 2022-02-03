namespace GeekSpace
{
    public sealed class InputController : IExecute
    {
        private readonly IInputInitialisation _input;

        internal InputController(IInputInitialisation input)
        {
            _input = input;
        }

        public void Execute(float deltaTime)
        {
            if (_input is InputInitializatioAxis initializatioAxis)
            {
                initializatioAxis.GetInput().inputHorizontal.GetAxis(InputManager.HORIZONTAL);
                initializatioAxis.GetInput().inputVertical.GetAxis(InputManager.VERTICAL);
                initializatioAxis.GetInput().pcIinputFire.GetFire();
            }
            if (_input is InputInitialisationBtns initialisationBtns)
            {
                initialisationBtns.GetUp();
                initialisationBtns.GetDown();
                initialisationBtns.GetLeft();
                initialisationBtns.GetRight();

            }
        }
    }
}