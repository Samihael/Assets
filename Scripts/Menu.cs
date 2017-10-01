using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu: MonoBehaviour {
    GameObject pausebutton;
    GameObject musicbutton;

    public AudioSource music;

    void Start()
    {
        musicbutton = GameObject.FindGameObjectWithTag("stopMusic");

    }

    public void PlayAgain()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    public void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

 

	public void Play () {
        SceneManager.LoadScene("scene");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("How To Play");

    }

    public void Exit()
    {
        Application.Quit();
    }


    public void StopMusic()
    {
        musicbutton.SetActive(false);
        music.Pause();
    }

    public void ResumeMusic()
    {
        musicbutton.SetActive(true);
        music.Play();
    }

}
