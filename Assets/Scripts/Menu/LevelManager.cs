using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject level2LockIcon;

    public GameObject level2;

    private void Update()
    {
        UnlockLevel2();
    }

    public void UnlockLevel2()
    {
        if (PlayerPrefs.GetInt("level2Unlocked") == 1)
        {
            level2LockIcon.SetActive(false);
            level2.SetActive(true);
        }

        if (PlayerPrefs.GetInt("level2puzzleUnlocked") == 1)
        {
            level2LockIcon.SetActive(false);
            level2.SetActive(true);
        }
    }
}
