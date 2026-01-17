using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;

    void Awake()
    {

    }

    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        Debug.Log("target is " + screenPos.x + " pixels from the left");
        Debug.Log("Vecto3: " + screenPos);
    }

    // Este metodo se va a ejecutar siempre que estemos arrastrando el raton con el boton pulsado
    private void OnMouseDrag()
    {
        Vector2 mousePos = Input.mousePosition;
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, distance)) + offset;

    }

    // Este metodo se ejecuta EL FRAME que pulsamos el objeto con el boton izquierdo del raton (el gameobject tiene que tener un collider)
    private void OnMouseDown()
    {
        // Coordenadas de pantalla en px
        Vector2 mousePos = Input.mousePosition;

        // estoy cogiendo la distancia que hay desde el gameObject a la camara
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;

        // calculo en coordenadas de mundo del juego (de la escena de Unity) la posicion del raton
        // teniendo en cuenta la distancia en Z calculada arriba
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, distance));

        // el offset lo calcula para que, a la hora de pincha sobre el objeto, el seguimiento al cursar del raton se haga
        // precisamente sobre el punto que hemos hecho click
        offset = transform.position - worldPos;

    }
}
