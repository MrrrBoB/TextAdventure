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
		else if (CurState == States.AtBed) {
			AtBed ();
		}
		else if (CurState == States.CellDoor) {
			CellDoor ();
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
		if (Input.GetKeyDown (KeyCode.W)) {
			print ("You climb out the window and fall to your death"); Start ();}
		if (Input.GetKeyDown(KeyCode.S)) {CurState = States.Cell;} 
		if (Input.GetKeyDown(KeyCode.A)) {CurState = States.AtBed;}
		if (Input.GetKeyDown(KeyCode.D)) {CurState = States.CellDoor;}

	}
	private void CellDoor()
	{
		print ("The door has a handle. Go to window (W) Go back to cell (S) Go to bed (A) Try the handle (D)");
		if (Input.GetKeyDown(KeyCode.D)) {print ("The door opens."); CurState = States.HallWay;}
		if (Input.GetKeyDown(KeyCode.S)) {CurState = States.Cell;} 
		if (Input.GetKeyDown(KeyCode.A)) {CurState = States.AtBed;}
		if (Input.GetKeyDown(KeyCode.W)) {CurState = States.AtWindow;}

	}
	private void AtBed()
	{
		print ("There's an old rusty key under the bed. Go to window (W) Go back to cell (S) Go to door (A) Grab the key (D)");
		if (Input.GetKeyDown(KeyCode.W)) {CurState = States.AtWindow;}
		if (Input.GetKeyDown(KeyCode.S)) {CurState = States.Cell;} 
		if (Input.GetKeyDown(KeyCode.A)) {CurState = States.CellDoor;}
		if (Input.GetKeyDown(KeyCode.D)) {if (HasCheese == true) {
				HasKey = true;
				print ("You place the cheese down and the rat runs out to grab it. You quickly grab the key.");
			} else {
			print ("A rat jumps out of the bed and bites you. You get infected and die"); Start ();}}

	}
}
