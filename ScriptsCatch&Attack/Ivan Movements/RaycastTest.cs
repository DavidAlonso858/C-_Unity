using UnityEngine;
using UnityEngine.EventSystems;

public class RaycastTest : MonoBehaviour
{
    // capa que va a detectar el raycast
    public LayerMask rayMask;

    // variable tipo Ray donde vamos a almacenar el rayo
    private Ray ray;
    // variable que almacena la info del choque entre rayo y objeto
    private RaycastHit hit;

    private void Awake()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        // El raycast necesita punto de origen y direccion
        // Configuración del rayo

        // ray.origin = transform.position; // desde los pies del objeto que lleve el script

        // para que el rayo salga un poco mas alto (altura de los ojos)
        ray.origin = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        ray.direction = transform.forward; // del objeto que lleve el script

        // Lanzar el rayo, Mathf.Infinity para que sea infinito la longitud del rayo
        // lo demas son variables que ya tenemos declaradas (out tiene que ir con hit)
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, rayMask)) // raycast infinito
        {
            GameObject hitObject = hit.collider.gameObject; // me guardo el objeto que choco

            if (hitObject.GetComponent<Rigidbody>() == null) // si no tiene componente RB
            {
                hitObject.AddComponent<Rigidbody>(); // le añado componente RB desde codigo
            }

            // le aplico una fuerza hacia arriba
            hitObject.GetComponent<Rigidbody>().AddForce(Vector3.up * 50);
            Debug.Log("He chocado con algo " + hit.collider.gameObject.name);

        }

        // Dibujar el rayo en el panel scene para debuggear
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
    }
}
