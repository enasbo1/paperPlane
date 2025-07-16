using UnityEngine;
using UnityEngine.Serialization;

namespace Script
{
    public class PaperPlanePhysics : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;
        [SerializeField] private Transform mainTransform;
        [SerializeField][Range(0f,1f)] private float portance;
        [SerializeField][Range(0f,1f)] private float lifting;
        [SerializeField][Range(0f,5f)] private float weight;


        private void FixedUpdate()
        {
            rb.rotation *= Profondeur(rb.linearVelocity, mainTransform.rotation) * Weight(mainTransform.rotation);
            rb.linearVelocity = Portance(rb.linearVelocity, mainTransform.rotation);
        }

        private Vector3 Portance(Vector3 velocity, Quaternion rotation)
        {
            Vector3 direction = rotation * Vector3.forward;
            return direction * (Scalar(direction, velocity) * portance) + velocity * (1-portance);
        }

        private Quaternion Profondeur(Vector3 velocity, Quaternion rotation)
        {
            Vector3 direction = rotation * Vector3.forward;
            return Quaternion.Euler(new Vector3(0,0,lifting * Time.deltaTime * Scalar(direction, velocity)));
        }

        private Quaternion Weight(Quaternion rotation)
        {
            return Quaternion.Euler(new Vector3(0,0,- weight * Time.deltaTime * Mathf.Cos(rotation.eulerAngles.z)));
        }

        private static float Scalar(Vector3 a, Vector3 b)
        {
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
    }
}
