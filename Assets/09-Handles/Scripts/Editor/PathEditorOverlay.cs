using System;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UIElements;

namespace PlayGround_09.Editor
{
    public class PathEditorOverlay : Overlay
    {
        private bool _isEditing;
        private Button _editingButton;
        private Action<bool> _onEditingTrigger;

        public PathEditorOverlay(Action<bool> onEditingTrigger)
        {
            displayName = "Path Editing";

            _onEditingTrigger = onEditingTrigger;
        }

        public override VisualElement CreatePanelContent()
        {
            var root = new VisualElement();
            _editingButton = new Button(OnEditingButtonClick)
            {
                text = "Start Editing"
            };
            root.Add(_editingButton);

            return root;
        }

        private void OnEditingButtonClick()
        {
            _isEditing = !_isEditing;
            _editingButton.text = _isEditing ? "End Editing" : "Start Editing";
            _onEditingTrigger.Invoke(_isEditing);
        }
    }
}
