using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    private const string Game = nameof(Game);

    public void StartGame()
    {
        SceneManager.LoadScene(Game);
    }
}
