using UnityEngine;

namespace KasherOriginal.Factories.UIFactory
{
    public interface IUIInfo
    {
        public GameObject MenuLoadingScreen { get; }
        public GameObject MainMenuScreen { get; }
        public GameObject GameLoadingScreen { get; }
        public GameObject GameplayScreen { get; }
    }
}

