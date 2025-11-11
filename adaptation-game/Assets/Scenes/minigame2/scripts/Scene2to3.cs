using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene2to3 : MonoBehaviour
{
    public LightCigarette lc;
    public PourDrink pd;
    public GameObject proceedButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        proceedButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lc.isBurned == true && pd.drinkFinished == true)
        {
            Debug.Log("both satisfied");
            proceedButton.SetActive(true);
        }
    }

    public void OpenScene3()
    {
        SceneManager.LoadScene("ThirdVignette");
    }
    

}
