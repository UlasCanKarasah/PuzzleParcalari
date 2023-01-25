using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Match3Levels()
    {
        SceneManager.LoadScene("Match3 Levels");
    }

    public void  Match3_Level1()
    {
        SceneManager.LoadScene("Match3");
    }

    public void Match3_Level2()
    {
        SceneManager.LoadScene("Match3 level2");
    }

    public void AnaMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void PuzzleLeveller()
    {
        SceneManager.LoadScene("PuzzleLevels");
    }

    public void Puzzle1()
    {
        SceneManager.LoadScene("PuzzleLevel1");
    }

    public void Puzzle2()
    {
        SceneManager.LoadScene("PuzzleLevel2");
    }

    public void Market()
    {
        SceneManager.LoadScene("market");
    }

    public void Match3Info()
    {
        SceneManager.LoadScene("Match3 Info");
    }

    public void YapbozInfo()
    {
        SceneManager.LoadScene("Yapboz Info");
    }



}
