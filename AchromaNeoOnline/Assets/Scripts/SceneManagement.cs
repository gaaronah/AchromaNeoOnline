using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void moveToScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
