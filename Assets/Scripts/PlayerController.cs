using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5; // Sebess�g v�ltoz�

    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal"); // V�zszintes bemenet
        float vInput = Input.GetAxisRaw("Vertical"); // F�gg�leges bemenet

        Vector3 direction = new(hInput, 0, vInput); // Ir�ny vektor
        direction.Normalize(); // Ir�ny normaliz�l�sa
        // Komment

        Vector3 velocity = direction * speed; // Sebess�g vektor

        transform.position += velocity * Time.deltaTime; // Poz�ci� friss�t�se
    }

    // �rj f�ggv�nyt ami egy tetsz�leges sz�mot emel egy tetsz�leges eg�sz hatv�nyra!

    float Pow(float baseNumber, int power)  // K�t param�teres f�ggv�ny: alap �s kitev�
    {
        // Annyiszor vessz�k az alap sz�mot szorz�t�nyez�nek, ah�nyadik hatv�nyra emelj�k

        float result = 1; // Eredm�ny v�ltoz�: 1-gyel kezd�nk �s a hatv�nyoz�s sor�n ezt m�dos�tjuk
        for (int i = 0; i < power; i++) // Annyiszor szorozzuk az alap sz�mmal, ah�nyadik hatv�nyra emelj�k
        {
            result *= baseNumber; // Minden ciklusban megszorozzuk az eredm�nyt az alap sz�mmal
        }
        return result; // Eredm�ny visszaad�sa
    }
}
