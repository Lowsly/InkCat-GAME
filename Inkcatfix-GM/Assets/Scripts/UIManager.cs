using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Pause")]
    [SerializeField] private GameObject _pauseScreen, _abilityScreen, _abilitySelectionScreen;
    private bool _paused = false;
    private bool _abilityMenuActive = false, _abilitySelection;

    private void Start()
    {
        Abilities(false);
        PauseGame(false);
        OpenAbilitiesMenu(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_abilitySelection)
            {
                OpenAbilitiesMenu(false);
            }
            else if (_abilityMenuActive)
            {
                Abilities(false);
            }
            else
            {
                PauseGame(!_paused);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (_paused)
            {
                PauseGame(false);
            }
            else if (_abilityMenuActive)
            {
                if (!_abilitySelection)
                {
                    Abilities(false);
                }
            }
            else
            {
                Abilities(true);
            }
        }

        if (_paused || _abilityMenuActive || _abilitySelection)
        {
            Time.timeScale = 0f; // Congelar el tiempo si algún menú está activo
        }
        else
        {
            Time.timeScale = 1f; // Dejar que el tiempo siga normal si ningún menú está activo
        }
    }

    #region Pause

    public void PauseGame(bool status)
    {
        _paused = status;
        _pauseScreen.SetActive(status);

        if (status)
        {
            _abilityMenuActive = false;
            _abilityScreen.SetActive(false);
            OpenAbilitiesMenu(false);
        }
    }

    public void Abilities(bool active)
    {
        _abilityMenuActive = active;
        _abilityScreen.SetActive(active);

        if (active)
        {
            _paused = false;
            _pauseScreen.SetActive(false);
            OpenAbilitiesMenu(false);
        }
    }

    public void OpenAbilitiesMenu(bool open)
    {
        _abilitySelection = open;
        _abilitySelectionScreen.SetActive(open);

        if (open)
        {
            _paused = false;
            _pauseScreen.SetActive(false);
        }
    }

    public void RestartGame(bool restart)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #endregion
}