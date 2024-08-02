using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTrackingPong : MonoBehaviour
{
    public UDPReceive udpReceive;
    public GameObject leftRacket;
    public GameObject rightRacket;

    private Vector2 leftHandPosition = Vector2.zero;
    private Vector2 rightHandPosition = Vector2.zero;

    void Update()
    {
        string data = udpReceive.data;
        if (string.IsNullOrEmpty(data)) return;

        data = data.TrimStart('[').TrimEnd(']');
        string[] points = data.Split(',');

        if (points.Length == 126)  // 21 points x 3 coordonnées x 2 mains
        {
            // Mettre à jour les positions des mains
            UpdateHandPositions(points);
            
            // Mettre à jour les positions des raquettes
            UpdateRacketsPosition();
        }
    }

    private void UpdateHandPositions(string[] points)
    {
        // Assumer que les 21 premiers points sont pour la main gauche
        int numPointsPerHand = 21;
        int leftHandStartIndex = 0;
        int rightHandStartIndex = numPointsPerHand * 3; // 21 points x 3 coordonnées = 63

        // Mettre à jour la position de la main gauche (pour la raquette droite)
        if (leftRacket != null && points.Length > leftHandStartIndex + 2)
        {
            float xLeft = 7 - float.Parse(points[leftHandStartIndex]) / 100;
            float yLeft = float.Parse(points[leftHandStartIndex + 1]) / 100;
            // Inverser la coordonnée x pour compenser le retournement horizontal
            xLeft = -xLeft;
            leftHandPosition = new Vector2(xLeft * 2, yLeft * 2);
        }

        // Mettre à jour la position de la main droite (pour la raquette gauche)
        if (rightRacket != null && points.Length > rightHandStartIndex + 2)
        {
            float xRight = 7 - float.Parse(points[rightHandStartIndex]) / 100;
            float yRight = float.Parse(points[rightHandStartIndex + 1]) / 100;
            // Inverser la coordonnée x pour compenser le retournement horizontal
            xRight = -xRight;
            rightHandPosition = new Vector2(xRight * 2, yRight * 2);
        }
    }

    private void UpdateRacketsPosition()
    {
        // Mettre à jour la position de la raquette gauche
        if (leftRacket != null)
        {
            leftRacket.transform.localPosition = new Vector3(leftHandPosition.x, leftHandPosition.y, leftRacket.transform.localPosition.z);
        }

        // Mettre à jour la position de la raquette droite
        if (rightRacket != null)
        {
            rightRacket.transform.localPosition = new Vector3(rightHandPosition.x, rightHandPosition.y, rightRacket.transform.localPosition.z);
        }
    }
}
