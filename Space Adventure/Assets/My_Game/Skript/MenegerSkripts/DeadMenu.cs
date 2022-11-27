using UnityEngine.SceneManagement;
using UnityEngine;

public class DeadMenu : MonoBehaviour
{
    public bool GameisPause = false;
    public GameObject deadMenu;
    [SerializeField] public GameObject[] CanvasList;

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        Debug.Log("Exit");
    }

    public void GameOver()
    {
        HideCanvas();
        GameisPause = true;
        deadMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    private void HideCanvas()
    {
        for (int i = 0; i < CanvasList.Length; i++)
        {
            CanvasList[i].SetActive(false);
        }
    }
}
