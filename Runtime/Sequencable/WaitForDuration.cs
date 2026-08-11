using ShowColors;
using UnityEngine;

namespace HierarchySequences
{
    public class WaitForDuration : ASequencable
    {
        [SerializeField] private float _duration;
        
        protected override async Awaitable OnPlay() {
            await Awaitable.WaitForSecondsAsync(_duration);
        }
        
        public override bool RequirementsValidated() {
            return _duration > 0;
        }

        protected override string GetName() {
            return $"Wait for {_duration} sec";
        }
        
#if UNITY_EDITOR
        protected override float Hue => 252f;
#endif
    }
}
