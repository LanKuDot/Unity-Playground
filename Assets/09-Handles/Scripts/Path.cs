using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PlayGround_09
{
    public class Path : MonoBehaviour
    {
        [SerializeField]
        private List<Vector3> _points = new() {
            new Vector3(-1, 1, 0),
            new Vector3(1, 1, 0)
        };

#if UNITY_EDITOR
        public List<Vector3> Points => _points;
#endif

        private int _targetPointIndex;
        private Vector3 _targetPosition;
        private Vector3 _curPosition;

        private void OnValidate()
        {
            var numOfPoints = _points.Count;
            for (var i = 0; i < numOfPoints; ++i)
            {
                var point = _points[i];
                point.y = 1;
                _points[i] = point;
            }
        }

        private void Awake()
        {
            if (_points.Count < 2) {
                Debug.LogError("There should be at least 2 points for the path");
                return;
            }

            _curPosition = transform.TransformPoint(_points[0]);
            _targetPointIndex = 1;
            _targetPosition = transform.TransformPoint(_points[_targetPointIndex]);
        }

        public Vector3 GetNextPosition(float distance)
        {
            if (Mathf.Approximately(distance, 0f))
                return _curPosition;

            var movingVector = _targetPosition - _curPosition;
            var remainingDistance = movingVector.magnitude;

            if (remainingDistance - distance > 0) {
                _curPosition += movingVector.normalized * distance;
            } else {
                var exceededDistance = distance - remainingDistance;

                _targetPointIndex = (int)Mathf.Repeat(_targetPointIndex + 1, _points.Count);
                var nextTargetPoint = transform.TransformPoint(_points[_targetPointIndex]);
                
                movingVector = nextTargetPoint - _targetPosition;
                _curPosition = _targetPosition + movingVector.normalized * exceededDistance;
                _targetPosition = nextTargetPoint;
            }

            return _curPosition;
        }
    }
}
