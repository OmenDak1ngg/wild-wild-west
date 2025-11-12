using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private SceneAsset _scene;
    [SerializeField] private Player _player;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private RestartButton _restartButton;

    private void OnEnable()
    {
        _player.Health.Dead += StopGame;
        _restartButton.Clicked += StartGame;
    }

    private void OnDisable()
    {
        _player.Health.Dead -= StopGame;
        _restartButton.Clicked -= StartGame;
    }

    private void Awake()
    {
        Time.timeScale = 1f;    
    }

    private void StopGame()
    {
        _endGameScreen.gameObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    private void StartGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        _endGameScreen.gameObject.SetActive(false);
        SceneManager.LoadScene(_scene.name);
    }
}
