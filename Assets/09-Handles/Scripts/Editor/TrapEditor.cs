using UnityEditor;
using UnityEngine;

namespace PlayGround_09.Editor
{
[CustomEditor(typeof(Trap))]
public class TrapEditor : UnityEditor.Editor
{
    [DrawGizmo(GizmoType.Selected)]
    private static void DrawGizmos(Trap trap, GizmoType gizmoType)
    {
        var textStyle =
            new GUIStyle {
                normal = { textColor = Color.black }
            };

        var trapTransform = trap.transform;
        var trapPosition = trapTransform.position;
        var detectionDistance = trap.DetectionDistance;

        Handles.Label(
            trapPosition + Vector3.right * (detectionDistance + 0.5f),
            $"Distance: {detectionDistance:F2}",
            textStyle);

        var color = GetColor(trap.Color);
        if (trap.ShowSolidDisc)
        {
            using (new Handles.DrawingScope(new Color(color.r, color.g, color.b, 0.3f)))
                Handles.DrawSolidDisc(trapPosition, Vector3.up, detectionDistance);
        }
        else
        {
            using (new Handles.DrawingScope(color))
                Handles.DrawWireDisc(trapPosition, Vector3.up, detectionDistance, 5);
        }
    }

    private static Color GetColor(Trap.ShowingColor showingColor)
    {
        return showingColor switch
        {
            Trap.ShowingColor.X => Handles.xAxisColor,
            Trap.ShowingColor.Y => Handles.yAxisColor,
            Trap.ShowingColor.Z => Handles.zAxisColor,
            Trap.ShowingColor.Selected => Handles.selectedColor,
            _ => Color.white,
        };
    }
}
}
