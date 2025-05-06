using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Canvas CompletionCanvas;
    public TMP_Text Clock;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (CompletionCanvas.gameObject.activeSelf)
        { 
            CompletionCanvas.gameObject.SetActive(false); 
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartClicked() 
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
