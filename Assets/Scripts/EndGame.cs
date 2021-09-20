using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Material Material_1;
    [SerializeField] private Material Material_2;
    [SerializeField] private Material Material_3;
    [SerializeField] private Material Material_4;

    [SerializeField] private AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        Player.winStatus = true;
        if (Player.winStatus)
        {
            StartCoroutine("displayWinPicture");
        }
        else
        {
            this.gameObject.GetComponent<MeshRenderer>().material = Material_4;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator displayWinPicture()
    {
        this.gameObject.GetComponent<MeshRenderer>().material = Material_1;
        //bgm.Play();
        yield return new WaitForSeconds(3f);
        this.gameObject.GetComponent<MeshRenderer>().material = Material_2;
        yield return new WaitForSeconds(3f);
        this.gameObject.GetComponent<MeshRenderer>().material = Material_3;
        yield return new WaitForSeconds(3f);
    }
}
