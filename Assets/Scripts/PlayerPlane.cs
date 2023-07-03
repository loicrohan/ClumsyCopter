using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPlane : MonoBehaviour
{
    public static int score = 0;

    public float tapForce = 265;

    public Text scoreText;

    public GameObject looseScreen;

    private Rigidbody2D playerRigidbody;

    private AudioSource _audioSource;

    [SerializeField]
    private AudioClip _clip;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        playerRigidbody = GetComponent<Rigidbody2D>();

        //Reset the score everytime the game restarts
        score = 0;

        Time.timeScale = 0;
    }

    void Update()
    {
        //The Score text updates every frame
        scoreText.text = score.ToString();

        if (Input.GetKeyDown(KeyCode.Space) || (Input.GetMouseButtonDown(0)))
        {
            _audioSource.Play();
            playerRigidbody.AddForce(Vector2.up * tapForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rocks")
        {
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);

            looseScreen.SetActive(true);

            Time.timeScale = 0;
        }
    }

    //Called externally
    public void SetGameTimeScale(float newScale)
    {
        Time.timeScale = newScale;
    }
}