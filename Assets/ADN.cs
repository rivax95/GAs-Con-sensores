﻿//                                          ▂ ▃ ▅ ▆ █ ZEN █ ▆ ▅ ▃ ▂ 
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

public class ADN : MonoBehaviour {


	List<int> genes = new List<int>();
	int dnaLength = 0;
	int maxValues = 0;
    public float timeWalking;
	public ADN(int l, int v)
	{
		dnaLength = l;
		maxValues = v;
		SetRandom();
	}

	public void SetRandom()
	{
		genes.Clear();
		for(int i = 0; i < dnaLength; i++)
		{
			genes.Add(Random.Range(0, maxValues));
		}
	}

	public void SetInt(int pos, int value)
	{
		genes[pos] = value;
	}

	public void Combine(ADN d1, ADN d2)
	{
		for(int i = 0; i < dnaLength; i++)
		{
			if(i < dnaLength/2.0)
			{
				int c = d1.genes[i];
				genes[i] = c;
			}
			else
			{
				int c = d2.genes[i]; 
				genes[i] = c;
			}
		}
	}

	public void Mutate()
	{
		genes[Random.Range(0,dnaLength)] = Random.Range(0, maxValues);
	}

	public int GetGene(int pos)
	{
		return genes[pos];
	}

}
