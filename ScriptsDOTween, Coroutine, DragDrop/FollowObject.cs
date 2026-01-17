using DG.Tweening;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float time;

    private Vector3 targetLastPosition;
    private Tweener myTween;

    void Awake()
    {
        // SetAutoKill a false significa que el tween no se muere nunca 
        myTween = transform.DOMove(target.position, time).SetAutoKill(false);
        targetLastPosition = transform.position;
    }

    void Update()
    {
        // si el target no se ha movido, me salgo del update porque no quiero hacer ningun seguimiento
        if (targetLastPosition == target.position) return;

        // Actualizo el valor del target dentro del tween
        myTween.ChangeEndValue(target.position, true).Restart();

        // Antes de salirme del update para ir al siguiente frame, actualizo la posicion
        targetLastPosition = target.position;
    }
}
