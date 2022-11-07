using UnityEngine;

namespace KasherOriginal.GlobalStateMachine
{
    public class MainMenuState : State<GameInstance>
    {
        public MainMenuState(GameInstance context) : base(context)
        {

        }

        public override void Enter()
        {
            Debug.Log("1");
        }
    }
}