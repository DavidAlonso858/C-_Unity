using UnityEngine;

public class ConditionalsPlayer : MonoBehaviour
{

    [Header("Player Health")]
    [SerializeField]
    private int health = 100;
    [SerializeField]
    private int health2 = 90;
    [SerializeField]
    private int health3 = 80;

    private char letter = 'A';
    private int numberDay = 3;
    private int numberMonth = 12;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // llamar al metodo para evaluar la salud del jugador
        HealthStatus();
        // llamar al metodo para evaluar si la salud es par o impar
        IsEven();
        // comparacion de forma ascendente dos numeros
        CompareHealthAscend2();
        // comparacion de forma ascendente tres numeros
        CompareHealthDescend3();
        // evaluar si una letra es vocal o consonante
        IsVocal();
        // evaluar el dia de la semana
        DayOfTheWeek();
        // evaluar el mes del año
        MonthOfTheYear();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void DayOfTheWeek()
    {
        if (numberDay == 1)
        {
            Debug.Log("Monday");
        }
        else if (numberDay == 2)
        {
            Debug.Log("Tuesday");
        }
        else if (numberDay == 3)
        {
            Debug.Log("Wednesday");
        }
        else if (numberDay == 4)
        {
            Debug.Log("Thursday");
        }
        else if (numberDay == 5)
        {
            Debug.Log("Friday");
        }
        else if (numberDay == 6)
        {
            Debug.Log("Saturday");
        }
        else if (numberDay == 7)
        {
            Debug.Log("Sunday");
        }
        else
        {
            Debug.Log("Invalid day number");
        }
    }

    private void MonthOfTheYear()
    {
        switch (numberMonth)
        {
            // con flechas serian 1 => "January" y a si con todos
            case 1:
                Debug.Log("January");
                break;
            case 2:
                Debug.Log("February");
                break;
            case 3:
                Debug.Log("March");
                break;
            case 4:
                Debug.Log("April");
                break;
            case 5:
                Debug.Log("May");
                break;
            case 6:
                Debug.Log("June");
                break;
            case 7:
                Debug.Log("July");
                break;
            case 8:
                Debug.Log("Agust");
                break;
            case 9:
                Debug.Log("September");
                break;
            case 10:
                Debug.Log("October");
                break;
            case 11:
                Debug.Log("November");
                break;
            case 12:
                Debug.Log("December");
                break;
            default:
                Debug.Log("Invalid month number");
                break;

        }
    }

    private void IsVocal()
    {
        // transformo el char en string pasandola a minuscula para facilitar la comparacion
        string lowerLetter = letter.ToString().ToLower();
        if (lowerLetter == "a" || lowerLetter == "e" || lowerLetter == "i"
        || lowerLetter == "o" || lowerLetter == "u")
        {
            Debug.Log("The Letter " + lowerLetter + " is a vowel.");
        }
        else
        {
            Debug.Log("The Letter " + lowerLetter + " is a consonant.");
        }
    }

    private void IsEven()
    {
        if (health % 2 == 0)
        {
            Debug.Log("Heath is even");

        }
        else
        {
            Debug.Log("Health is odd");
        }
    }

    private void CompareHealthAscend2()
    {
        if (health > health2)
        {
            Debug.Log(health2 + ", " + health);
        }
        else if (health < health2)
        {
            Debug.Log(health + ", " + health2);
        }
        else
        {
            Debug.Log(health + " = " + health2);
        }
    }

    private void CompareHealthDescend3()
    {
        // forma sin condicionales (la adecuada)
        /*
        float[] healths = { health, health2, health3 };
        Array.Sort(healths); // De menor a mayor
        Array.Reverse(healths); // De mayor a menor

        Debug.Log(healths[0] + "," + healths[1] + "," + healths[2]); 
        */
        if (health >= health2 && health >= health3 && health2 >= health3)
        {
            Debug.Log(health + "," + health2 + "," + health3);
        }
        else if (health >= health3 && health >= health2 && health3 >= health2)
        {
            Debug.Log(health + "," + health3 + "," + health2);
        }
        else if (health2 >= health && health2 >= health3 && health >= health3)
        {
            Debug.Log(health2 + "," + health + "," + health3);
        }
        else if (health2 >= health3 && health2 >= health && health3 >= health)
        {
            Debug.Log(health2 + "," + health3 + "," + health);
        }
        else if (health3 >= health && health3 >= health2 && health2 >= health)
        {
            Debug.Log(health3 + "," + health2 + "," + health);
        }
        else if (health3 >= health && health3 >= health2 && health >= health2)
        {
            Debug.Log(health3 + "," + health + "," + health2);
        }
        else
        {
            Debug.Log("There is a tie for the greatest health.");
        }
    }
    private void HealthStatus()
    {
        if (health >= 60)
        {
            Debug.Log("Player is healthy.");
        }
        else if (health >= 30)
        {
            Debug.Log("Player is injured.");
        }
        else
        {
            Debug.Log("Player is critical.");
        }
    }

}