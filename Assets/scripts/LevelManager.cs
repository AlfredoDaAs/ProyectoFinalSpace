using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

	public float loadNextLevelAfter = 3;

	void Start ()
	{
		if (loadNextLevelAfter > 0) {
			Invoke ("LoadNextLevel", loadNextLevelAfter);
		}
	}

	public void LoadLevel (string level)
	{
		Debug.Log ("Loading level: " + level);
		SceneManager.LoadScene (level);
	}

	public void QuitRequest ()
	{
		Debug.Log ("Quit game.");
		Application.Quit ();
	}

	public void LoadNextLevel ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}
}