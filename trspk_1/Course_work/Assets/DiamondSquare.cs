using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Here, code praying to the GOD for protecting our open file from all bugs and other things.
//This is really crucial step! Be adviced to not remove it, even if don't believer.
//Rahman ve Rehim olan Allan'in in adiyla

public class IJ
{
	public IJ(int I, int J)
	{
		i = I;
		j = J;
	}
	public int i;
	public int j;
}



public class DiamondSquare : MonoBehaviour
{
	public float upperRange = 10.0f;
	private float lowerRange = 0.01f;
	public float roughness = 0.01f;
	private float outOfBoundsH;
	private int twoPow = 1;

	private float unit;
	private float[,] heightMap;

	public void TerraForm(ref float[,] heightMap)
	{

	}

	private void Diamond(IJ[] square, int lenght)
	{
		IJ center = new IJ((square[0].i + square[2].i) / 2, (square[0].j + square[2].j) / 2);
	}

	public void Square(IJ start, IJ finish, int lenghtOld)
	{
		int lenght = Convert.ToInt32(Math.Sqrt(lenghtOld));//длина стороны квадрата
		IJ[] square = new IJ[4];
		int type;

		if (start.i > finish.i)
		{
			if (start.j < finish.j)
				type = 3;
			else
				type = 0;
		}
		else
		{
			if (start.j < finish.j)
				type = 2;

			else
				type = 1;
		}
		if (type == 1 || type == 3)
		{
			square[0] = start;
			square[1] = new IJ(start.i, finish.j);
			square[2] = finish;
			square[3] = new IJ(finish.i, start.j);
		}
		else
		{
			square[0] = start;
			square[1] = new IJ(finish.i, start.j);
			square[2] = finish;
			square[3] = new IJ(start.i, finish.j);
		}

	}

	private float segmentLength(IJ start, IJ finish)//вычисление растояния между точками
	{
		double segmentLength = Math.Pow((start.i* unit - finish.i*unit), 2) + Math.Pow((start.j * unit - finish.j * unit), 2);
		return (float)Math.Sqrt(segmentLength);
	}

	public void Start(int N,float unit)
	{
		this.unit = unit;
		int mapRang = (int)Math.Pow(2, N) + 1;
		float[,] heightMap = new float[mapRang, mapRang];

		while (twoPow <= (heightMap.Length - 1) / 2)//количество итераций
			twoPow *= 2;
		twoPow /= 2;

	}

}
//بِسْمِ ٱللَّهِ ٱلرَّحْمَٰنِ ٱلرَّحِيمِ
//ٱلْحَمْدُ لِلَّهِ رَبِّ ٱلْعَٰلَمِينَ
//ٱلرَّحْمَٰنِ ٱلرَّحِيمِ
//مَٰلِكِ يَوْمِ ٱلدِّينِ
//إِيَّاكَ نَعْبُدُ وَإِيَّاكَ نَسْتَعِينُ
//ٱهْدِنَا ٱلصِّرَٰطَ ٱلْمُسْتَقِيمَ
//صِرَٰطَ ٱلَّذِينَ أَنْعَمْتَ عَلَيْهِمْ غَيْرِ ٱلْمَغْضُوبِ عَلَيْهِمْ وَلَا ٱلضَّآلِّينَ

