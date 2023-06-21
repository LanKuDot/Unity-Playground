using PlayGround_07;
using UnityEditor;
using UnityEngine;

namespace PlayGround_08.Editor
{
    [CustomEditor(typeof(ChaseEnemy))]
    [CanEditMultipleObjects]
    public class ChaseEnemyEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.NonSelected | GizmoType.Active)]
        private static void DrawGizmos(ChaseEnemy chaseEnemy, GizmoType gizmoType)
        {
            var labelStyle =
                new GUIStyle {
                    normal = { textColor = Color.black },
                };

            var cameraTransform = SceneView.currentDrawingSceneView.camera.transform;
            var transform = chaseEnemy.transform;

            var chaseEnemyData = chaseEnemy.Data;
            var labelStr =
                chaseEnemyData == null
                    ? "-- Data not set --"
                    : gizmoType.HasFlag(GizmoType.NonSelected)
                        ? chaseEnemyData.GetSimpleSceneDisplayInfo()
                        : chaseEnemyData.GetSceneDisplayInfo();

            Handles.Label(
                transform.position + cameraTransform.right + cameraTransform.up,
                labelStr, labelStyle);
        }
    }
}
