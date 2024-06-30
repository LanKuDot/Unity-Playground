using UnityEditor;
using UnityEngine;

namespace PlayGround_09.Editor
{
    [CustomEditor(typeof(TrapTrigger))]
    public class TrapTriggerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Selected)]
        private static void DrawGizmos(TrapTrigger trapTrigger, GizmoType gizmoType)
        {
            var targetTrap = trapTrigger.Trap;
            if (targetTrap == null)
                return;

            var drawingGameObjects = new GameObject[1];
            drawingGameObjects[0] = targetTrap.gameObject;
            Handles.DrawOutline(drawingGameObjects, Color.green, 0.5f);

            var triggerPosition = trapTrigger.transform.position;
            var trapPosition = targetTrap.transform.position;
            using (new Handles.DrawingScope(Color.green))
                Handles.DrawDottedLine(triggerPosition, trapPosition, 4);
        }
    }
}
