using UnityEngine;

namespace Platinio.Save
{
    public class GenericSaveManager<T> : ScriptableObject
    {
        [SerializeField] private GenericSaveSlot<T> saveSlot = null;
    }
}
