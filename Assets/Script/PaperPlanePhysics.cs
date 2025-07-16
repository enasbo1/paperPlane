using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class PaperPlanePhysics : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField][Range(0f,1f)] private float portance;
        [SerializeField][Range(0f,5f)] private float lifting;
        [SerializeField][Range(0f,50f)] private float weight;
        
        
        private void FixedUpdate()
        {
            rb.rotation *= Profondeur(rb.linearVelocity, rb.rotation) * Weight(rb.rotation);
            rb.linearVelocity = Portance(rb.linearVelocity, rb.rotation) * Friction(rb.linearVelocity, rb.rotation);
        }

        private Vector3 Portance(Vector3 velocity, Quaternion rotation)
        {
            Vector3 direction = rotation * Vector3.forward;
            return direction * (Scalar(direction, velocity) * portance) + velocity * (1-portance);
        }
        
        private static float Friction(Vector3 velocity, Quaternion rotation)
        {
            Vector3 direction = rotation * Vector3.forward;
            return Scalar(direction, velocity) > 0 ? 0.995f : 0.9f;
        }

        private Quaternion Profondeur(Vector3 velocity, Quaternion rotation)
        {
            Vector3 direction = rotation * Vector3.forward;
            return Quaternion.Euler(new Vector3(-lifting * Time.deltaTime * Scalar(direction, velocity),0,0));
        }

        private Quaternion Weight(Quaternion rotation)
        {
            return Quaternion.Euler(new Vector3(weight * Time.deltaTime * Mathf.Cos(rotation.eulerAngles.z * Mathf.Deg2Rad),0,0));
        }

        private static float Scalar(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
    }
}
