using System.Collections;
using UnityEngine;

[ExecuteInEditMode]
public class TextureResize : MonoBehaviour
{
   public float scaleFactor = 1.0f;
    Material mat;

    void Start()
    {
        GetComponent<Renderer>().material.mainTextureScale = new Vector2 (transform.localScale.x / scaleFactor, transform.localScale.z / scaleFactor );

    }

    void Update()
    {
        if(transform.hasChanged && Application.isEditor && !Application.isPlaying)
        {
             GetComponent<Renderer>().material.mainTextureScale = new Vector2 (transform.localScale.x / scaleFactor, transform.localScale.z / scaleFactor );
            transform.hasChanged = false;
        }
    }
}