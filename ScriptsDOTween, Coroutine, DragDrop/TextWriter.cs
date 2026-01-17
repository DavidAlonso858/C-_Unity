using UnityEngine;
using TMPro;
using System.Collections;

public class TextWriter : MonoBehaviour
{
    [SerializeField]
    // el texto que queremos mostrar en la interfaz
    private string textToShow;

    [SerializeField]
    private TextMeshProUGUI textUI;

    void Awake()
    {
        //StartCoroutine(ShowText());
        StartCoroutine(ShowTextWithVisibility());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ShowText()
    {
        textUI.text = ""; // limpiar el texto que hay en la interfaz
        foreach (char c in textToShow)
        {
            textUI.text += c;
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator ShowTextWithVisibility()
    {
        // obliga al textmeshpro a calcular inmediatamente el siguiente frame
        textUI.ForceMeshUpdate();

        // cuento los char
        int totalCharacters = textUI.textInfo.characterCount;
        // hace invisible el texto
        textUI.maxVisibleCharacters = 0;

        for (int i = 0; i <= totalCharacters; i++)
        {
            textUI.maxVisibleCharacters = i;
            yield return new WaitForSeconds(0.2f);
        }
    }

}
