using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class ScenceTransitioner : MonoBehaviour
{
    public GameObject tutorialImage;
    public void StartGameScene(){
        SceneManager.LoadScene("GameScene");
    }
    public void ShowTutorial(){
        tutorialImage.SetActive(true);
    }
    public void HideTutorial(){
        tutorialImage.SetActive(false);
    }
    
}
