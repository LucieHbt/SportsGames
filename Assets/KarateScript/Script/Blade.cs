using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    private Rigidbody rb;
    private SphereCollider sc;
    private TrailRenderer tr;
    private KarateManager km;
    public HandTracking handTracking;
    public GameObject highlightPoint; // Reference to the highlight object

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        sc = GetComponent<SphereCollider>();  
        tr = GetComponent<TrailRenderer>();
        km = FindObjectOfType<KarateManager>();

        // Enable the collider and trail renderer initially
        sc.enabled = true;
        tr.enabled = true;
    }

    void Update()
    {
        if (km.EndGame)
        {
            tr.enabled = false;
            sc.enabled = false;
            highlightPoint.SetActive(false);
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            tr.enabled = true;
            sc.enabled = true;
            highlightPoint.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            tr.enabled = false;
            sc.enabled = false;
            highlightPoint.SetActive(false);
        }

        BladeFollowIndex();
    }

    private void BladeFollowIndex()
    {
        // Get the position of the index finger from the HandTracking script
        Vector3 leftIndexPos = handTracking.leftHandPoints[8].transform.position;  // index finger of left hand
        Vector3 rightIndexPos = handTracking.rightHandPoints[8].transform.position; // index finger of right hand

        bool isLeftHandVisible = handTracking.leftHandPoints[8].activeInHierarchy;
        bool isRightHandVisible = handTracking.rightHandPoints[8].activeInHierarchy;

        // Compare the Z coordinate to determine which hand is closer to the camera
        if (isLeftHandVisible && isRightHandVisible)
        {
            if (leftIndexPos.z < rightIndexPos.z)
            {
                rb.position = leftIndexPos;
                highlightPoint.transform.position = leftIndexPos;
                SetHandVisibility(true, false);
            }
            else
            {
                rb.position = rightIndexPos;
                highlightPoint.transform.position = rightIndexPos;
                SetHandVisibility(false, true);
            }
        }
        else if (isLeftHandVisible && !isRightHandVisible)
        {
            rb.position = leftIndexPos;
            highlightPoint.transform.position = leftIndexPos;
            SetHandVisibility(true, false);
        }
        else if (!isLeftHandVisible && isRightHandVisible)
        {
            rb.position = rightIndexPos;
            highlightPoint.transform.position = rightIndexPos;
            SetHandVisibility(false, true);
        }
    }

    private void SetHandVisibility(bool showLeftHand, bool showRightHand)
    {
        // Enable or disable left hand points
        foreach (GameObject point in handTracking.leftHandPoints)
        {
            point.SetActive(showLeftHand);
        }

        // Enable or disable right hand points
        foreach (GameObject point in handTracking.rightHandPoints)
        {
            point.SetActive(showRightHand);
        }
    }
}
