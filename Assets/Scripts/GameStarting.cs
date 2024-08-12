using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarting : MonoBehaviour
{
    public GameObject player;
    public GameObject holdText;
    public static bool isGameStarted = false;

    void Update()
    {
        if (!Losing.gameEnding && Input.touchCount > 0)
        {
                isGameStarted = true;
        }

        Camera.main.gameObject.Enabled<CameraMovement>(isGameStarted);
        player.Enabled<PlayerMovement>(isGameStarted);
        player.Enabled<ScoreIncreasing>(isGameStarted);
        player.Enabled<RoadSpawning>(isGameStarted);
        holdText.SetActive(!isGameStarted && !Losing.gameEnding);
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }    
}
