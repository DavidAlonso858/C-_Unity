using DG.Tweening;
using UnityEngine;

public class Paths : MonoBehaviour
{
    [SerializeField]
    private PathType pathType;
    
    [SerializeField]
    private float time;

    [SerializeField]
    private Vector3[] waypoints = new[]
    {
        new Vector3(4f, 2f, 6f),
        new Vector3(8f, 6f, 14f),
        new Vector3(4f, 6f, 14f),
        new Vector3(0f, 6f, 6f),
        new Vector3(-3f, 0f, 0f),
    };

    void Awake()
    {

        /*
            SetOptions a true sirve para cerrar el path, es decir, une el ultimo punto con el primero
            SetLookAt es para que sirve siempre el punto siguiente al que se dirige
            SetEase para establecer el tipo de movimiento que va a hacer
            SetLoops para que haga el path en loop infinito
        */

        transform.DOPath(waypoints, time, pathType).SetOptions(true).SetLookAt(0.001f).SetEase(Ease.Linear).SetLoops(-1);
    }

    void Update()
    {

    }
}
