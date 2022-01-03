using UnityEngine;
internal sealed class EnemyModel
{
    private string _pathToPrefab;
    private EnemyType _enemyType;
    private Transform _transform;
    private int _healthPoitns;
    private float _speed;

    public EnemyType EnemyType
    {
        get { return _enemyType; }
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

    public EnemyModel(string pathToPrefab, EnemyType enemyType, Transform transform, int healthPoitns, float speed)
    {
        _pathToPrefab = pathToPrefab;
        _enemyType = enemyType;
        _transform = transform;
        _healthPoitns = healthPoitns;
        _speed = speed;
    }
}
