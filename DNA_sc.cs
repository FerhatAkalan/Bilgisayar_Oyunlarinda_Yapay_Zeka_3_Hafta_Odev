using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DNA_sc : MonoBehaviour
{
    List<int> genes = new List<int>();
    int dnaLength;// DNA uzunluğu
    int maxValues;// Maksimum genetik değer
    // DNA Constructor'ı
    public DNA_sc(int length, int max){
        dnaLength = length;
        maxValues = max;
        SetRandom();
    }
    // Rastgele DNA kodu (length uzunluğunda, en fazla max değerine sahip olacak şekilde) oluşturur.
    public void SetRandom(){
        genes.Clear();
        for(int i = 0; i < dnaLength; i++){
            genes.Add(Random.Range(0, maxValues));
        }
    }
    public void SetInt(int pos, int value){
        genes[pos] = value;
    }
    //İki DNA kodunu (yarısı farklı ebeveynlerden gelecek şekilde) birleştiren fonksiyon
    public void Combine(DNA_sc dna1, DNA_sc dna2){
        for(int i = 0;i < dnaLength; i++){
            if(i < dnaLength / 2.0){
                int c = dna1.genes[i];
                genes[i] = c;
            }
            else{
                int c = dna2.genes[i];
                genes[i] = c;
            }
        }
    }
    // Gen mutasyonu
    public void Mutate(){
        genes[Random.Range(0, dnaLength)] = Random.Range(0, maxValues);
    }
    public int GetGene(int pos){
        return genes[pos];
    }
    void Start()
    {
        
    }
    void Update()
    {
        
    }
}