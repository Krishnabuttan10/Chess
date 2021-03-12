using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class splash : MonoBehaviour
{
    public Image logo,bg;
    
    void Start()
    {
        logo.fillAmount.Equals(1f);
        //note1.SetActive(true);           
        //StartCoroutine(Wait());
    }
    public bool coolingDown;
    public float waitTime = 1.0f;
    public float waitTimebg = 0.01f;

    // Update is called once per frame
    void Update()
    {
        if (coolingDown == true)
        {
            //Reduce fill amount over 30 seconds
            logo.fillAmount -= 1.0f / waitTime * Time.deltaTime;
            bg.fillAmount -= 1.0f / waitTimebg * Time.deltaTime;
            if (bg.fillAmount == 0f)
            { StartCoroutine(Wait()); }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.2f);
      
        Debug.Log("Level Enter");
       // note1.SetActive(false);
        SceneManager.LoadScene("Home");
    }
}
