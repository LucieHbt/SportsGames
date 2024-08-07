using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{

    private float rotationForce = 200;
    public ParticleSystem BombExplosion;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Random.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blade")
        {
            Destroy(gameObject);
            Instantiate(BombExplosion, transform.position, BombExplosion.transform.rotation);
            FindAnyObjectByType<KarateManager>().GameOver();
        }

    }
}
