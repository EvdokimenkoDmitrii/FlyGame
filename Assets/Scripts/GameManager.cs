using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Добавляем для новой Input System

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // Используем Keyboard из новой Input System
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        // Перезагружаем текущую сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GameOver(string playerName)
    {
        Debug.Log(playerName + " died! Press R to restart.");
    }
}