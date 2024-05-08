using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    GameObject player;
    public GameObject particleSystemPrefab;
    private GameObject particleSystemInstance;
    public int arrowValue = 10;
    public AudioClip hitSound;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player");

    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(0, -0.1f, 0);

        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        if (player == null)
            return;

        Vector2 p1 = transform.position;
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1 - p2;
        float d = dir.magnitude;
        float r1 = 0.5f;
        float r2 = 1.0f;

        if (d < r1 + r2)
        {
            GameObject director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
            if (particleSystemPrefab != null)
            {

                Vector3 particlePosition = player.transform.position + Vector3.up * 1.0f;
                particleSystemInstance = Instantiate(particleSystemPrefab, particlePosition, Quaternion.identity);

                particleSystemInstance.transform.parent = player.transform;
                ParticleSystem ps = particleSystemInstance.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Play();
                    var mainModule = ps.main;
                    mainModule.loop = false;
                }
                if (hitSound != null && player.GetComponent<AudioSource>() != null)
                {
                    player.GetComponent<AudioSource>().PlayOneShot(hitSound);
                }



            }
            Destroy(gameObject);

        }

        if (GameDirector.IsGameOver)
        {
            SceneManager.LoadScene("GG");
            
            
        }

    }

}