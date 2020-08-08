using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comandos : MonoBehaviour
{
    public void irPara(string Cena)
    {
        SceneManager.LoadScene(Cena);
    }
}
