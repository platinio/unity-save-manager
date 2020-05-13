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
        [SerializeField] private bool debug = false;

        private const string fileName = "saveData.json";

        public string FilePath 
        {
            get
            {
                return Path.Combine(Application.persistentDataPath, fileName);
            }
        }

        public string FolderPath
        {
            get
            {
                return Application.persistentDataPath;
            }
        }

        public void Save()
        {
            string json = saveGame.ToJson();

            if (debug)
            {
                Debug.Log("saving json " + json);
            }
            

            if (encrypt)
            {
                json = EncryptionUtility.Encrypt(json);
            }
            
            
            File.WriteAllText(FilePath , json);
        }

        public void Load()
        {
            string json = File.ReadAllText(FilePath);

            if (debug)
            {
                Debug.Log("reading json " + json);        
            }

            if (encrypt)
            {
                json = EncryptionUtility.Decrypt(json);
            }

            saveGame.FromJson(json);
        }

    }
}

