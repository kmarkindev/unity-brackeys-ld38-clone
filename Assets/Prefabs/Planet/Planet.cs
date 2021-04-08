using UnityEngine;

public class Planet : MonoBehaviour
{

    public float planetGroundOffset = 0.5f;

    GameManager gameManager;
    Car car;
    SphereCollider sc;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        car = gameManager.car;
        sc = GetComponent<SphereCollider>();
    }

    private void Update()
    {
        PositionCar();
        RotateCar();
    }

    private void PositionCar()
    {
        var carDir = (car.transform.position - transform.position).normalized;
        var planetSurfaceRadius = transform.localScale.x * sc.radius + planetGroundOffset;
        var localGravityOrigin = carDir * planetSurfaceRadius;
        var newCarPosition = transform.position + localGravityOrigin;
        car.transform.position = newCarPosition;
    }

    private void RotateCar()
    {
        var targetBottomVector = (transform.position - car.transform.position).normalized;
        var bottomVector = -car.transform.up;

        car.transform.rotation = Quaternion.FromToRotation(bottomVector, targetBottomVector) * car.transform.rotation;
    }

}
