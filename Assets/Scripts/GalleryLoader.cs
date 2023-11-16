using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GalleryLoader : MonoBehaviour
{
    public AudioClip clickSfx;
    public AudioClip curtainSfx;
    public AudioClip galleryMusic;
    public AudioClip mainMusic;

    public void GalleryLoad()
    {
        AudioManagerScript.instance.PlaySoundEffect(clickSfx, 0.3f);
        StartCoroutine(WaitForAnim("Gallery"));
       
    }

    public void MainLoad()
    {
        AudioManagerScript.instance.PlaySoundEffect(clickSfx, 0.3f);
        StartCoroutine(WaitForAnim("Main"));
    }

    private IEnumerator WaitForAnim(string sceneName)
    {
        AudioManagerScript.instance.PlaySoundEffect(curtainSfx, 1f);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
        if(sceneName == "Gallery")
        {
            AudioManagerScript.instance.PlayMusic(galleryMusic, 0.25f);
        }
        else
        {
            AudioManagerScript.instance.PlayMusic(mainMusic, 0.15f);
        }

    }

}
