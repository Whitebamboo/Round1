using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private AudioSource bgm;

    // Start is called before the first frame update
    void Start()
    {
        bgm.Play();
        StartCoroutine("changeScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator changeScene()
    {
        yield return new WaitForSeconds(23.5f);
        SceneManager.LoadScene(1);
    }

}
