using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private GameObject player;
    private Rigidbody2D rb;
    [SerializeField] private float pushForce;

    private void Awake()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    public void Push()
    {
        rb.AddForce(Vector2.right * pushForce);
    }

    public void PlayGame()
    {
        StartCoroutine(LoadLevel());
    }

    private IEnumerator LoadLevel()
    {
        anim.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(1);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
