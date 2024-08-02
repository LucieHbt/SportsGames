using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    private GameManager gm;
    public HandTracking handTracking;

    public bool followLeftHand = true;
    public bool followRightHand = true;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (gm.gameIsOver)
        {
            return;
        }

        DetectHandTouches();
    }

    private void DetectHandTouches()
    {
        if (handTracking != null)
        {
            if (followLeftHand)
            {
                CheckCollisions(handTracking.leftHandPoints);
            }

            if (followRightHand)
            {
                CheckCollisions(handTracking.rightHandPoints);
            }
        }
        else
        {
            Debug.LogWarning("HandTracking n'est pas assigné.");
        }
    }

    private void CheckCollisions(GameObject[] handPoints)
    {
        foreach (GameObject point in handPoints)
        {
            Collider[] hitColliders = Physics.OverlapSphere(point.transform.position, 0.1f); // Ajustez le rayon selon vos besoins
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("Ball"))
                {
                    gm.UpdateTheScore(1);
                    Destroy(hitCollider.gameObject);
                }
            }
        }
    }
}
