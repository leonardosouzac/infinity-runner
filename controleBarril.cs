using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controleBarril : MonoBehaviour
{
    private gameControler _GameControler;

    private Rigidbody2D barrilRb;

    private bool pontuado;

    // Start is called before the first frame update
    void Start()
    {
        _GameControler = FindObjectOfType(typeof(gameControler)) as gameControler;
        barrilRb = GetComponent<Rigidbody2D>();
        barrilRb.velocity = new Vector2(_GameControler.velocidadeObjeto, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x < _GameControler.distanciaDestruir)
        {
            Destroy(this.gameObject);
        }
    }

    void LateUpdate()
    {
        if (pontuado == false && transform.position.x < _GameControler.posXPlayer)
        {
            pontuado = true;
            print("Ponto");
            _GameControler.pontuar(1);
        }
    }
}
