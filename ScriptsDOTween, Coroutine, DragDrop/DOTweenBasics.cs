using UnityEngine;
using DG.Tweening; // Libreria a Incorporar para poder usar el DOTween 
public class DOTweens : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    // tiempo que quiero que tarde el objeto en llegar a su destino
    private float time;

    [SerializeField]
    private Camera myCamera;

    private Tween myTween;

    void Awake()
    {
        // DOMove mueve el gameObject hacia una posicion en el tiempo determinado
        // target "time" segundos en llegar a su destino
        // LINEA DE CODIGO SE EJECUTA UNA SOLA VEZ AL INICIAR EL JUEGO
        myTween = transform.DOMove(target.position, time).SetEase(Ease.OutElastic);

        // Cambio de color del material, poner -1 significa que se repite infinitamente el cambio de color
        // Yoyo significa que vuelve al color original
        target.GetComponent<Renderer>().material.DOColor(Color.red, time).SetLoops(-1, LoopType.Yoyo);

        // Tembleque en la camara por 5 segundos con una fuerza de 1 y 5 vibraciones
        myCamera.DOShakePosition(5, 2, 2);
    }

    void Update()
    {
        // Podemos tener control del tween que estamos ejecutando
        if (Input.GetMouseButtonDown(0)) myTween.Pause();
        else if (Input.GetMouseButton(1)) myTween.Play();

    }
}
