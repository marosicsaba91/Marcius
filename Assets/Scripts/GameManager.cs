using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] HealthObject_Asteroids player;
    [SerializeField] AsteroidManager asteroidManager;

    [SerializeField] GameObject onGameEndedObject;
 
    void Update()
    {
        int asteroidCount = asteroidManager.GetAsteroidCount();
        bool hasAnyAsteroids = asteroidCount > 0;
        float hp = player.GetHP();
        bool isPlayerAlive = hp > 0;

        bool isGameOn = hasAnyAsteroids && isPlayerAlive;

        // Debug.Log($" {hasAnyAsteroids}   {asteroidCount}    -   {isPlayerAlive}   {hp}");

        onGameEndedObject.SetActive(!isGameOn);

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
