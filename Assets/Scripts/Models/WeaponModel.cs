namespace GeekSpace
{
    internal sealed class WeaponModel : IModel
    {
        private int _damage;
        private float _cooldown;
        private IPool _pool;
        private WeaponType _weaponType;

        public IPool Pool
        {
            get { return _pool; }
            set { _pool = value; }
        }
        public WeaponType WeaponType
        {
            get { return _weaponType; }
        }
        public int Damage
        {
            get { return _damage; }
        }
        public float Cooldown
        {
            get { return _cooldown; }
        }

        public WeaponModel(IPool pool, WeaponType weaponType, int damage, float cooldown)
        {
            _pool = pool;
            _weaponType = weaponType;
            _damage = damage;
            _cooldown = cooldown;
        }
    }
}

