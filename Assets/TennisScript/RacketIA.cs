using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketIA : MonoBehaviour
{
    public Transform ball;
    public float speed = 5f;
    public float marginOfError = 0.1f;
    public float followDistance = 2f;
       
    void Update()
    {
        if(Mathf.Abs(ball.position.x - transform.position.x) < followDistance)
        {
            if (Random.value > marginOfError)
            {
                Vector3 targetPosition = new Vector3(transform.position.x, ball.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); 
            }
        } 

        transform.position = new Vector2(transform.position.x,Mathf.Clamp(transform.position.y, -4.25f, 4.25f));
    }
}