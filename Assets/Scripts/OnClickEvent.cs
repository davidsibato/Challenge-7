using TMPro;
using UnityEngine;

public class OnClickEvent : MonoBehaviour
{
    public TextMeshProUGUI soundsText;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.mute)
        {
            soundsText.text = "/";
        }
        else 
        {
             soundsText.text = "";
        }
    }

    // Update is called once per frame
   
    public void ToggleMute()
    {
        if(GameManager.mute)
        {
            GameManager.mute = false;
            soundsText.text = "";

        }else
        
        {
            GameManager.mute = true;
            soundsText.text = "/";
        }
    }
   
   
   
   
   
    public void QuitGame()
    {
        Application.Quit();
    }
}
