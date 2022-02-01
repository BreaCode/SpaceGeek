using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekSpace
{
    internal class MoveTransformEnemy : IMoveble
    {
        private EnemyModel _enemyModel;
        private GameObject _player;
        private GameObject _playerTwo;
        public MoveTransformEnemy(EnemyModel enemyModel, GameObject player, GameObject playerTwo)
        {
            _enemyModel = enemyModel;
            _player = player;
            _playerTwo = playerTwo;
        }

        public void Move(Transform transform)
        {
            var speed = _enemyModel.Speed * Time.deltaTime;
            var pos = Vector2.MoveTowards(transform.position, _player.transform.position, speed);
            var posTwo = Vector2.MoveTowards(transform.position, _playerTwo.transform.position, speed);
            transform.position = new Vector2(pos.x, transform.position.y);
        }
    }
}