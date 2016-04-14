using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class StartupController : MonoBehaviour {

	public GameObject buttons;
	public GameObject learnPanel;
	public GameObject aboutPanel;
	public GameObject mainText;

	void Start(){
		learnPanel.SetActive (false);
		aboutPanel.SetActive (false);
		buttons.SetActive (true);
		mainText.SetActive (true);
	}

	void Update(){

	}

	public void StartLevel(){
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void Exit(){
		Application.Quit ();
	}

	public void Learn(){
		buttons.SetActive (false);
		mainText.SetActive (false);
		learnPanel.SetActive (true);
		aboutPanel.SetActive (false);
	}

	public void About(){
		buttons.SetActive (false);
		mainText.SetActive (false);
		learnPanel.SetActive (false);
		aboutPanel.SetActive (true);
	}

	public void MainScreen(){
		buttons.SetActive (true);
		mainText.SetActive (true);
		learnPanel.SetActive (false);
		aboutPanel.SetActive (false);

	}

}
