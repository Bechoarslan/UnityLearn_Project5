using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    
    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private float maxTorque = 10.0f;
    private float xRange = 4.0f;
    private float ySpawnPos = -6.0f;
    private GameManager gameManager;
    public int value;
    public ParticleSystem particles;
    public bool gameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(),RandomTorque(),RandomTorque(), ForceMode.Impulse);
        transform.position = RandomPosition();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        

        
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.GameOver();
    }
   
    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(particles, transform.position, particles.transform.rotation);
            gameManager.AddScore(value);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(!gameObject.CompareTag("Bad1"))
        {
            gameManager.Get();
            
            
        }
        Destroy(gameObject);

    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomPosition()
    {
        return  new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
