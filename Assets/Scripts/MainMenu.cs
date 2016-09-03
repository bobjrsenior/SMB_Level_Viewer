using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    private InputField objText;

    [SerializeField]
    private InputField configText;

    public void setObjectFilename()
    {
        string filename = objText.text;
        filename = filename.Replace(@"\", "/");
        if(!filename.Contains("/")){
            filename = "./" + filename;
        }
        Filenames.objectFilename = filename;
    }

    public void setConfigFilename()
    {
        string filename = configText.text;
        filename = filename.Replace(@"\", "/");
        if (!filename.Contains("/"))
        {
            filename = "./" + filename;
        }
        Filenames.configFilename = filename;
    }

    public void start()
    {
        SceneManager.LoadScene(1);
    }

    public void quit()
    {
        Application.Quit();
    }
}
