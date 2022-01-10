using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace GeekSpace
{
    internal sealed class EnemyController : IExecute
    {
        private readonly TimerSystem _timerSystem;
        private readonly ObjectPool _objectPool;
        internal EnemyController(TimerSystem timerSystem, ObjectPool objectPool)
        {
            if (timerSystem == null) throw new Exception("TimerSystem is null");
            if (objectPool == null) throw new Exception("ObjectPool is null");

            _timerSystem = timerSystem;
            _objectPool = objectPool;
        }
        public void Execute(float deltaTime)
        {
            if (_timerSystem.CheckEvent())
            {
                _objectPool.Pop();
            }
        }
    }
}