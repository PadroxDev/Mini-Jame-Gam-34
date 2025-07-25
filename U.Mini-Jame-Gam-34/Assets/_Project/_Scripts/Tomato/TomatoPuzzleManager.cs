using System;
using System.Collections;
using DG.Tweening;
using Padrox.Acelab.Core;
using UnityEngine;

namespace MJG_34 {
    public class TomatoPuzzleManager : Singleton<TomatoPuzzleManager> {
        const float k_tomatoScale = 380.2131f;
        const float k_growthDuration = 0.2f;

        [SerializeField] Transform _tomatoParent;
        [SerializeField] Camera _puzzleCamera;

        Tomato _currentTomato;

        public void InitializePuzzle(TomatoType tomatoType) {
            if (_currentTomato != null) return;
            
            _currentTomato = Instantiate(tomatoType.prefab, _tomatoParent);
            _currentTomato.transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
            _currentTomato.transform.localScale = Vector3.zero;
            _currentTomato.transform.DOScale(Vector3.one * k_tomatoScale, k_growthDuration);
            StartCoroutine(PuzzleGrowth());
        }

        IEnumerator PuzzleGrowth() {
            float duration = 3f;
            float targetEmissionRate = 20f;
            float elapsed = 0f;
            
            while (elapsed < duration) {
                elapsed += Time.deltaTime;

                float alpha = elapsed / duration;
                float rate = Mathf.Lerp(0f, targetEmissionRate, alpha);
                _currentTomato.SetEmissionRate(rate);
                
                _currentTomato.SetBlendAmount(alpha);
                
                yield return null;
            }
        }
    }
}