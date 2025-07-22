using UnityEngine;

namespace Script
{
    public class Checkpoint : MonoBehaviour
    {

        [SerializeField]
        GameObject destination;
        [SerializeField]
        int numberOfCheckpoint;

        private void OnCollisionEnter(Collision collision)
        {
            destination.GetComponent<finalCheckpoint>().checkPointPassed(numberOfCheckpoint);
        }
    }
}
