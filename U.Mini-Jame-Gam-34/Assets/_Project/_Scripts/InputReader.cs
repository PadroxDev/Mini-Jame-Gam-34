using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace MJG_34 {
    [RequireComponent(typeof(PlayerInput))]
    public class InputReader : MonoBehaviour {
        public UnityEvent OnAlpha1;
        
        PlayerInput _playerInput;
        InputAction _mousePosAction;
        InputAction _alpha1Action;

        public Vector2 MousePos => _mousePosAction.ReadValue<Vector2>();

        void Awake() {
            _playerInput = GetComponent<PlayerInput>();
            _mousePosAction = _playerInput.actions["MousePosition"];
            _alpha1Action = _playerInput.actions["Alpha1"];
        }

        void OnEnable() {
            _alpha1Action.performed += Alpha1Performed;
        }

        void OnDisable() {
            _alpha1Action.performed -= Alpha1Performed;
        }

        void Alpha1Performed(InputAction.CallbackContext ctx) {
            OnAlpha1?.Invoke();
        }
    }
}
