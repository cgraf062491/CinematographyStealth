using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
	[SerializeField] private Image progress_bar;

	void Start()
	{
		StartCoroutine(LoadLevelAsync());
	}

	IEnumerator LoadLevelAsync()
	{
		yield return null;

		AsyncOperation operation = SceneManager.LoadSceneAsync(2);

		while(!operation.isDone)
		{
			progress_bar.fillAmount = operation.progress;
			yield return new WaitForEndOfFrame();
		}
	}
}
