
using UnityEngine;
using UnityEngine.SceneManagement;

public class splash : MonoBehaviour
{
    
    void Start()
    {
        Invoke("loadscene", 1f);
    }

    void loadscene()
    {
        SceneManager.LoadScene(1);
    }
}
