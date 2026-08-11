using UnityEngine;

namespace HierarchySequences
{
    public class ActivateObject : ASequencable
    {
        [SerializeField] private GameObject _object;
        [SerializeField] private bool _active;
        
        protected override async Awaitable OnPlay() {
            _object.SetActive(_active);
        }

        public override bool RequirementsValidated() {
            return _object != null;
        }

        protected override string GetName() {
            return (_active ? "Activate" : "Deactivate") + $" {_object.name}";
        }

#if UNITY_EDITOR
        protected override float Hue => 0f;
#endif
    }
}
