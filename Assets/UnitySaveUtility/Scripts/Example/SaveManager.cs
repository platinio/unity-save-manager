using UnityEngine;

namespace Platinio.Save
{
    [CreateAssetMenu(fileName = "SaveManager", menuName = "Save Manager")]
    public class SaveManager : GenericSaveManager<PlayerSaveData>
    {
        [SerializeField] private SaveSlot saveSlot = null;
    }
}
