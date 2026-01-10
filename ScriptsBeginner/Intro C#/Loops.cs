using UnityEngine;

public class Loops : MonoBehaviour
{
    int index = 0;
    int index2 = 100;

    [SerializeField]
    int indexInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Muestra del 0 al 100
        LoopsExample1();
        // Muestra del 100 al 0 
        LoopsExample2();
        // Mostrar los numeros del 1 hasta el numero ingresado
        LoopsExample3();
        // Muestra los numeros pares del 0 al 100
        LoopsExample4();
        // Muestra los numeros impares del 0 al 100
        LoopsExample5();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoopsExample1()
    {
        while (index < 100)
        {
            index++;
            Debug.Log("Index value: " + index);
        }
    }
    private void LoopsExample2()
    {
        for (int i = index2; i > 0; i--)
        {
            Debug.Log("Index2 value: " + i);
        }
    }
    private void LoopsExample3()
    {
        int number = 1;
        while (number < indexInput)
        {
            number++;
            Debug.Log("Number value to the limit: " + number);
        }
    }
    private void LoopsExample4()
    {
        for (int i = 0; i < 100; i++)
        {
            if (i % 2 != 0)
            {
                Debug.Log("Index value: " + i);
            }
        }
    }
    private void LoopsExample5()
    {
        while (index < 100)
        {
            index += 2;
            Debug.Log("Index value: " + index);
        }
    }
}
