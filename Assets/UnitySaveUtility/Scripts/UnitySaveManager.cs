using UnityEngine;
using System.IO;
using Platinio.Encryption;

namespace Platinio.SaveUtility
{
    [CreateAssetMenu(fileName = "UnitySaveManager", menuName = "UnitySaveManager")]
    public class UnitySaveManager : ScriptableObject
    {
        [SerializeField] private SaveGame saveGame = null;
        [SerializeField] private bool encrypt = false;

        private const string fileName = "saveData.json";

        public void Save()
        {
            string json = saveGame.ToJson();

            if (encrypt)
            {
                json = EncryptionUtility.Encrypt(json);
            }

            string filePath = Path.Combine(Application.persistentDataPath , fileName);
            File.WriteAllText(filePath , json);
        }

        public void Load()
        {
            string filePath = Path.Combine(Application.persistentDataPath, fileName);
            string json = File.ReadAllText(filePath);

            if (encrypt)
            {
                json = EncryptionUtility.Decrypt(json);
            }

            saveGame.FromJson(json);
        }

    }
}

