using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fundamentos : MonoBehaviour
{
    // Start is called before the first frame update

    private gameControler _GameControler;
    private Rigidbody2D playerRb;

    void Start()
    {
        _GameControler = FindObjectOfType(typeof(gameControler)) as gameControler;

        playerRb = GetComponent<Rigidbody2D>();

    }


    // Update is called once per frame
    void Update()

    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float posY = transform.position.y;
        float posX = transform.position.x;

        playerRb.velocity = new Vector2(horizontal * _GameControler.velocidadeMovimento, vertical * _GameControler.velocidadeMovimento);

        //verificar limite X
        if (transform.position.x < _GameControler.limiteMinX)
        {
            posX = _GameControler.limiteMinX;
        }
        else if (transform.position.x > _GameControler.limiteMaxX)
        {
            posX = _GameControler.limiteMaxX;
        }

        //verificar limite Y
        if (transform.position.y > _GameControler.limiteMaxY)
        {
            posY = _GameControler.limiteMaxY;
        }
        else if (transform.position.y < _GameControler.limiteMinY)
        {
            posY = _GameControler.limiteMinY;
        }

        transform.position = new Vector3(posX, posY, 0);
    }




}


