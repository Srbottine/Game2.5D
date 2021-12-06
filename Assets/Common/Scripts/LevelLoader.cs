using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour {
   
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Boss 1");
        }
    }

}
