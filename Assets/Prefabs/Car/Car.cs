using Assets.Prefabs.GameManager;
using UnityEngine;

public class Car : MonoBehaviour, IResetable
{
    private GameManager gameManager;
    private Rigidbody rb;
    public GameObject model;
    private Transform initialTransfrom;

    public GameObject explosion;

    private Animator animator;
    private int turnLeftHash;
    private int turnRightHash;

    private bool hasControlls = true;

    public float speed = 15;
    public float rotationSpeed = 70;

    private void Awake()
    {
        initialTransfrom = transform;
        gameManager = FindObjectOfType<GameManager>();

        gameManager.OnGameStart.AddListener(() =>
        {
            hasControlls = true;
        });

        gameManager.OnGameOver.AddListener(() =>
        {
            hasControlls = false;
        });

        gameManager.OnStartMenu.AddListener(() =>
        {
            hasControlls = false;
        });

        animator = model.GetComponent<Animator>();
        turnLeftHash = Animator.StringToHash("turnLeft");
        turnRightHash = Animator.StringToHash("turnRight");
        rb = GetComponent<Rigidbody>();
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.red);
        Debug.DrawRay(transform.position, -transform.up * 5, Color.blue);
    }

    public void Reset()
    {
        rb.isKinematic = false;
        gameObject.transform.position = initialTransfrom.position;
        gameObject.transform.rotation = initialTransfrom.rotation;
        gameObject.transform.localScale = initialTransfrom.localScale;

        animator.SetBool(turnLeftHash, false);
        animator.SetBool(turnRightHash, false);
    }

    private void Update()
    {
        if (!hasControlls)
            return;

        transform.position += transform.forward * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            StartRotate(true);

            transform.rotation = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, -transform.up) * transform.rotation;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            StartRotate(false);

            transform.rotation = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, transform.up) * transform.rotation;
        }
        else
        {
            StopRotate();
        }

        gameManager.Planet.PositionCar();
        gameManager.Planet.RotateCar();
    }

    private void StartRotate(bool rotateLeft)
    {
        animator.SetBool(turnLeftHash, rotateLeft);
        animator.SetBool(turnRightHash, !rotateLeft);

        model.transform.rotation = Quaternion.AngleAxis((rotateLeft ? -1 : 1) * 20, transform.up) * model.transform.rotation;
    }

    private void StopRotate()
    {
        animator.SetBool(turnLeftHash, false);
        animator.SetBool(turnRightHash, false);

        model.transform.rotation = Quaternion.FromToRotation(model.transform.forward, transform.forward) * model.transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasControlls)
            return;

        string objTag = collision.gameObject.tag;
        if (objTag == "Meteor" || objTag == "Rock")
        {
            rb.isKinematic = true;

            Instantiate(explosion, transform.position, transform.rotation);

            gameManager.GameOver();
        }
    }

}
