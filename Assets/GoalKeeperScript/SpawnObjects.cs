using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject[] objects;
    public float left;
    public float right;
    public float forwardForceMin = 5f;
    public float forwardForceMax = 10f;

    void Start()
    {
        StartCoroutine(SpawnRandomObject());
    }

    private IEnumerator SpawnRandomObject()
    {
        yield return new WaitForSeconds(1);

        while(FindAnyObjectByType<GameManager>().gameIsOver == false) 
        {
            InstantiateRandomObject();
            yield return new WaitForSeconds(RandomRepeatrate());
        }
    }

    private void InstantiateRandomObject()
    {
        int objectIndex = Random.Range(0, objects.Length);
        GameObject obj = Instantiate(objects[objectIndex], transform.position, objects[objectIndex].transform.rotation);
        obj.GetComponent<Rigidbody>().AddForce(RandomVector() * RandomForce() + Vector3.forward * RandomForwardForce(), ForceMode.Impulse);
        obj.transform.rotation = Random.rotation;
    }

    private float RandomForce()
    {
        return Random.Range(14f, 16f);
    }

    private float RandomForwardForce()
    {
        return Random.Range(forwardForceMin, forwardForceMax);
    }

    private float RandomRepeatrate()
    {
        return Random.Range(1f, 5f);
    }

    private Vector3 RandomVector()
    {
        return new Vector3(Random.Range(left, right), 1, 0).normalized; // Z set to 0 here, as forward force is added separately
    }
}
