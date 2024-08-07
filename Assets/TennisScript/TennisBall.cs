using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TennisBall : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb;
    public TennisScoreManager scoreManager;
    private bool Launched = false;
    private AudioSource audioSource;
    public AudioClip SfxRacket, SfxWalls, SfxLoose;
    private float curSpeed;
    public TMP_Text countdownText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Launched == false)
        {
            StartCoroutine(StartCountdownAndLaunch());
        }
    }

    IEnumerator StartCountdownAndLaunch()
    {
        Launched = true; // Empêche de relancer la coroutine si elle est déjà en cours
        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString(); // Afficher le compte à rebours
            yield return new WaitForSeconds(1f); // Attendre 1 seconde
        }
        countdownText.text = ""; // Effacer le texte après le compte à rebours
        LaunchBall();
    }

    void LaunchBall()
    {
        if (scoreManager.EndGame == true)
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
        }

        curSpeed = speed;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector2(x, y) * speed;
    }

    private void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * curSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.collider.tag);
        switch (collision.collider.tag)
        {
            case "P1Loose":
                HandleScoreAndReinit(2);
                audioSource.PlayOneShot(SfxLoose);
                break;

            case "P2Loose":
                HandleScoreAndReinit(1);
                audioSource.PlayOneShot(SfxLoose);
                break;

            case "Walls":
                audioSource.PlayOneShot(SfxWalls);
                curSpeed += 0.5f;
                break;

            case "Racket":
                audioSource.PlayOneShot(SfxRacket);
                break;
        }
    }

    void HandleScoreAndReinit(int player)
    {
        Launched = false;
        rb.velocity = Vector2.zero; // stopper la vitesse
        transform.position = new Vector2(-4, 6); // remettre la balle à la position (-4, 6)
        scoreManager.AddScore(player); // ajouter du score
        audioSource.PlayOneShot(SfxLoose);
    }
}
