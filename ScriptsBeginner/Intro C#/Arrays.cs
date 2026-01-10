using UnityEngine;

public class Arrays : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int[] exampleArray = new int[5];
    int[] arrayTest = { 34, -23, 0, 56, -78, 12, -1, 45, 11, -2 };
    void Start()
    {
        // Metodo al que le paso un array con un tamaño y devuelve su contenido aleatorio
        ExampleArrayRandom(exampleArray);
        // Array con numeros positivos
        ArrayPositive(arrayTest);
        // Array con numeros negativos
        ArrayNegative(arrayTest);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ArrayPositive(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] >= 0)
            {
                Debug.Log("Positive numbers in the array: " + array[i]);
            }
        }
    }
    private void ArrayNegative(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0)
            {
                Debug.Log("Negative numbers in the array: " + array[i]);
            }
        }
    }


    private void ExampleArrayRandom(int[] array)
    {
        for (int i = 0; i < exampleArray.Length; i++)
        {
            exampleArray[i] = Random.Range(25, 75);
            Debug.Log("Element at array " + exampleArray[i]);
        }

        exampleArray[2] = 99;
        Debug.Log("Modified element at index 2: " + exampleArray[2]);

    }


}
