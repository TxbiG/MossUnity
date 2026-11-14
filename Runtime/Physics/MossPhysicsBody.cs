using UnityEngine;

namespace MossUnity
{
    /// <summary>
    /// Unity-facing marker/configuration component for a future Moss-owned body.
    /// Native body creation is deferred until the MossSharp API is audited.
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Moss/Physics/Moss Physics Body")]
    public sealed class MossPhysicsBody : MonoBehaviour
    {
        [SerializeField]
        private bool isKinematic;

        [SerializeField, Min(0.0f)]
        private float mass = 1.0f;

        public bool IsKinematic => isKinematic;
        public float Mass => mass;

        private void OnEnable()
        {
            // TODO: register with the nearest active MossPhysicsWorld and create
            // a native body through the verified MossSharp adapter.
        }

        private void OnDisable()
        {
            // TODO: unregister and dispose the native body before object teardown.
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            mass = Mathf.Max(0.0f, mass);
        }
#endif
    }
}
