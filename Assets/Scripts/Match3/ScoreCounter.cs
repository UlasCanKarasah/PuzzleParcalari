
using UnityEngine;
using TMPro;

public sealed class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance { get; private set; }

    private int _score;

    public Canvas win;

    public Canvas board;

    public Canvas mint;


    void Start()
    {
        // Enable the canvas
        win.enabled = false;
        mint.enabled = false;
    }

    private void Update()
    {
        if (_score > 250)
        {
            win.enabled = true;
            board.enabled = false;
            mint.enabled = true;
            return;
        }
    }

    public int Score
    {
        get => _score;

        set
        {
            if (_score == value)
                return;
            _score = value;

            scoreText.SetText($"Score = {_score}");
        }
    }

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Awake() => Instance = this;

}
