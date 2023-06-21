using UnityEditor;
using UnityEngine;

namespace PlayGround_08.Editor
{
    [CustomEditor(typeof(DoorTrigger))]
    [CanEditMultipleObjects]
    public class DoorTriggerEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.NonSelected | GizmoType.Active | GizmoType.Pickable)]
        private static void DrawGizmos(DoorTrigger doorTrigger, GizmoType gizmoType)
        {
            var trigger = doorTrigger.Trigger;
            var center = trigger.center;
            var size = trigger.size;
            Gizmos.matrix = doorTrigger.transform.localToWorldMatrix;
            Gizmos.color = new Color(0, 1, 0, 0.5f);
            Gizmos.DrawCube(center, size);
        }
    }
}
