using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class Tools 
    {
        [MenuItem("Tools/ClearPrefs")]
        public static void ClearPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        }
    }
}