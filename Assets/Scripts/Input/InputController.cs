namespace GeekSpace
{
    public sealed class InputController : IExecute
    {
        private readonly IUserInputProxy _horizontal;
        private readonly IUserInputProxy _vertical;
        private readonly IUserInputFire _fire;

        internal IUserInputProxy Horizontal
        {
            get { return _horizontal; }
        }
        internal IUserInputProxy Vertical
        {
            get { return _vertical; }
        }
        internal IUserInputFire Fire
        {
            get { return _fire; }
        }

        public InputController((IUserInputProxy inputHorizontal, IUserInputProxy inputVertical, IUserInputFire inputFire1) input)
        {
            _horizontal = input.inputHorizontal;
            _vertical = input.inputVertical;
            _fire = input.inputFire1;
        }

        public void Execute(float deltaTime)
        {
            _horizontal.GetAxis();
            _vertical.GetAxis();
            _fire.GetFire();
        }
    }
}