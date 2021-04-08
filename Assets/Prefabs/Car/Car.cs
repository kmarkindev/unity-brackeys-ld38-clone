using UnityEngine;

public class Car : MonoBehaviour
{

    public GameObject model;

    private Animator animator;
    private int turnLeftHash;
    private int turnRightHash;

    public float speed = 15;
    public float rotationSpeed = 70;

    private void Awake()
    {
        animator = model.GetComponent<Animator>();
        turnLeftHash = Animator.StringToHash("turnLeft");
        turnRightHash = Animator.StringToHash("turnRight");
    }
    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward * 5, Color.red);
        Debug.DrawRay(transform.position, -transform.up * 5, Color.blue);
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        if(Input.GetKey("a"))
        {
            StartRotate(true);

            transform.rotation = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, -transform.up) * transform.rotation;

        }
        else if(Input.GetKey("d"))
        {
            StartRotate(false);

            transform.rotation = Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, transform.up) * transform.rotation;
        }
        else
        {
            StopRotate();
        }

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

}
