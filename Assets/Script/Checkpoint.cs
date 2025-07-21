using UnityEngine;

public class Checpoint : MonoBehaviour
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
