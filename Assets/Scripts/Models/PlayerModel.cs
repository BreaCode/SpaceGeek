using UnityEngine;
internal sealed class PlayerModel
{
    private string _pathToPrefab;
    private WeaponType _weaponType;
    private Transform _transform;
    private int _healthPoitns;
    private float _speed;

    public WeaponType WeaponType
    {
        get { return _weaponType; }
    }
    public Transform Transform
    {
        get { return _transform; }
    }
    public int HealthPoitns
    {
        get { return _healthPoitns; }
    }
    public float Speed
    {
        get { return _speed; }
    }

    public PlayerModel(string pathToPrefab, WeaponType weaponType, Transform transform, int healthPoitns, float speed)
    {
        _pathToPrefab = pathToPrefab;
        _weaponType = weaponType;
        _transform = transform;
        _healthPoitns = healthPoitns;
        _speed = speed;
    }
}
