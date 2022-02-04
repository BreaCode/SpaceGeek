namespace GeekSpace
{
    public sealed class InputControllerTwo : IExecute
    {
        private readonly IInputInitialisation _inputOne;
        private readonly IInputInitialisationTwo _inputTwo;

        internal InputControllerTwo(IInputInitialisation inputOne, IInputInitialisationTwo inputTwo)
        {
            _inputOne = inputOne;
            _inputTwo = inputTwo;
        }

        public void Execute(float deltaTime)
        {
            if (_inputOne is InputInitialisationBtns initialisationBtnsOne)
            {
                initialisationBtnsOne.GetUp();
                initialisationBtnsOne.GetDown();
                initialisationBtnsOne.GetLeft();
                initialisationBtnsOne.GetRight();
            }

            if (_inputTwo is InputInitialisationBtnsTwo initialisationBtnsTwo)
            {
                initialisationBtnsTwo.GetUp();
                initialisationBtnsTwo.GetDown();
                initialisationBtnsTwo.GetLeft();
                initialisationBtnsTwo.GetRight();
            }
        }
    }
}
