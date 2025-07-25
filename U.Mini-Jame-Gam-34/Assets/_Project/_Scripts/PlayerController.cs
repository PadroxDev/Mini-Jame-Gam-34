using Padrox.Acelab;
using Padrox.Acelab.Core;
using UnityEngine;

namespace MJG_34 {
    public class PlayerController : MonoBehaviour {
        const float k_raycastDistance = 1000f;
        
        [SerializeField] Transform _rootModel;
        [SerializeField] float _rotationSpeed = 5f;
        
        InputReader _inputReader;
        RaycastHit _hit;
        Vector3 _targetDir;

        void Start() {
            _inputReader = gameObject.GetOrAdd<InputReader>();
        }

        void Update() {
            CalculateTargetDirection();
            RotateTowardTarget();
        }

        void CalculateTargetDirection() {
            Vector2 mousePos = _inputReader.MousePos;
            Ray ray = Acer.Camera.ScreenPointToRay(mousePos);
            if (!Physics.Raycast(ray, out _hit, k_raycastDistance)) return;
            
            Vector3 target = _hit.point.With(y: _rootModel.position.y);
            _targetDir = (target - _rootModel.position).normalized;
        }
        
        void RotateTowardTarget() {
            Quaternion targetRotation = Quaternion.LookRotation(_targetDir, Vector3.up);
            _rootModel.rotation = Quaternion.Slerp(_rootModel.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }
}