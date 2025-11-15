using UnityEngine;

public class SceneManager : MonoBehaviour
{
	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ToMenu()
	{
		SceneManager.LoadScene(0);
	}
}
