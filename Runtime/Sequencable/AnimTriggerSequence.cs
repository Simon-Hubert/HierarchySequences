using UnityEngine;

namespace HierarchySequences
{
    public class AnimTriggerSequence : ASequencable
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _triggerName;
        
        protected override async Awaitable OnPlay() {
            _animator.SetTrigger(_triggerName);
        }

        public override bool RequirementsValidated() {
            return _animator && _triggerName.Length > 0;
        }

        protected override string GetName() {
            return $"Set {_triggerName} on {_animator.name}";
        }
        
#if UNITY_EDITOR
        protected override float Hue => 72f;
#endif
    }
}
