using UnityEngine;
using UnityEngine.InputSystem;

namespace CatTarot.Core.Input
{
    public class InputHandler
    {
        public Vector2 MouseDelta => Instance.mouseDelta.ReadValue<Vector2>();
        public Vector2 Scroll => Instance.scroll.ReadValue<Vector2>();
        public bool InteractPressed => Instance.interact.WasPressedThisFrame();
        public bool InteractReleased => Instance.interact.WasReleasedThisFrame();

        private static InputHandler instance;

        public static InputHandler Instance
        {
            get
            {
                if (instance == null)
                    instance = new InputHandler();

                return instance;
            }
        }

        private InputHandler()
        {
            mouseDelta = InputSystem.actions.FindAction("MouseDelta");
            interact = InputSystem.actions.FindAction("Interact");
            scroll = InputSystem.actions.FindAction("Scroll");
        }

        #region Player Movement
        private InputAction mouseDelta;
        private InputAction scroll;
        private InputAction interact;

        #endregion

        #region UI Navigation

        #endregion

    }
}