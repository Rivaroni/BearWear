using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryLoader : MonoBehaviour
{

    public void GalleryLoad()
    {
        SceneManager.LoadScene("Gallery");
    }

    public void MainLoad()
    {
        SceneManager.LoadScene("Main");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
