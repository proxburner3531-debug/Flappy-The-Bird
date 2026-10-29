using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button gameRestartButton;
    [SerializeField] private Button mainMenuButton;


    private void Awake()
    {
        gameRestartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);

        });

        mainMenuButton.onClick.AddListener(() => 
        {
            SceneManager.LoadScene(1);
        });
    }

    private void Start()
    {
        Hide();
        Bird.Instance.OnGameOver += Instance_OnGameOver;

    }

    private void Instance_OnGameOver(object sender, System.EventArgs e)
    {
        Show();
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
        gameRestartButton.Select();
    }

}
