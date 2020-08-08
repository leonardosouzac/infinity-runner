using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlePonte : MonoBehaviour
{
    private gameControler _GameControler;
    private Rigidbody2D ponteRb;

    private bool instanciado;
    // Start is called before the first frame update
    void Start()
    {
        _GameControler = FindObjectOfType(typeof(gameControler)) as gameControler;

        ponteRb = GetComponent<Rigidbody2D>();
        ponteRb.velocity = new Vector2(_GameControler.velocidadeObjeto, 0);
          
    }

    // Update is called once per frame
    void Update()
    {
        if (instanciado == false)
        {
            if (transform.position.x <= 0)
            {
                instanciado = true;
                GameObject temp = Instantiate(_GameControler.pontePrefab);
                float posX = transform.position.x + _GameControler.tamanhoPonte;
                float posY = transform.position.y;
                temp.transform.position = new Vector3(posX, posY, 0);
            }
        }

        if (transform.position.x < _GameControler.distanciaDestruir)
        {
            Destroy(this.gameObject);
        }
    }
}
