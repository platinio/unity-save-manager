using UnityEngine;
using UnityEditor;
using Platinio.Encryption;

namespace Platinio.SaveUtility
{
    [CustomEditor(typeof(UnitySaveManager))]
    public class UnitySaveManagerInspector : Editor
    {

        private UnitySaveManager saveManager = null;

        private void OnEnable()
        {
            saveManager = (UnitySaveManager)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Save"))
            {
                saveManager.Save();
            }

            if (GUILayout.Button("Load"))
            {
                saveManager.Load();
            }

        }
    }

}
