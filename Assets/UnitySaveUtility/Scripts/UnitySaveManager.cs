using UnityEngine;

namespace Platinio.SaveUtility
{
    [CreateAssetMenu(fileName = "UnitySaveManager", menuName = "UnitySaveManager")]
    public class UnitySaveManager : ScriptableObject
    {
        [SerializeField] private SaveGame saveGame = null;

        public void Save()
        {
            
        }

        public void Load()
        {
            
        }

    }
}

