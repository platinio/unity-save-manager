﻿using UnityEngine;

namespace Platinio.SaveUtility
{
    [CreateAssetMenu (fileName = "SaveGame" , menuName = "Save Game") ]
    public class SaveGame : ScriptableObject
    {
        [SerializeField] private PlaceHolderType saveData = null;       

        public string ToJson()
        {
            return JsonUtility.ToJson(saveData);
        }

        public void FromJson(string json)
        {
            saveData = JsonUtility.FromJson<PlaceHolderType>(json);
        }

    }

}

