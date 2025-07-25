using System;
using UnityEngine;

namespace MJG_34 {
    public class Tomato : MonoBehaviour {
        
        [SerializeField] ParticleSystem _particles;

        Material _mat;
        int _blendAmount;
        
        void Awake() {
            _mat = GetComponent<MeshRenderer>().material;
            _blendAmount = Shader.PropertyToID("_BlendAmount");
        }

        public void SetEmissionRate(float rate) {
            var emission = _particles.emission;
            emission.rateOverTime = rate;
        }

        public void SetBlendAmount(float amount) {
            _mat.SetFloat(_blendAmount, amount);
        }
    }
}