using UnityEngine;

namespace MossUnity
{
    /// <summary>
    /// Owns the Unity-side lifecycle/configuration for a Moss simulation world.
    ///
    /// This foundation is not yet connected to MossSharp. The native world must
    /// only be created after the real MossSharp API and deployment model are verified.
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Moss/Physics/Moss Physics World")]
    public sealed class MossPhysicsWorld : MonoBehaviour
    {
        [SerializeField, Min(0.001f)]
        private float fixedTimeStep = 1.0f / 60.0f;

        [SerializeField, Min(1)]
        private int maximumSubsteps = 4;

        private float accumulatedTime;
        private bool initialized;

        public float FixedTimeStep => fixedTimeStep;
        public int MaximumSubsteps => maximumSubsteps;
        public bool IsInitialized => initialized;

        private void OnEnable()
        {
            // TODO: instantiate the verified MossSharp world adapter.
            // Do not mark initialized until native world creation succeeds.
            accumulatedTime = 0.0f;
            initialized = false;
        }

        private void FixedUpdate()
        {
            if (!initialized)
                return;

            // TODO: use a deliberate stepping policy with the actual MossSharp API.
            // Avoid silently mixing Unity's default physics simulation with Moss.
        }

        private void OnDisable()
        {
            // TODO: stop stepping, unregister callbacks and dispose native handles.
            initialized = false;
            accumulatedTime = 0.0f;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            fixedTimeStep = Mathf.Max(0.001f, fixedTimeStep);
            maximumSubsteps = Mathf.Max(1, maximumSubsteps);
        }
#endif
    }
}
