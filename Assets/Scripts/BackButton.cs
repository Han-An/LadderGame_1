using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void OnButtonClick()
    {
        SceneManager.LoadScene("Start");
    }
}
