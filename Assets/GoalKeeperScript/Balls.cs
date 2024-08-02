using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    private GameManager gm;
    private float rotationForce = 200f;
    private Rigidbody rb;
    public int scorePoints;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce); 
    }

    private void InstantiateSlicedBall()
    {

        Rigidbody[] slicedRb = GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody srb in slicedRb)
        {
            srb.AddExplosionForce(130f, transform.position, 10);
            srb.velocity = rb.velocity * 1.2f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandPoint"))
        {
            Destroy(gameObject);
            gm.UpdateTheScore(scorePoints);
            InstantiateSlicedBall();
        }

        if (other.CompareTag("BallsTrigger"))
        {
            Destroy(gameObject);
        }
    }
}
