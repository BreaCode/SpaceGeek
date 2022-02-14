namespace GeekSpace
{
    public struct Entity
    {
        public float _speed;
        public float _maxSpeed;
        public int _HP;
        public int _maxHP;
        public float _speedFire;
        public float _maxSpeedFire;
        public int _shootBlocked;
        public Entity(float speed, int hp, float speedFire)
        {
            this._speed = speed;
            this._maxSpeed = _speed * 2;
            this._HP = hp;
            this._maxHP = _HP * 2;
            this._speedFire = speedFire;
            this._maxSpeedFire = _speedFire * 2;
            this._shootBlocked = 0;
        }
        public Entity(float speed, float maxSpeed, int hp, int maxHp, float speedFire, float maxSpeedFire)
        {
            this._speed = speed;
            this._maxSpeed = maxSpeed;
            this._HP = hp;
            this._maxHP = maxHp;
            this._speedFire = speedFire;
            this._maxSpeedFire = maxSpeedFire;
            this._shootBlocked = 0;
        }
    }
}
