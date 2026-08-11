using UnityEngine;

namespace HierarchySequences
{
    public class PlaySoundSequence : ASequencable
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private bool _active = true;
        [Space(5)]
        [SerializeField] private bool _fireAndForget = false;
        
        protected override async Awaitable OnPlay()  {
            if (!_source) return;
            
            if (_active) _source.Play();
            else _source.Stop();
            
            if (!_source.loop && _fireAndForget)
                await Awaitable.WaitForSecondsAsync(_source.clip.length);
        }

        public override bool RequirementsValidated() {
            return _source;
        }
        
        protected override string GetName() {
            
            return $"Play " + (_source.gameObject == gameObject ? "self" : _source.name) + (_fireAndForget ? " fire and forget" : "");
        }

#if UNITY_EDITOR
        protected override float Hue => 288f;
#endif
    }
}
