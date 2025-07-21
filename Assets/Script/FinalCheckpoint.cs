using UnityEngine;

public class finalCheckpoint : MonoBehaviour
{
    public int numberOfCheckPoint;
    public ParticleSystem victoryParticles;

    private int counter = 0;
    public void checkPointPassed (int i)
    {
        if (counter == i + 1)
        {
            counter++;
        }
        else counter = 0;
    }

    public void OnCollisionEnter(Collision collision)
    {
        checkVictory();
    }

    private void checkVictory()
    {
        if (counter == numberOfCheckPoint--)
        {
            Debug.Log("parcours réussi");
            victoryParticles.Play();
            counter = 0;
        }
    }
}
