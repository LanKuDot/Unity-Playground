using UnityEditor;
using UnityEngine;

namespace PlayGround_09.Editor
{
    [CustomEditor(typeof(Trap))]
    public class TrapEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active)]
        private static void DrawGizmos(Trap trap, GizmoType gizmoType)
        {
            var textStyle =
                new GUIStyle {
                    normal = { textColor = Color.black }
                };

            var trapTransform = trap.transform;
            var detectionDistance = trap.DetectionDistance;

            Handles.Label(
                trapTransform.position + Vector3.right * (detectionDistance + 0.5f),
                $"{detectionDistance:F2}",
                textStyle);
        }

        private void OnSceneGUI()
        {
            var trap = (Trap)target;
            var trapTransform = trap.transform;

            EditorGUI.BeginChangeCheck();

            float detectionDistance;
            using (new Handles.DrawingScope(Color.cyan)) {
                detectionDistance =
                    Handles.RadiusHandle(
                        Quaternion.identity,
                        trapTransform.position,
                        trap.DetectionDistance);
            }

            if (EditorGUI.EndChangeCheck()) {
                Undo.RecordObject(target, "Change detection distance");
                trap.DetectionDistance = detectionDistance;
            }
        }
    }
}
