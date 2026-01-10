using System;
using UnityEngine;

public class Observer : MonoBehaviour
{
    // referencia al script GameEnding
    public GameEnding gameEnding;
    public Transform playerTransform;
    private bool isPlayerInRange;

    private Ray ray;
    private RaycastHit hit;
    private void Awake()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (isPlayerInRange == false)
        {
            // si el player no esta en rango, me salgo del update
            return;
        }

        // la posicion del jugador menos la del objeto que lleva el script
        Vector3 direction = playerTransform.position - transform.position;
        ray.origin = transform.position;
        ray.direction = direction;

        if (Physics.Raycast(ray, out hit))
        {
            // comprueba si el raycast esta chocando con un GameObject con tag "Player"
            if (hit.collider.CompareTag("Player"))
            {
                gameEnding.CaughtPlayer();
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * 10, Color.purple);
    }
    private void OnTriggerEnter(Collider other)
    {
        // comprueba si el objeto con el que choca tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // comprueba si el objeto con el que choca tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
