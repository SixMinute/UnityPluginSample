using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
	public Text text;

	// Use this for initialization
	void Start ()
	{
		text.text = SMApplicationHelper.BundleVersion() + ", " + SMApplicationHelper.BundleBuildCode();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
