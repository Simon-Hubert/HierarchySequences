using UnityEngine;

namespace HierarchySequences
{
    public class EnableBehaviour : ASequencable
    {
        [SerializeField] private MonoBehaviour _behaviour;
        [SerializeField] private bool _enabled;
        
        protected override async Awaitable OnPlay() {
            _behaviour.enabled = _enabled;
        }
        
        public override bool RequirementsValidated() {
            return _behaviour;
        }
        
        protected override string GetName() {
            return (_enabled ? "Enable" : "Disable") + $" {_behaviour.name}";
        }
        
#if UNITY_EDITOR
        protected override float Hue => 108f;
#endif
    }
}
