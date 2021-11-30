using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//Here, code praying to the GOD for protecting our open file from all bugs and other things.
//This is really crucial step! Be adviced to not remove it, even if don't believer.
//Rahman ve Rehim olan Allan'in in adiyla


public class DiamondSquare : MonoBehaviour
{
	public float upperRange = 0.1f;
	private float lowerRange = 0.01f;
	public float roughness = 0.01f;
	private float outOfBoundsH;

	public void TerraForm(MeshCreator meshCreator,int n)
	{
		int stop = (int)Math.Pow(2, n);
		int rightBorder = (meshCreator.Vertices.Count - 1) / 2;
		int ochenNuznayaXyeta = 1; //Правда очень нужная хуета
		while (ochenNuznayaXyeta <= rightBorder)
			ochenNuznayaXyeta *= 2;
		ochenNuznayaXyeta /= 2;

		Square(meshCreator, 0, meshCreator.Vertices.Count - 1, meshCreator.Vertices.Count - 1, ochenNuznayaXyeta, stop);
	}

	private void Diamond(MeshCreator meshCreator, int start, int finish, int lenght, int twoPow, int stop)
	{
		int[] square = new int[4];//массив индексов углов квадрата
		square[0] = start;
		square[1] = start + lenght;
		square[2] = finish - lenght;
		square[3] = finish;

		int center = (start + finish) / 2;

		//float halfLenght = segmentLength(meshCreator.Vertices[square[0]], meshCreator.Vertices[square[1]]);//центр стороны квадрата
		float diagonal = segmentLength(meshCreator.Vertices[square[0]], meshCreator.Vertices[square[3]]);//длина диагонали

		float height = ((meshCreator.Vertices[square[0]].y + meshCreator.Vertices[square[1]].y + 
			meshCreator.Vertices[square[2]].y + meshCreator.Vertices[square[3]].y) / 4) +
			UnityEngine.Random.Range(-roughness * diagonal, roughness * diagonal);//вычисление высоты точки
		
		meshCreator.Vertices[center] = new Vector3(meshCreator.Vertices[center].x, height, meshCreator.Vertices[center].z);


		if (twoPow == stop)
			return;

		Square(meshCreator, square[0], center, lenght, twoPow / 2, stop);
		Square(meshCreator, square[1], center, lenght, twoPow / 2, stop);
		Square(meshCreator, center, square[2], lenght, twoPow / 2, stop);
		Square(meshCreator, center, square[3], lenght, twoPow / 2, stop);
	}

	public void Square(MeshCreator meshCreator, int start, int finish, int lenghtOld,int twoPow, int stop)
	{
		int lenght = Convert.ToInt32(Math.Sqrt(lenghtOld));//длина стороны квадрата
		float randNum;

		int[] square = new int[4];//массив индексов углов квадрата

		if (start + twoPow == finish)
		{
			start -= lenght;
			finish += lenght;
		}
		square[0] = start;
		square[1] = start + lenght;
		square[2] = finish - lenght;
		square[3] = finish;

		foreach (int index in square)//задаем случайные высоты углам 
		{
			if (meshCreator.Vertices[index].y != 0.0f)
				continue;
			randNum = UnityEngine.Random.Range(lowerRange, upperRange);//гененрируем случайную высоту угла

			meshCreator.Vertices[index] = new Vector3(meshCreator.Vertices[index].x, randNum, meshCreator.Vertices[index].z);//изменяем высоту точки
		}

		Diamond(meshCreator, square[0], square[3], lenght, twoPow, stop);
	}

	private float segmentLength(Vector3 point1, Vector3 point2)//вычисление растояния между точками
	{
		double segmentLength = Math.Pow((point1.x - point2.x), 2) + Math.Pow((point1.y - point2.y), 2);
		return (float)Math.Sqrt(segmentLength);
	}

	//private void Start()
	//{
	//	outOfBoundsH = upperRange / 2 * UnityEngine.Random.Range(lowerRange, upperRange);
	//}


}
//بِسْمِ ٱللَّهِ ٱلرَّحْمَٰنِ ٱلرَّحِيمِ
//ٱلْحَمْدُ لِلَّهِ رَبِّ ٱلْعَٰلَمِينَ
//ٱلرَّحْمَٰنِ ٱلرَّحِيمِ
//مَٰلِكِ يَوْمِ ٱلدِّينِ
//إِيَّاكَ نَعْبُدُ وَإِيَّاكَ نَسْتَعِينُ
//ٱهْدِنَا ٱلصِّرَٰطَ ٱلْمُسْتَقِيمَ
//صِرَٰطَ ٱلَّذِينَ أَنْعَمْتَ عَلَيْهِمْ غَيْرِ ٱلْمَغْضُوبِ عَلَيْهِمْ وَلَا ٱلضَّآلِّينَ

