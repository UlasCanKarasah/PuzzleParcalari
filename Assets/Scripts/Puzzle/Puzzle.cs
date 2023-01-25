using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using System.Collections;

public class Puzzle : MonoBehaviour
{

    public GameObject[] puzzlePieces;
    private Vector3[] startingPositions;

    public GameObject[] puzzleTargets;
    public Vector3[] targetPositions;

    public Button showSolutionButton;

    public Button shuffleButton;

    public Button resetButton;

    public Text winText;

    public GameObject completedPuzzleImage;

    private bool puzzleSolved = false;

    public Canvas mint;


    private void Start()
    {
        // baslangic ve hedef pozisyonlarini alma
        startingPositions = new Vector3[puzzlePieces.Length];
        targetPositions = new Vector3[puzzleTargets.Length];

        
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            startingPositions[i] = puzzlePieces[i].transform.position;
            Debug.Log(startingPositions[i]);
        }

        
        for (int i = 0; i < puzzleTargets.Length; i++)
        {
            targetPositions[i] = puzzleTargets[i].transform.position;
            Debug.Log(targetPositions[i]);
        }


        shuffleButton.onClick.AddListener(Shuffle);

        resetButton.onClick.AddListener(Reset);

        showSolutionButton.onClick.AddListener(delegate { StartCoroutine(ShowSolution()); });

        winText.gameObject.SetActive(false);

        mint.enabled = false;

        PlayerPrefs.SetInt("level2puzzleUnlocked", 0);
    }

    private void Update()
    {

        if(IsSolved())
        {
            
            winText.gameObject.SetActive(true);

            for (int i = 0; i < puzzlePieces.Length; i++)
            {
                puzzlePieces[i].SetActive(false);
            }

            for (int i = 0; i < puzzlePieces.Length; i++)
            {
                puzzleTargets[i].SetActive(false);
            }

            shuffleButton.gameObject.SetActive(false);
            resetButton.gameObject.SetActive(false);
            showSolutionButton.gameObject.SetActive(false);
            completedPuzzleImage.SetActive(true);
            mint.enabled = true;
            PlayerPrefs.SetInt("level2puzzleUnlocked", 1);

        }


    }



   
    void Shuffle()
    {
        
        // random olarak yerleri degistir
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            GameObject temp = puzzlePieces[i];
            int randomIndex = Random.Range(0, puzzlePieces.Length);
            puzzlePieces[i] = puzzlePieces[randomIndex];
            puzzlePieces[randomIndex] = temp;
        }

        // yeni konumlari guncelle
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            puzzlePieces[i].transform.position = startingPositions[i];
        }
    }

    
    void Reset()
    {
        
        // null check
        if (puzzlePieces != null && startingPositions != null)
        {
            
            for (int i = 0; i < puzzlePieces.Length; i++)
            {
                puzzlePieces[i].transform.position = startingPositions[i];
            }
        }

        
        if (winText != null)
        {
           
            winText.gameObject.SetActive(false);
        }
    }

  
    //cozumu belirli saniye boyunca goster
    IEnumerator ShowSolution()
    {
        completedPuzzleImage.SetActive(true);

        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            puzzlePieces[i].SetActive(false);
        }

        yield return new WaitForSeconds(1.0f);

        completedPuzzleImage.SetActive(false);

        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            puzzlePieces[i].SetActive(true);
        }
    }


    bool IsSolved()
    {
       
        float threshold = 0.75f;

        // konumlari karsilastir 
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (Vector3.Distance(puzzlePieces[i].transform.position, targetPositions[i]) > threshold)
            {
                return false;
            }
        }

        
        if (!puzzleSolved)
        {
            puzzleSolved = true;
        }

        
        return puzzleSolved;
    }

}
