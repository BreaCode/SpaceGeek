using UnityEngine;
internal sealed class EnemyModel
{
    private string _pathToPrefab;
    private EnemyType _enemyType;
    private Vector3 _transform;
    private int _healthPoitns;
    private float _speed;
    public string PathToPrefab 
    {
        get { return _pathToPrefab; }
    }
    public EnemyType EnemyType
    {
        get { return _enemyType; }
    }
    public Vector3 Position
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

    public EnemyModel(string pathToPrefab, EnemyType enemyType, Vector3 position, int healthPoitns, float speed)
    {
        _pathToPrefab = pathToPrefab;
        _enemyType = enemyType;
        _transform = position;
        _healthPoitns = healthPoitns;
        _speed = speed;
    }
}
