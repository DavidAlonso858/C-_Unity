using System.Collections;
using UnityEngine;

public class MovementWithCoroutine : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float speed;

    private Vector3 initialPosition;

    void Awake()
    {
        initialPosition = transform.position;
        StartCoroutine(MoveToTarget());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator MoveToTarget()
    {
        // voy hacia el objetivo
        yield return Move(target.position);
        // Hacemos una paradita
        yield return new WaitForSeconds(1f);
        // vuelve a la posicion inicial
        yield return Move(initialPosition);
    }

    IEnumerator Move(Vector3 desiredPosition)
    {

        // mientras no haya llegado a mi destino
        while (Vector3.Distance(desiredPosition, transform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, desiredPosition, speed * Time.deltaTime);
            yield return null; // se para y sigue ejecutando el metodo en el siguiente frame
        }

        Debug.Log("He llegado a mi destino");
    }
}
