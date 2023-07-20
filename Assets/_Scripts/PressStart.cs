
using UnityEngine;

public class PressStart : MonoBehaviour
{
    private void Awake()
    {
        Application.targetFrameRate = 120;

    }
    private void Start()
    {
        Time.timeScale = 0f;  // Останавливаем время в начале игры
       
    }

    private void Update()
    {
        
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Mouse0))
            {
                ResumeGame();
            }
    }

    private void ResumeGame()
    {
        Time.timeScale = 1f;  
        gameObject.SetActive(false);
    }
}
