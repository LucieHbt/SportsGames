using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruits : MonoBehaviour
{

    public GameObject[] karateobjects;
    public float left;
    public float right;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomObject());
    }

    private IEnumerator SpawnRandomObject()
    {
        yield return new WaitForSeconds(2);

        while(FindAnyObjectByType<KarateManager>().EndGame == false) 
        {
            InstantiateRamdomObject();
            yield return new WaitForSeconds(RandomRepeatrate());
        }
    }

    private void InstantiateRamdomObject()
    {
        int objectIndex = Random.Range(0, karateobjects.Length);
        GameObject obj = Instantiate(karateobjects[objectIndex], transform.position, karateobjects[objectIndex].transform.rotation);
        obj.GetComponent<Rigidbody>().AddForce(RandomVector() * RandomForce(), ForceMode.Impulse);
        obj.transform.rotation = Random.rotation;
    }

    private float RandomForce()
    {
        float force = Random.Range(14f, 15f);
        return force;
    }

        private float RandomRepeatrate()
    {
        float repeatrate = Random.Range(0.5f, 3f);
        return repeatrate;
    }

    private Vector2 RandomVector()
    {
        Vector2 moveDirection = new Vector2(Random.Range(left, right), 1).normalized;
        return moveDirection;
    }
    
}
