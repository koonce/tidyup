using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null; 
	
    //Doesn't allow two play twice/over each other
	void Awake(){
		if (instance != null){
			Destroy (gameObject);
		} else{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}	
	// Update is called once per frame
	void Update () {
	
	}
}
 