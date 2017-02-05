using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public bool loadNextLevel;
    public int levelNum;
    public Image fader;
	// Use this for initialization
	void Start () {
        FadeIn();
	}
	
	// Update is called once per frame
	void Update () {
        if (loadNextLevel) {
            FadeOut();
            Invoke("LoadLevel", 2);
            loadNextLevel = !loadNextLevel;
        }
	}

    void FadeOut() {
        fader.GetComponent<Animator>().Play("FadeOut");

    }

    void FadeIn() {
        fader.GetComponent<Animator>().Play("FadeIn");

    }

    void LoadLevel() {
        SceneManager.LoadScene(levelStringName());

    }

    string levelStringName() {
        string s = "_Level_1F " + (levelNum + 1).ToString();

        return s;
    }
}
