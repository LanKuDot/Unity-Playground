using UnityEditor;
using UnityEngine;

namespace PlayGround_09.Editor
{
    [CustomEditor(typeof(Path))]
    public class PathEditor : UnityEditor.Editor
    {
        private bool _isEditing;
        private PathEditorOverlay _editorOverlay;

        [DrawGizmo(GizmoType.NonSelected | GizmoType.Selected)]
        private static void DrawGizmos(Path path, GizmoType gizmoType)
        {
            var points = path.Points;
            if (points.Count < 2)
                return;

            var localToWorldMatrix = path.transform.localToWorldMatrix;

            Gizmos.matrix = localToWorldMatrix;
            Gizmos.color = Color.green;
            Gizmos.DrawLineStrip(points.ToArray(), true);

            foreach (var point in points)
            {
                Gizmos.color = new Color(0, 0, 1.0f, 0.5f);
                Gizmos.DrawSphere(point, 0.2f);
            }

            var firstPoint = points[0];
            var secondPoint = points[1];
            var vector = secondPoint - firstPoint;
            using (new Handles.DrawingScope(Color.cyan, localToWorldMatrix))
            {
                Handles.ArrowHandleCap(
                    0,
                    firstPoint, Quaternion.FromToRotation(Vector3.forward, vector),
                    Mathf.Min(HandleUtility.GetHandleSize(firstPoint), 5f),
                    EventType.Repaint);
            }
        }

        private void OnEnable()
        {
            _editorOverlay = new PathEditorOverlay(OnEditingTrigger);
            SceneView.AddOverlayToActiveView(_editorOverlay);
            _editorOverlay.displayed = true;
        }

        private void OnDisable()
        {
            SceneView.RemoveOverlayFromActiveView(_editorOverlay);
        }

        private void OnEditingTrigger(bool isEditing)
        {
            _isEditing = isEditing;
        }

        private void OnSceneGUI()
        {
            if (!_isEditing)
                return;

            var path = (Path)target;

            using (new Handles.DrawingScope(path.transform.localToWorldMatrix))
            {
                for (var i = 0; i < path.Points.Count; ++i)
                {
                    EditorGUI.BeginChangeCheck();
                    var newPosition = Handles.PositionHandle(path.Points[i], Quaternion.identity);
                    if (EditorGUI.EndChangeCheck())
                    {
                        Undo.RecordObject(path, "Change path position");
                        newPosition.y = 1;
                        path.Points[i] = newPosition;
                    }
                }
            }
        }
    }
}
