using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{

    public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void LoadScene(int _sceneIndex)
    {
        anim.SetTrigger("fadeOut");
        StartCoroutine(Load(_sceneIndex));
    }

    IEnumerator Load(int _sceneIndex)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(_sceneIndex);
        
    }
}
