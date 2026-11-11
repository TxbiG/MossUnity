using UnityEditor;
using UnityEngine;

namespace MossUnity.Editor
{
    [CustomEditor(typeof(MossPhysicsBody))]
    [CanEditMultipleObjects]
    internal sealed class MossPhysicsBodyEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EditorGUILayout.Space();
            EditorGUILayout.HelpBox(
                "MossSharp physics integration is not connected yet. " +
                "This component currently stores Unity-side configuration only.",
                MessageType.Info);
        }
    }
}
