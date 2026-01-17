using System.Collections;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    [SerializeField]
    // luces de los cubos insertadas en la escena
    private Light[] lights;

    private bool check;
    
    void Awake()
    {
        //CalculateNumber();
        // Para iniciar las Coroutines y que se activen los metodos con el tiempo asignado
        StartCoroutine(MyFirstCoroutine());
        // StartCoroutine(ActivateLightsWithDelay());

    }

    // Update is called once per frame
    void Update()
    {
        if (check == false)
        {
            StartCoroutine(ActivateLightsWithDelay());
        }
    }

    // Las coroutines son metodos "especiales que se van a ejecutar 
    // a la largo de los frames, son metodos "con memoria"
    IEnumerator MyFirstCoroutine()
    {
        Debug.Log("Hello World!");
        // aqui se queda el metodo dos segundos esperando
        yield return new WaitForSeconds(2);
        Debug.Log("Han pasado dos segundos");
    }

    IEnumerator ActivateLightsWithDelay()
    {
        check = true;
        for (int i = 0; i < lights.Length; i++)
        {
            // habilito el componente, es decir, enciendo la luz
            lights[i].enabled = true;
            yield return new WaitForSeconds(0.5f);

        }

        for (int i = 0; i < lights.Length; i++)
        {
            // deshabilita el componente, es decir, apaga la luz
            lights[i].enabled = false;
            yield return new WaitForSeconds(0.5f);
        }

        check = false;
    }

    void CalculateNumber()
    {
        Debug.Log("Hello World!");
    }
}
