using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventure : MonoBehaviour {
	
	public enum States {Cell, CellDoor, AtBed, AtWindow, HallWay, LeftCor, CenterCor, RightCor, Courtyard, Gate};
	public States CurState;
	public bool HasKey;
	public bool HasCheese;

	public int num_1;

	// Use this for initialization
	void Start () {
		CurState = States.Cell;
		HasKey = false;
		HasCheese = false; 
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (CurState == States.Cell) {
			Cell ();
		} 
		else if (CurState == States.AtWindow) {
			AtWindow ();
		}


	}
	private void Cell()
	{
		print ("you wake up in a cell. There is a shabby bed, a small window, and an iron door \n"+
			" Go to window (W) Go to bed (A) Go to door (D)");
		if (Input.GetKeyDown(KeyCode.W)) {CurState = States.AtWindow;}
		if (Input.GetKeyDown(KeyCode.A)) {CurState = States.AtBed;} 
		if (Input.GetKeyDown(KeyCode.D)) {CurState = States.CellDoor;}
	}
	private void AtWindow()
	{
		print ("The window is just large enough to squeeze through. Climb through window (W) Go back to cell (S) Go to bed (A) Go to door (D)");
		if (Input.GetKeyDown(KeyCode.W)) {print ("You climb out the window and fall to your death");}
		if (Input.GetKeyDown(KeyCode.S)) {CurState = States.Cell;} 
		if (Input.GetKeyDown(KeyCode.A)) {CurState = States.AtBed;}
		if (Input.GetKeyDown(KeyCode.D)) {CurState = States.CellDoor;}

	}
	private void CellDoor()
	{
		print ("The door has a handle. Go to window (W) Go back to cell (S) Go to bed (A) Try the handle (D)");
		if (Input.GetKeyDown(KeyCode.W)) {print ("The door opens."); CurState = States.HallWay;}
		if (Input.GetKeyDown(KeyCode.S)) {CurState = States.Cell;} 
		if (Input.GetKeyDown(KeyCode.A)) {CurState = States.AtBed;}
		if (Input.GetKeyDown(KeyCode.D)) {CurState = States.CellDoor;}

	}
}
