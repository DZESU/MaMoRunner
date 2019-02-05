using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class clickbutton : MonoBehaviour {
    public Button exit;
    public Button soundBtn;
    public Sprite soundOn,soundOff;
    public void ChangeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
        GameControllerScript.isPause = false;
    }
    public void Quit()
    {
        exit.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
    public void ChangeSound()
    {
        //Sound 0 is on 1 is off
        int sound = PlayerPrefs.GetInt("Sound", 1);
        if(sound == 0)
        {
            soundBtn.GetComponent<Image>().sprite = soundOn;
            GetComponent<AudioSource>().mute = false;
            PlayerPrefs.SetInt("Sound", 1);
        }
        else
        {
            soundBtn.GetComponent<Image>().sprite = soundOff;
            GetComponent<AudioSource>().mute = true;
            PlayerPrefs.SetInt("Sound", 0);
        }

    }
}
