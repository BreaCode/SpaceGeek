using System.Collections.Generic;
using UnityEngine;

namespace GeekSpace
{
    internal sealed class ObjectPool : IPool
    {
        private readonly Stack<GameObject> _stack = new Stack<GameObject>();
        private readonly GameObject _prefab;
        private readonly ParrentStruct _parent;
        private readonly Transform _rootPool;

        public ObjectPool(GameObject prefab, ParrentStruct parent)
        {
            _prefab = prefab;
            _parent = parent;

            if (_rootPool == null)
            {
                //if (_name == PoolName.POOL_ENEMY_SHIP)
                //{
                //    _rootPool = new GameObject(NameManager.POOL_ENEMY_SHIP).transform;
                //}
                //if (_name == PoolName.POOL_ENEMY_ASTEROID)
                //{
                //    _rootPool = new GameObject(NameManager.POOL_ENEMY_ASTEROID).transform;
                //}
                //if (_name == PoolName.POOL_ENEMY_BULLET)
                //{
                //    _rootPool = new GameObject(NameManager.POOL_ENEMY_BULLET).transform;
                //}
                _rootPool = new GameObject(parent._name).transform;
            }
        }

        public void Push(GameObject go)
        {
            _stack.Push(go);
            go.transform.position = _parent._pos;
            go.transform.SetParent(_rootPool);
            go.SetActive(false);
        }

        public GameObject Pop(Vector3 position,Quaternion quaternion)
        {
            GameObject go;
            if (_stack.Count == 0)
            {
                go = Object.Instantiate(_prefab, _parent._pos, quaternion);
            }
            else
            {
                go = _stack.Pop();
                go.transform.position = position;
                go.transform.rotation = quaternion;

            }
            go.SetActive(true);
            return go;
        }
    }
    public struct ParrentStruct
    {
        public Vector2 _pos { get; }
        public string _name { get; }
        public ParrentStruct(Vector2 pos, string name)
        {
            this._name = name;
            this._pos = pos;
        }
    }
}