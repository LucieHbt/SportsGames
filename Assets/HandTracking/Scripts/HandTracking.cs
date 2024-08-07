using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTracking : MonoBehaviour
{
    public UDPReceive udpReceive;
    public GameObject[] leftHandPoints;
    public GameObject[] rightHandPoints;
    public GameObject leftIndexPoint;
    public GameObject rightIndexPoint;
    
    void Update()
    {
        string data = udpReceive.data;
        if (string.IsNullOrEmpty(data)) return;
        
        data = data.TrimStart('[').TrimEnd(']');
        string[] points = data.Split(',');

        if (points.Length == 126)  // 21 points x 3 coordonnées x 2 mains
        {
            UpdateHandPoints(leftHandPoints, points, 0);
            UpdateHandPoints(rightHandPoints, points, 63); // 21 * 3

            // Mettre à jour la position des points des index
            UpdateIndexPoint(leftIndexPoint, leftHandPoints[8].transform.localPosition);
            UpdateIndexPoint(rightIndexPoint, rightHandPoints[8].transform.localPosition);
        }
        else if (points.Length == 63)  // 21 points x 3 coordonnées x 1 main
        {
            // Essayez de déterminer quelle main est présente
            float xFirstPoint = float.Parse(points[0]);
            if (xFirstPoint > 0) // Supposition que les coordonnées X positives sont pour la main droite
            {
                UpdateHandPoints(rightHandPoints, points, 0);
                UpdateIndexPoint(rightIndexPoint, rightHandPoints[8].transform.localPosition);
            }
            else // Les coordonnées X négatives sont pour la main gauche
            {
                UpdateHandPoints(leftHandPoints, points, 0);
                UpdateIndexPoint(leftIndexPoint, leftHandPoints[8].transform.localPosition);
            }
        }
    }

    private void UpdateHandPoints(GameObject[] handPoints, string[] points, int startIndex)
    {
        for (int i = 0; i < handPoints.Length; i++)
        {
            float x = 7 - float.Parse(points[startIndex + i * 3]) / 100;
            float y = float.Parse(points[startIndex + i * 3 + 1]) / 100;
            float z = float.Parse(points[startIndex + i * 3 + 2]) / 100;

            handPoints[i].transform.localPosition = new Vector3(x, y, z);
        }
    }

    private void UpdateIndexPoint(GameObject indexPoint, Vector3 position)
    {
        indexPoint.transform.localPosition = position;
    }
}
