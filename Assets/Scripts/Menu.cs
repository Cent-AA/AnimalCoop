using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("ChoosingInputs"); // временно
        //сначало катсцена потом выбор перса потом уровень 
        // надо будет в катсцену потом поменять
        
    }
    public void FinishInputSetting()
    {
        SceneManager.LoadSceneAsync("SampleScene"); // временно
        //сначало катсцена потом выбор перса потом уровень 
        // надо будет в катсцену потом поменять
        
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("В эдиторе не будет выходить поэтому вроде норм. Нужно будет потестить в забилденной игре");
    }
}
