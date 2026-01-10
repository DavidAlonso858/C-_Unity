using System;
using UnityEngine;

// : MonoBehaviour significa que hereda de MonoBehaviour, 
// la clase base de Unity que permite que tu script se adjunte a objetos del juego
public class Day1 : MonoBehaviour
{
    // Primeras variables en C#
    int number;
    int number2;
    int sum;
    int i;
    int a;
    int b;
    int c;

    // Se ejecuta una sola vez cuando el objeto se activa en la escena
    // Es perfecto para inicializar variables, configurar el objeto, buscar referencias a otros 
    // objetos, etc.
    void Start()
    {
        number = 12;
        number2 = 8;

        sum = number + number2;
        Debug.Log("The sum of number " + number + " and number " + number2 + " is "
         + sum);

        i = 8;
        a = i;
        b = ++i;
        c = i;
        Debug.Log($"The value of a: {a}, b: {b}, c: {c}");
    }

    // Se ejecuta cada frame (típicamente 60 veces por segundo)
    // Úsalo para cosas que necesitan actualizarse constantemente: movimiento, entrada del jugador, 
    // temporizadores, etc.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("¡Has presionado la barra espaciadora!");
        }

    }
}
