using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; private set; }

    [SerializeField] private TextMeshProUGUI scoreTextMesh;

    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }
    public void AddScore()
    {
        score ++;

        scoreTextMesh.text = score.ToString();
    }
}
