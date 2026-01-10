using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float speed = 1;

    // array de Transform (gameObjects vacios en posiciones concretas) que van a 
    // representar los puntos de patrulla del fantasma
    public Transform[] wayPoints;

    private Rigidbody rb;
    private int currentWayPointIndex; // para controlar que casilla del array estoy
    private Vector3 currentToTarget;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // Cojo la posicion que hay en la casilla del array marcada por el index
        Transform currentWayPoint = wayPoints[currentWayPointIndex];
        currentToTarget = currentWayPoint.position - transform.position;

        // Comprobar si he llegado a mi destino para poder pasar al siguiente punto
        if (currentToTarget.magnitude < 0.1f)
        {
            // si he llegado al final del array, vuelvo al principio
            if (currentWayPointIndex == wayPoints.Length - 1)
            {
                currentWayPointIndex = 0;
            }
            // paso al siguiente punto
            else
            {
                currentWayPointIndex++;

            }
        }
    }

    private void FixedUpdate()
    {
        // Rotar el fantasma hacia donde esta mirando
        Quaternion forwardRotation = Quaternion.LookRotation(currentToTarget);
        rb.MoveRotation(forwardRotation);

        rb.MovePosition(rb.position + currentToTarget.normalized * speed * Time.deltaTime);
    }
}
