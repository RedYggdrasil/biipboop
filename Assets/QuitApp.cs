using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApp : MonoBehaviour
{
	public void QuitAppFunction()
	{
#if UNITY_ENGINE

#else
		Application.Quit();
#endif
	}
}
