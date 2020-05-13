using UnityEngine;
using UnityEditor;
using Platinio.Encryption;

namespace Platinio.SaveUtility
{
    [CustomEditor(typeof(UnitySaveManager))]
    public class UnitySaveManagerInspector : Editor
    {

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Encrypt Test"))
            {
                string value = "James Ricardo Roman Caceres 25";
                Debug.Log("encrypt test " + value);
                string result = EncryptionUtility.Encrypt(value);
                Debug.Log("encrypt result " + result);
                Debug.Log("decrypt test ");
                result = EncryptionUtility.Decrypt(result);
                Debug.Log("decryption value " + result);
            }

        }
    }

}
