using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamelevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TombolBelajar()
    {
        SceneManager.LoadScene("game level");
    }

    // Fungsi untuk tombol bermain
    public void TombolBermain()
    {
        SceneManager.LoadScene("game level");
    }
}
