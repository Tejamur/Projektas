using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPoint : MonoBehaviour
{
    public Rigidbody2D alien;
    public PointCounter pointCounter;
    public GameObject explosionPrefab;

    public EndLevel endLevel;

    public ParticleSystem explosion;

    public AudioSource audioSource;
    public AudioClip explosionClip;



    void Start()
    {
        alien.isKinematic = true;
        explosion.Stop();
        explosion.Clear();
    }
    
    public void MakeDynamic()
    {
        alien.isKinematic = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Floor"))
        {
            endLevel.waitTime = 6f;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            AudioSource.PlayClipAtPoint(explosionClip, transform.position);

            pointCounter.UpdateStars();
            Destroy(this.gameObject);
        }
    }
}
