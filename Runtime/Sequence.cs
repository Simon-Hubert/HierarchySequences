using System;
using System.Collections.Generic;
using UnityEngine;

namespace HierarchySequences
{
    public class Sequence : ASequencable
    {
        private List<ASequencable> _sequence = new List<ASequencable>();
        public event Action SequenceEnded;

        private void Awake() {
            foreach (Transform child in transform) {
                if (!child.gameObject.activeSelf) continue;
                ASequencable sequencable = child.GetComponent<ASequencable>();
                if(sequencable) _sequence.Add(sequencable);
            }
        }

        public void Execute() {
            _ = ExecuteAsync();
        }
        
        protected override async Awaitable OnPlay()  {
            try {
                foreach (ASequencable element in _sequence) {
                    await element.ExecuteAsync();
                }
            }
            catch (OperationCanceledException oce) {

            }
            finally {
                SequenceEnded?.Invoke();
            }
        }
        
        
#if UNITY_EDITOR
        public override InspectorColor GetInspectorColor() {
            return new InspectorColor
            {
                Background = new Color(1f,0,0),
                Text = new Color(0.3f,0f,0f),
            };
        }
#endif
    }
}
