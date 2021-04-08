using UnityEngine;

public class Meteor : MonoBehaviour
{

    public float speed = 10.0f;

    private GameManager gameManager;
    private Vector3 planetDir;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
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
        transform.position += planetDir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Planet")
        {
            // spawn rock on planet

            Destroy(gameObject);
        }
    }

}
