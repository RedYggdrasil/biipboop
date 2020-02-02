using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public float transitionTime;

    void Start() 
    {
        if (PrefManager.currScene == "Level") {
            if (PrefManager.triggerIntro) 
            {
                PrefManager.triggerIntro = false;
                transition.SetTrigger("Intro");
            } else {
                transition.SetTrigger("Start");
            }
        } else {
            transition.SetTrigger("Start");
        }
    }

    public void loadLevel() 
    {
        StartCoroutine("LoadProtoMap");
    }

    IEnumerator LoadProtoMap() 
    {
        transition.SetTrigger("Quit");

        yield return new WaitForSeconds(transitionTime);

        PrefManager.currScene = "Level";
        SceneManager.LoadScene(1);
    }
}
