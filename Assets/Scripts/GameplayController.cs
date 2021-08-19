using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    [SerializeField] private Animator animFade, animTextFinish, animTextGO, animUI;
    [SerializeField] private GameObject pauseScreen, gameplayUI, finishScreen, gameOverScreen;
    [SerializeField] private float timeBeforeText;


    private void Start()
    {
        finishScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        gameplayUI.SetActive(false);
    }

    private void Update()
    {
        if (PlayerController.isFinished)
        {
            StartCoroutine(Finish(animTextFinish, finishScreen));
        }
        if (PlayerController.isDead)
        {
            StartCoroutine(Finish(animTextGO, gameOverScreen));
        }
        if (PlayerController.isActivated)
        {
            gameplayUI.SetActive(true);
            animUI.SetTrigger("Show");
        }
        if (PlayerController.isDeactivated)
        {
            animUI.SetTrigger("Hide");
        }
    }

    private IEnumerator Finish(Animator anim, GameObject screen)
    {
        animFade.SetTrigger("Start");
        yield return new WaitForSeconds(timeBeforeText);
        screen.SetActive(true);
        anim.SetTrigger("Start");
    }    

    private void SwitchPause(float _timeScale, bool _pauseScreen, bool _gameplayUI)
    {
        Time.timeScale = _timeScale;
        gameplayUI.gameObject.SetActive(_gameplayUI);
        pauseScreen.gameObject.SetActive(_pauseScreen);
    }

    public void PauseGame()
    {
        SwitchPause(0f, true, false);
    }

    public void ContinueGame()
    {
        SwitchPause(1f, false, true);
    }

    public void Restart()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
