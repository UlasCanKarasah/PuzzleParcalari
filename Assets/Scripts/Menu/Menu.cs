using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void  Oyna()
    {
        SceneManager.LoadScene("Match3");
    }

    public void AnaMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PuzzleLeveller()
    {
        SceneManager.LoadScene("PuzzleLevels");
    }

    public void Puzzle()
    {
        SceneManager.LoadScene("PuzzleDemo");
    }

    public void Puzzle1()
    {
        SceneManager.LoadScene("puzzledenemeler");
    }

    public void Market()
    {
        SceneManager.LoadScene("market");
    }



}
