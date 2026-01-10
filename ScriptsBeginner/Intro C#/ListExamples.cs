using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ListExamples : MonoBehaviour
{
    List<string> exampleList = new List<string>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ExampleListMethods(exampleList);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ExampleListMethods(List<string> listName)
    {
        listName.Add("Ivan");
        listName.Add("Pepe");
        listName.Add("Juancito");

        // List.Count es el .Size de Java o .lenght de los arrays
        for (int i = 0; i < listName.Count; i++)
        {
            Debug.Log("List Element " + i + ": " + listName[i]);
        }

        Debug.Log("List size: " + listName.Count);
        Debug.Log("List contains Ivan: " + listName.Contains("Ivan"));

        listName.RemoveAt(0);
        Debug.Log("List size: " + listName.Count);
        Debug.Log("List contains Ivan: " + listName.Contains("Ivan"));
    }
}