using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDeathScene : MonoBehaviour
{

    public float delay = 5;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadDeathScenein5Seconds());
    }

    IEnumerator LoadDeathScenein5Seconds()
    {
        yield return new WaitForSeconds(delay);
        FindObjectOfType<SceneTransition>().LoadScene(4);
    }
}
