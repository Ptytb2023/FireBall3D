using UnityEngine;

namespace Structures
{
	public class DontDestroyOnLoad : MonoBehaviour
	{
		private void OnEnable() => 
			DontDestroyOnLoad(gameObject);
	}
}