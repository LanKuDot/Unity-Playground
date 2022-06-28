﻿using UnityEngine;

namespace PlayGround_07
{
    public class PathEnemy : Enemy
    {
        [SerializeField]
        private Transform[] _pathPoints;
        [SerializeField]
        private PathEnemyData _data;

        private Vector3 _movingVector;
        private int _currentIndex;
        private float _timeRemain;

        private void Awake()
        {
            enemyData = _data;
        }

        private new void Start()
        {
            base.Start();
            transform.position = _pathPoints[0].position;
            SetNextPoint();
        }

        private void FixedUpdate()
        {
            _timeRemain -= Time.deltaTime;
            if (_timeRemain < 0)
                SetNextPoint();

            Move(_data.movingVelocity * Time.deltaTime * _movingVector);
        }

        /// <summary>
        /// Set up the next target point
        /// </summary>
        private void SetNextPoint()
        {
            _currentIndex =
                (int) Mathf.Repeat(_currentIndex + 1, _pathPoints.Length);

            var deltaPosition =
                _pathPoints[_currentIndex].position - transform.position;
            deltaPosition.y = 0;
            var distance = deltaPosition.magnitude;

            _movingVector = deltaPosition.normalized;
            _timeRemain = distance / _data.movingVelocity;
        }
    }
}
