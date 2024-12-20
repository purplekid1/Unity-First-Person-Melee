using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(3);
        }

    }

}
