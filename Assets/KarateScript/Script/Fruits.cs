using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    private KarateManager km;
    public GameObject slicedFruit;
    public GameObject fruitjuice;
    private float rotationForce = 200f;
    private Rigidbody rb;
    public int scorePoints;

    private bool isSliced = false; // Pour éviter les destructions multiples

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        km = FindObjectOfType<KarateManager>();
    }

    void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce); 
    }

    private void InstantiateSlicedFruit()
    {
        GameObject instantiatedFruit = Instantiate(slicedFruit, transform.position, transform.rotation);
        GameObject instantiatedJuice = Instantiate(fruitjuice, new Vector3(transform.position.x, transform.position.y, 0), fruitjuice.transform.rotation);

        Rigidbody[] slicedRb = instantiatedFruit.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody srb in slicedRb)
        {
            srb.AddExplosionForce(130f, transform.position, 10);
            srb.velocity = rb.velocity * 1.2f;
        }

        Destroy(instantiatedFruit, 5);
        Destroy(instantiatedJuice, 5);   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isSliced) return; // Éviter les destructions multiples

        if (other.CompareTag("Blade") || other.CompareTag("HandPoint"))
        {
            isSliced = true;
            InstantiateSlicedFruit();
            km.UpdateTheScore(scorePoints);
            Destroy(gameObject);
        }

        if (other.CompareTag("BottomTrigger"))
        {
            km.UpdateLives();
            Destroy(gameObject);
        }
    }
}
