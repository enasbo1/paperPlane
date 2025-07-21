using UnityEngine;

namespace Script
{
    public class Checkpoint : MonoBehaviour
    {

        [SerializeField]
        GameObject finalCheckpoint;
        [SerializeField]
        int numberOfCheckpoint;

        private void OnCollisionEnter(Collision collision)
        {
            finalCheckpoint.GetComponent<finalCheckpoint>().checkPointPassed(numberOfCheckpoint);
        }
    }
}
