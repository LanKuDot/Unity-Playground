using UnityEditor;

namespace PlayGround_04.Editor
{
    [CustomEditor(typeof(ObjectPool))]
    public class ObjectPoolEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            UpdateItemName();
        }

        private void UpdateItemName()
        {
            var poolItemsProp = serializedObject.FindProperty("_objectPoolItems");
            var numOfItems = poolItemsProp.arraySize;

            for (var i = 0; i < numOfItems; ++i) {
                var itemProp = poolItemsProp.GetArrayElementAtIndex(i);
                var nameProp = itemProp.FindPropertyRelative("_name");
                var prefabObject =
                    itemProp.FindPropertyRelative("_prefab").objectReferenceValue;

                nameProp.stringValue =
                    prefabObject ? prefabObject.name : "-- Unassigned --";
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
