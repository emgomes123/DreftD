using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LineDrawer : MonoBehaviour
{
	public GameObject linePrefab;
	public LayerMask cantDrawOverLayer;
	int cantDrawOverLayerIndex;
	public EdgeCollider2D ed;

	[Space(30f)]
	public Gradient lineColor;
	public float linePointsMinDistance;
	public float lineWidth;
	public float timeRemaining = 1000;
	public float timeRemainingEstamina = 0;
	//public float timeRemainingEstamina = 10;

	Line currentLine;

	public int contador = 0;
	public float estamina= 40;

	private float teste = 0f;
	public float teste2 = 0f;

	Camera cam;


	void Start()
	{
		cam = Camera.main;
		cantDrawOverLayerIndex = LayerMask.NameToLayer("CantDrawOver");
		timeRemaining = 1;
	}

	void Update()
	{  
		time();

		if (GameObject.Find("Line(Clone)") != null && timeRemaining <= 0 )
		{
			Destroy(GameObject.Find("Line(Clone)"));
			
			
		}
		if(GameObject.Find("Line(Clone)") == null)
        {
			contador = 0;

		}


		if (Input.touchCount > 0)
		{

			Touch t = Input.GetTouch(0);

			if (Input.touchCount > 0 && Input.touchCount < 2)
			{

				if (Input.GetMouseButtonDown(0) && contador <= 0)
				{
					if (EventSystem.current.IsPointerOverGameObject())
					{
						return;
					}
					else
					{
						BeginDraw();
					}

				}
			}
            else
            {
				return;
            }

		}
      

		if (currentLine != null)
		{
			Draw();
		}
		if (Input.GetMouseButtonUp(0) && contador == 0)
		{
			EndDraw();
			contador = 1;
			timeRemaining = 5;
			
		}
        else
        {
			Input.GetMouseButtonUp(1);

		}     

    }


	private void FixedUpdate()
	{

        teste = currentLine.pointsCount;
        teste2 = teste;


        if (teste >= 3)
		{
			for (float cont = 0; cont < teste; cont++)
			{
				estamina -= 0.009f;

			}


			teste = 0;
		}
		if (estamina <= 0)
		{
			estamina = 0;
			currentLine.gameObject.SetActive(false);
		}

		if (estamina >= 3) {

			currentLine.gameObject.SetActive(true);
		}

	}

	void time()
    {
		timeRemaining -= Time.fixedDeltaTime;
		if(timeRemaining <= -1)
        {
			timeRemaining = 1000;
		}

		
	}


	// Begin Draw ----------------------------------------------
	void BeginDraw()
	{

	
			currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();

			//Set line properties
			currentLine.UsePhysics(false);
			currentLine.SetLineColor(lineColor);
			currentLine.SetPointsMinDistance(linePointsMinDistance);
			currentLine.SetLineWidth(lineWidth);
		

	}
	// Draw ----------------------------------------------------
	void Draw()
	{
		Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

		//Check if mousePos hits any collider with layer "CantDrawOver", if true cut the line by calling EndDraw( )
		RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer);

		if (hit)
		{
			EndDraw();
		}
		else
		{

			currentLine.AddPoint(mousePosition);

            if (currentLine.pointsCount >= 25)
			{

				EndDraw();
				contador++;
				timeRemaining = 5;


			}
		}
	}
	// End Draw ------------------------------------------------
	void EndDraw()
	{
		if (currentLine != null)
		{
			if (currentLine.pointsCount < 2)
			{
				//If line has one point
				
				Destroy(currentLine.gameObject);
				
				


			}
			else
            {
				//Add the line to "CantDrawOver" layer
				currentLine.gameObject.layer = cantDrawOverLayerIndex;

				//Activate Physics on the line
				currentLine.UsePhysics(true);

				currentLine = null;



			}
		}
	}
}
