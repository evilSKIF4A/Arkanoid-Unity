using UnityEngine;
using UnityEngine.SceneManagement;

public class SwapScene : MonoBehaviour
{
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        if (!PlayerPrefs.HasKey("LastLevel"))
            PlayerPrefs.SetInt("LastLevel", 1);
        if (!PlayerPrefs.HasKey("Coin"))
            PlayerPrefs.SetInt("Coin", 0);
    }
    public void OpenMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void OpenGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("LastLevel"));
    }
    public void OpenChooseShop()
    {
        SceneManager.LoadScene("ChooseShop");
    }
    public void OpenShop(string nameProduct)
    {
        PlayerPrefs.SetString("ChooseProduct", nameProduct);
        SceneManager.LoadScene("Shop");
    }
    public void OpenLevels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void OpenLevel(string nameLevel)
    {
        if(PlayerPrefs.GetInt(nameLevel.ToLower() + "Open") == 1)
            SceneManager.LoadScene(nameLevel);
    }
    public void OpenTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
