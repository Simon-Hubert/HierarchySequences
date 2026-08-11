using UnityEngine;

namespace HierarchySequences
{
    public class SpriteOpacitySequence : ASequencable
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private float _duration;
        [SerializeField] private AnimationCurve _curve;
        
        protected override async Awaitable OnPlay(){
            float t = 0;
            Color col = _spriteRenderer.color;
            col.a = _curve.Evaluate(0);
            _spriteRenderer.color = col;
            while (t < _duration) {
                await Awaitable.EndOfFrameAsync();
                t += Time.deltaTime;
                float p = t / _duration;
                p = _curve.Evaluate(p);
                Color color = _spriteRenderer.color;
                color.a = p;
                _spriteRenderer.color = color;
            }
            col.a = _curve.Evaluate(1);
            _spriteRenderer.color = col;
        }

        public override bool RequirementsValidated() {
            return _spriteRenderer && _duration > 0;
        }

        protected override string GetName()  {
            return $"Animate Opacity of {_spriteRenderer.name}";
        }
        
#if UNITY_EDITOR
        protected override float Hue => 180f;
#endif
    }

}
