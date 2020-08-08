using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gameControler : MonoBehaviour
{
    private playerControler _playerControler;

    [Header("Config. Personagem")]
    public float velocidadeMovimento;
    public float limiteMaxY;
    public float limiteMinY;
    public float limiteMaxX;
    public float limiteMinX;

    [Header("Config Objetos")]
    public float velocidadeObjeto;
    public float distanciaDestruir;

    public float tamanhoPonte;
    public GameObject pontePrefab;

    [Header("Config. Barril")]

    public float posYTop;
    public float posYDown;
    public int orderTop;
    public int orderDown;

    public GameObject barrilPrefab;
    public float tempoSpawn;

    [Header("GLobals")]
    public float posXPlayer;

    public int score;

    public Text txtScore;
    [Header("FX Sound")]

    public AudioSource fxSource;
    public AudioClip fxPontos;

    // Start is called before the first frame update
    void Start()
    {
        _playerControler = FindObjectOfType(typeof(playerControler)) as playerControler;
        StartCoroutine("spawnBarril");

    }

    // Update is called once per frame
    void LateUpdate()
    {
        posXPlayer = _playerControler.transform.position.x;
    }
    IEnumerator spawnBarril()
    {
        yield return new WaitForSeconds(tempoSpawn);

        float posY = 0;
        int order = 0;

        int rand = Random.Range(0, 100);
        if (rand < 50)
        {
            //instanciar em cima
            posY = posYTop;
            order = orderTop;
        }
        else
        {
            //instanciar embaixo
            posY = posYDown;
            order = orderDown;
        }

        GameObject temp = Instantiate(barrilPrefab);

        temp.transform.position = new Vector3(temp.transform.position.x, posY, 0);
        StartCoroutine("spawnBarril");
        temp.GetComponent<SpriteRenderer>().sortingOrder = order;
    }

    public void pontuar(int qtdPontos)
    {
        score += qtdPontos;
        txtScore.text = score.ToString();
        fxSource.PlayOneShot(fxPontos);
    }


    public void mudarCena(string cenaDestino)
    {
        SceneManager.LoadScene(cenaDestino);
    }
}
