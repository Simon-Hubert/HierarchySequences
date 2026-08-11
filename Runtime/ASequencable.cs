using ShowColors;
using UnityEngine;

namespace HierarchySequences
{
    #if UNITY_EDITOR
    public struct InspectorColor
    {
        public Color Background;
        public Color Text;
    }
    #endif
    
    public abstract class ASequencable : MonoBehaviour
    {
        public async Awaitable ExecuteAsync() {
            if (!RequirementsValidated()) return;
            Debug.Log("Executes " + this.name);
            await OnPlay();
        }

        protected abstract Awaitable OnPlay();

        public virtual bool RequirementsValidated() => true;

        protected virtual string GetName() => "";

        private void OnValidate() {
            if (!RequirementsValidated()) return;
            string newName = GetName();
            if (newName == "") return;
            name = newName;
        }

#if UNITY_EDITOR
        protected virtual float Hue => 0.0f;
#if SHOW_COLORS
        protected const float CHROMA = 0.1005f;
        protected const float BACKGROUND_LIGHTNESS = 0.6513f;
        protected const float TEXT_LIGHTNESS = 0.25f;
        
        public virtual InspectorColor GetInspectorColor() {
            return new InspectorColor
            {
                Background = ColorHelpers.ColorFromOklch(BACKGROUND_LIGHTNESS, CHROMA, Hue),
                Text = ColorHelpers.ColorFromOklch(TEXT_LIGHTNESS, CHROMA, Hue),
            };
        }
#else
        public virtual InspectorColor GetInspectorColor() {
            return new InspectorColor
            {
                Background = Color.HSVToRGB(Hue/360f, 1f, 1f),
                Text = Color.HSVToRGB(Hue/360f, 1f, 0.5f)
            };
        }
#endif
#endif
    }
}
