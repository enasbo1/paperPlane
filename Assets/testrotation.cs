using UnityEngine;

public class testrotation : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.rotation = Quaternion.identity;  
    }

    // Update is called once per frame
    void Update()
    {
        rb.rotation = Quaternion.Euler(0f, 10f,0f);
    }
}
