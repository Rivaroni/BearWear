using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryLoader : MonoBehaviour
{

    public void GalleryLoad()
    {
        StartCoroutine(WaitForAnim("Gallery"));
       
    }

    public void MainLoad()
    {
        StartCoroutine(WaitForAnim("Main"));
    }

    private IEnumerator WaitForAnim(string sceneName)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }

}
