using System.Collections.Generic;
using UnityEngine;
using ShowColors;

namespace HierarchySequences
{
    public class ParallelSequence : ASequencable
    {
        private readonly List<ASequencable> _sequence = new List<ASequencable>();
        [SerializeField] private float _duration;
        
        private void Awake() {
            foreach (Transform child in transform) {
                if (!child.gameObject.activeSelf) continue;
                ASequencable sequencable = child.GetComponent<ASequencable>();
                if(sequencable) _sequence.Add(sequencable);
            }
        }
        
        protected override async Awaitable OnPlay()  {
            foreach (ASequencable sequencable in _sequence) {
                _ = sequencable.ExecuteAsync();
            }
            await Awaitable.WaitForSecondsAsync(_duration);
        }
        
        public override bool RequirementsValidated() {
            return transform.childCount > 0 && _duration > 0;
        }
        
        
#if UNITY_EDITOR
        protected override float Hue => 144f;
#endif
    }
}
