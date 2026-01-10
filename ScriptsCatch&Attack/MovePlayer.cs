using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // variable global, que significa que puede ser usada en cualquier parte del script 
    public float speed;
    public float turnSpeed;

    // quiero almacenar la posicion que lleva el objeto en el eje x
    private float xPos;
    private Vector3 posObject;
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        xPos = transform.position.x;
        Debug.Log("XPOS: " + xPos);

        posObject = transform.position;
        Debug.Log("Position: " + posObject);

        //cambiando la posicion del cubo
        // transform.position = newPos;
    }

    // Update is called once per frame
    void Update()
    {
       
        // Vector3.forward = (0,0,1) -> VECTOR UNITARIO
        // Vector3.up = (0,1,0)
        // Vector3.right = (1,0,0)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);

        transform.Rotate(Vector3.up * horizontal * turnSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            // destruyo el objeto que lleva este script
            Destroy(gameObject);
        }

    }
}
