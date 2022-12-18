using Assets.Plugins.Script.Extra;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    [CustomPropertyDrawer(typeof(EnumFlags))]
    public class EnumFlagsDrawer : PropertyDrawer //多选枚举绘制器
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            base.OnGUI(position, property, label);
            property.intValue = EditorGUI.MaskField
                (position, label, property.intValue, property.enumNames);
        }
    }
}