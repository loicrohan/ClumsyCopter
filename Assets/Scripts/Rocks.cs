using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    public float speed = 5f;

    public int lifetime = 5;

    [SerializeField]
    private AudioClip _clip;

    private void Start()
    {
        Invoke("DestroyThis", lifetime);
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
            PlayerPlane.score++;
        }
    }
}