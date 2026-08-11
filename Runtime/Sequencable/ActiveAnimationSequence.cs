using UnityEngine;

namespace HierarchySequences
{
    public class ActivateAnimationSequence : ASequencable
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private string _parameter;

        protected override async Awaitable OnPlay() {
            _animator.SetBool(_parameter, true);
        }

        public override bool RequirementsValidated() {
            return _animator != null;
        }

        protected override string GetName() {
            return $"Play {_animator.name} : {_parameter}";
        }

#if UNITY_EDITOR
        protected override float Hue => 36f;
#endif
    }
}
