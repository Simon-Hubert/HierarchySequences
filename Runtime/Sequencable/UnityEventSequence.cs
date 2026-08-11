using ShowColors;
using UnityEngine;
using UnityEngine.Events;

namespace HierarchySequences
{
    public class UnityEventSequence : ASequencable
    {
        [SerializeField] private UnityEvent _event = new UnityEvent();
        

        protected override async Awaitable OnPlay() {
            _event?.Invoke();
        }
        
        public override bool RequirementsValidated() {
            return _event.GetPersistentEventCount() > 0;
        }

        protected override string GetName() {
            return $"Invoke Event with {_event.GetPersistentEventCount()} binds";
        }
        
#if UNITY_EDITOR
        protected override float Hue => 216f;
#endif
    }
}
