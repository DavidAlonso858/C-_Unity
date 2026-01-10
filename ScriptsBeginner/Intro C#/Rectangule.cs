using UnityEngine;

public class Rectangule : MonoBehaviour
{
    [Header("Rectangule Dimensions")]
    private float width = 12.5f; // C# poner f para indicar que es decimal (igual con double d)
    private float height = 45.26f; // C# poner f para indicar que es decimal si fuera (igual con double d)
    float resultPerimeter;
    float resultLong;


    string studentName;

    [Header("Exam Notes")]
    [SerializeField]
    float theoryExam;
    [SerializeField]
    float practicExam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // metodo que devuelve el float del area pasandole parametros
        Debug.Log("The area of the rectangule is: " + AreaRectangule(8.5f, 50.3f));

        resultPerimeter = 2 * (width + height);
        Debug.Log("The perimeter of the rectangule is: " + resultPerimeter);

        resultLong = Mathf.Sqrt(width * width + height * height);
        Debug.Log("The long of the rectangule is: " + resultLong);

        Exam();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private float AreaRectangule(float width, float height)
    {
        return width * height;
    }

    private void Exam()
    {
        studentName = "\nJuanito Garcia Perez";
        theoryExam = Random.Range(0.0f, 10.0f);
        practicExam = Random.Range(0.0f, 10.0f);

        float finalExam = (theoryExam * 0.7f) + (practicExam * 0.3f);
        Debug.Log("The final result of " + studentName + " is: " + finalExam);

        if (finalExam >= 5.0f)
        {
            Debug.Log(studentName + " has passed the exam. Congratulations!");
        }
        else
        {
            Debug.Log(studentName + " has failed the exam. Mierdon!");
        }
    }

}