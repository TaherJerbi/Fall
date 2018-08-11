using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {
    
	public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
