using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();    

        gameManager.OnGameStart.AddListener(() =>
        {
            Destroy(gameObject);
        });
    }

    private void Start()
    {
        var targetVector = (transform.position - gameManager.Planet.transform.position).normalized;
        transform.rotation = Quaternion.AngleAxis(Random.Range(-180, 180), targetVector)
            * Quaternion.FromToRotation(transform.up, targetVector) 
            * transform.rotation;
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.up * 5, Color.red);
    }

}
