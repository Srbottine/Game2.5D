using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour {

    public string sceneName;
   
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Boss 1");
        }
    }

    public void ChangeS()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void exit()
    {
        Application.Quit();
    }


}
