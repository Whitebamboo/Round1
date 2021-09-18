using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changePicture : MonoBehaviour
{
    [SerializeField] private Material Material_1;
    [SerializeField] private Material Material_2;
    [SerializeField] private Material Material_3;
    [SerializeField] private Material Material_4;
    [SerializeField] private Material Material_5;

    [SerializeField] private AudioSource bgm;


    void Start()
    {
        StartCoroutine("displayPicture");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator displayPicture()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = Material_1;
        bgm.Play();
        yield return new WaitForSeconds(3f);
        this.gameObject.GetComponent<MeshRenderer>().material = Material_2;
        yield return new WaitForSeconds(3f);
        this.gameObject.GetComponent<MeshRenderer>().material = Material_3;
        yield return new WaitForSeconds(3f);
        this.gameObject.GetComponent<MeshRenderer>().material = Material_4;
        yield return new WaitForSeconds(3f);
        this.gameObject.GetComponent<MeshRenderer>().material = Material_5;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    } 
}
