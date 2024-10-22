using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Brain_sc : MonoBehaviour
{
    public int DNALength = 1;
    public float timeALive;
    public DNA_sc dna_sc;
    private ThirdPersonCharacter m_character;
    private Vector3 m_move;
    private bool m_jump;
    bool isAlive = true;
    void OnCollisionEnter(Collision obj){
        if(obj.gameObject.tag == "Dead")
        {
            isAlive = false;
        }
    }
    // Initialize DNA
    public void Init(){
        //0 forward
        //1 back
        //2 left
        //3 right
        //4 jump
        //5 crouch
        dna_sc = new DNA_sc(DNALength, 6);
        m_character = GetComponent<ThirdPersonCharacter>();
        timeALive = 0;
        isAlive = true;
    }
    private void FixedUpdate(){
        //read DNA
        float horizontal = 0;
        float vertical = 0;
        bool crouch = false;
        if(dna_sc.GetGene(0) == 0) vertical = 1;
        else if(dna_sc.GetGene(0) == 1) vertical = -1;
        else if(dna_sc.GetGene(0) == 2) horizontal = -1;
        else if(dna_sc.GetGene(0) == 3) horizontal = 1;
        else if(dna_sc.GetGene(0) == 4) m_jump = true;
        else if(dna_sc.GetGene(0) == 5) crouch = true;
        m_move = vertical * Vector3.forward + horizontal * Vector3.right;
        m_character.Move(m_move, crouch, m_jump);
        m_jump = false;
        if(isAlive){
            timeALive += Time.deltaTime;
        }
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}