using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer : MonoBehaviour
{
    public float speed = 20f;
    
    void Update()
    {
        float v = Input.GetAxisRaw("Vertical");  
        transform.Translate(Vector2.up * v * speed * Time.deltaTime);
        transform.position = new Vector2(transform.position.x,
            Mathf.Clamp(transform.position.y, -4.25f, 4.25f));
    }
}