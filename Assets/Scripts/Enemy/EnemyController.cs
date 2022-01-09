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
            _timerSystem = timerSystem;
            _objectPool = objectPool;
        }
        public void Execute(float deltaTime)
        {
            if (_timerSystem.CheckEvent())
            {
                var enemy = _objectPool.Pop();
            }
        }
    }
}