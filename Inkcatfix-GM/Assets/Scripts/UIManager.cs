using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [Header("Pause")]
    [SerializeField] private GameObject pauseScreen;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //If pause screen already active unpause |
            if(pauseScreen.activeInHierarchy)
                PauseGame(false);
            
            else 
                PauseGame(true);
        }
    }
    #region Pause

    public void PauseGame(bool status)
    {
        //If status == true pause | if status == false unpause.
        pauseScreen.SetActive(status);
    }

    public void RestartGame(bool restart)
    {
        //If status == true pause | if status == false unpause.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #endregion
}
