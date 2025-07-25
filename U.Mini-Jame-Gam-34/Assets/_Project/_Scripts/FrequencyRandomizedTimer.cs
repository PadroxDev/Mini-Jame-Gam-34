using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Padrox.Acelab.Timers
{
    /// <summary>
    /// Timer that ticks at a specific frequency. (N times per second)
    /// </summary>
    public class FrequencyRandomizedTimer : Timer
    {
        public int TicksPerSecond { get; private set; }

        public Action OnTick = delegate { };

        float _timeThreshold;
        float _baseDuration;
        float _variation;
        float _currentDuration;

        public FrequencyRandomizedTimer(float averageDuration, float variation = 0.3f) : base(0) {
            _baseDuration = averageDuration;
            _variation = variation;
            CalculateNewDuration();
        }

        public override void Tick() {
            if (IsRunning && CurrentTime >= _currentDuration) {
                CurrentTime -= _currentDuration;
                CalculateNewDuration();
                OnTick.Invoke();
            }

            if (IsRunning && CurrentTime < _currentDuration) {
                CurrentTime += Time.deltaTime;
            }
        }

        public override bool IsFinished => !IsRunning;

        public override void Reset() {
            CurrentTime = 0;
        }

        void CalculateNewDuration() {
            _currentDuration = _baseDuration + Random.Range(-_variation, _variation);
        }
    }
}