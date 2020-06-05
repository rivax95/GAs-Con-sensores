//                                          ▂ ▃ ▅ ▆ █ ZEN █ ▆ ▅ ▃ ▂ 
//                                        ..........<(+_+)>...........
// .cs (//)
//Autor: Alejandro Rivas                 alejandrotejemundos@hotmail.es
//Desc:
//Mod : 
//Rev :
//..............................................................................................\\
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
public class Brain : MonoBehaviour
{

    public int DNALength = 2;
    public float timeAlive;
    public ADN dna;
    public GameObject ojos;
    bool seeGround = true;
    public float timeWalking;

    bool alive = true;

    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "dead")
        {
            alive = false;
            timeAlive = 0;
            timeWalking = 0;
        }
    }

    public void Init()
    {
        //initialise DNA
        //0 forward
        //1 left
        //2 right

        dna = new ADN(DNALength, 3); // 3 ACCIONES
    //    m_Character = GetComponent<ThirdPersonCharacter>();
        timeAlive = 0;
        alive = true;
    }


    void Update()
    {
        if (!alive) return;
        Debug.DrawRay(ojos.transform.position, ojos.transform.forward * 10, Color.red, 10);
        seeGround = false;
        RaycastHit hit;

        if (Physics.Raycast(ojos.transform.position, ojos.transform.forward * 10, out hit))
        {
            if (hit.collider.gameObject.tag == "platform")
            {
                seeGround = true;
            }
        }
        timeAlive = PopulationManager.elapsed;
        // lectura de patrones de adn
        float h = 0; //rotar
        float v = 0; //moover
        if (seeGround)
        {
            if (dna.GetGene(0) == 0) { v = 1; timeWalking++; } // hacia a delante
            else if (dna.GetGene(0) == 1) h = -90; // pal lao contrario
            else if (dna.GetGene(0) == 2) h = 90; // pal lao
        }
        else // si el ray no detecta el suelo
        {
            if (dna.GetGene(1) == 0) { v = 1; timeWalking++; }// hacia a delante
            else if (dna.GetGene(1) == 1) h = -90; // pal lao contrario
            else if (dna.GetGene(1) == 2) h = 90; // pal lao
        }
        // lo hago con translate por vageria
        this.transform.Translate(0, 0, v * 0.1f);
        this.transform.Rotate(0, h, 0);
    }


    // Fixed update is called in sync with physics
   
}
