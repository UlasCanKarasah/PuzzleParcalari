using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public sealed class ScoreCounter : MonoBehaviour
{
    public static ScoreCounter Instance { get; private set; }

    private int _score;

    public int goal;

    public Canvas win;

    public Canvas board;

    public Canvas mint;

    public void Start()
    {
        // Enable the canvas
        win.enabled = false;
        mint.enabled = false;
    }

    private void Update()
    {
        if (_score > goal)
        {
            win.enabled = true;
            board.enabled = false;
            mint.enabled = true;
            Board.Instance.audioSource.Stop();
            if (SceneManager.GetActiveScene().name == "Match3")
            {
                PlayerPrefs.SetInt("level2Unlocked", 1);
                
            }
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
