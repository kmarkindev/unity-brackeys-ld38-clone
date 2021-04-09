using UnityEngine;

public class Meteor : MonoBehaviour
{

    public float speed = 10.0f;

    private GameManager gameManager;
    private Vector3 planetDir;
    private Rigidbody rb;

    public GameObject model;
    public GameObject explosion;
    public ParticleSystem[] particles;
    public GameObject Rock;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        gameManager.OnGameStart.AddListener(OnGameStart);
    }

    private void OnGameStart()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        planetDir = gameManager.Planet.transform.position - transform.position;

        transform.rotation = Quaternion.FromToRotation(transform.forward, planetDir) * transform.rotation;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.red);
    }

    private void Update()
    {
        if(rb != null)
            transform.position += planetDir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var collTag = collision.gameObject.tag;
        if (collTag == "Planet")
        {
            Instantiate(Rock, gameObject.transform.position, Quaternion.identity);

            DestroyMeteor();
        }
        else if(collTag == "Rock")
        {
            DestroyMeteor();
        }
    }

    public void DestroyMeteor()
    {
        Destroy(rb);

        var explosionObj = Instantiate(explosion, gameObject.transform, false);

        model.SetActive(false);

        if (particles.Length == 0)
            return;

        float maxDuration = 0.0f;

        foreach(var particle in particles)
        {
            var main = particle.main;
            main.loop = false;
            main.startLifetimeMultiplier = 0.2f;

            if (maxDuration < main.duration)
                maxDuration = main.duration;

            Destroy(particle, main.duration);
        }

        Destroy(gameObject, maxDuration);
        Destroy(explosionObj, maxDuration);
    }

}
