using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] GameObject Spelen;
    [SerializeField] GameObject Level1;
    [SerializeField] GameObject Level2;
    [SerializeField] GameObject Level3;
    [SerializeField] GameObject Return;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onButtonSpelem()
    {
        Level1.SetActive(true);
        Level2.SetActive(true);
        Level3.SetActive(true);
        Spelen.SetActive(false);
    }

    public void onButtonLevel1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void onButtonLevel2()
    {
        SceneManager.LoadScene("Level2");

    }

    public void onButtonLevel3()
    {

    }

    public void onButtonReturn()
    {
        SceneManager.LoadScene("Menu");
    }
}
