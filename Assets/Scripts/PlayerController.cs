using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5; // Sebesség változó

    void Update()
    {
        float hInput = Input.GetAxisRaw("Horizontal"); // Vízszintes bemenet
        float vInput = Input.GetAxisRaw("Vertical"); // Függõleges bemenet

        Vector3 direction = new(hInput, 0, vInput); // Irány vektor
        direction.Normalize(); // Irány normalizálása
        // Komment

        Vector3 velocity = direction * speed; // Sebesség vektor

        transform.position += velocity * Time.deltaTime; // Pozíció frissítése
    }

    // Írj függvényt ami egy tetszõleges számot emel egy tetszõleges egész hatványra!

    float Pow(float baseNumber, int power)  // Két paraméteres függvény: alap és kitevõ
    {
        // Annyiszor vesszük az alap számot szorzótényezõnek, ahányadik hatványra emeljük

        float result = 1; // Eredmény változó: 1-gyel kezdünk és a hatványozás során ezt módosítjuk
        for (int i = 0; i < power; i++) // Annyiszor szorozzuk az alap számmal, ahányadik hatványra emeljük
        {
            result *= baseNumber; // Minden ciklusban megszorozzuk az eredményt az alap számmal
        }
        return result; // Eredmény visszaadása
    }
}
