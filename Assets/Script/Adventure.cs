using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Adventure : MonoBehaviour {
	
	public enum States {Cell, CellDoor, AtBed, AtWindow, HallWay, LeftCor, CenterCor, RightCor, Courtyard, Gate};
	public States CurState;
	public bool HasKey;
	public bool HasCheese;
	public bool HasSword;
	public bool GuardDead;
	public Text textObject;
	public Text textEvent;
	public int num_1;


	// Use this for initialization
	void Start () {
		CurState = States.Cell;
		HasKey = false;
		HasCheese = false; 
		HasSword = false;
		GuardDead = false;
		textObject.text = "Welcome";


	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (CurState == States.Cell) {
			Cell ();
		} else if (CurState == States.AtWindow) {
			AtWindow ();
		} else if (CurState == States.AtBed) {
			AtBed ();
		} else if (CurState == States.CellDoor) {
			CellDoor ();
		} else if (CurState == States.HallWay) {
			HallWay ();
		} else if (CurState == States.LeftCor) {
			LeftCor ();
		} else if (CurState == States.CenterCor) {
			CenterCor ();
		} else if (CurState == States.RightCor) {
		 	RightCor ();
		} else if (CurState == States.Courtyard) {
			Courtyard ();
		} else if (CurState == States.Gate) {
			Gate ();
		}


	}
	private void Cell()
	{
		print ("You wake up in a cell. There is a shabby bed, a small window, and an iron door \n Go to window (W) Go to bed (A) Go to door (D)");
		textObject.text = "you wake up in a cell. There is a shabby bed, a small window, and an iron door \n Go to window (W) Go to bed (A) Go to door (D)";
		if (Input.GetKeyDown(KeyCode.W)) {CurState = States.AtWindow;}
		if (Input.GetKeyDown(KeyCode.A)) {CurState = States.AtBed;} 
		if (Input.GetKeyDown(KeyCode.D)) {CurState = States.CellDoor;}

	}
	private void AtWindow()
	{
		print ("The window is just large enough to squeeze through.\n Climb through window (W) Go back to cell (S) Go to bed (A) Go to door (D)");
		textObject.text = "The window is just large enough to squeeze through.\n Climb through window (W) Go back to cell (S) Go to bed (A) Go to door (D)";
		if (Input.GetKeyDown (KeyCode.W)) {
			textEvent.text="You climb out the window and fall to your death"; Start ();}
		if (Input.GetKeyDown(KeyCode.S)) {CurState = States.Cell;} 
		if (Input.GetKeyDown(KeyCode.A)) {CurState = States.AtBed;}
		if (Input.GetKeyDown(KeyCode.D)) {CurState = States.CellDoor;}

	}
	private void CellDoor()
	{
		
		print ("The door has a handle. \n Go to window (W) Go back to cell (S) Go to bed (A) Try the handle (D)");
		textObject.text = "The door has a handle. \n Go to window (W) Go back to cell (S) Go to bed (A) Try the handle (D)";
		if (Input.GetKeyDown(KeyCode.D)) {textEvent.text = "The door opens."; CurState = States.HallWay;}
		if (Input.GetKeyDown(KeyCode.S)) {CurState = States.Cell;} 
		if (Input.GetKeyDown(KeyCode.A)) {CurState = States.AtBed;}
		if (Input.GetKeyDown(KeyCode.W)) {CurState = States.AtWindow;}

	}
	private void AtBed()
	{
		
		print ("There's an old rusty key under the bed.\n Go to window (W) Go back to cell (S) Go to door (A) Grab the key (D)");
		textObject.text = "There's an old rusty key under the bed.\n Go to window (W) Go back to cell (S) Go to door (A) Grab the key (D)";
		if (Input.GetKeyDown(KeyCode.W)) {CurState = States.AtWindow;}
		if (Input.GetKeyDown(KeyCode.S)) {CurState = States.Cell;} 
		if (Input.GetKeyDown(KeyCode.A)) {CurState = States.CellDoor;}
		if (Input.GetKeyDown(KeyCode.D)) {if (HasCheese == true) {
				HasKey = true;
				print ("You place the cheese down and the rat runs out to grab it. You quickly grab the key.");
				textEvent.text ="You place the cheese down and the rat runs out to grab it. You quickly grab the key.";
			} else {
			print ("A rat jumps out of the bed and bites you. You get infected and die");
			textObject.text = "A rat jumps out of the bed and bites you. You get infected and die";
			Start ();}}

	}
	private void HallWay()
	{
		print ("You reach a fork in the hallway. There is a path straight forward, as well as one to the left and right.\n Go left (A) Go Straight (W) Go right (D) Go back (S)");
		textObject.text = "You reach a fork in the hallway. There is a path straight forward, as well as one to the left and right.\n Go left (A) Go Straight (W) Go right (D) Go back (S)";
		if (Input.GetKeyDown(KeyCode.D)) {CurState = States.RightCor;}
		if (Input.GetKeyDown(KeyCode.S)) {CurState = States.CellDoor;} 
		if (Input.GetKeyDown(KeyCode.A)) {CurState = States.LeftCor;}
		if (Input.GetKeyDown(KeyCode.W)) {CurState = States.CenterCor;}

	}
	private void LeftCor ()
	{
	print("As you round the corner, a guard turns to face you. You are returned to your cell");
		textEvent.text = "As you round the corner, a guard turns to face you. You are returned to your cell";
		CurState = States.Cell;
		Start ();
	}
	private void CenterCor()
	{
		print ("The hallway ends in a dead end. In the corner you find a slice of cheese, and a sword.\n Grab the cheese (A) Grab the sword (D) Return to the fork (S)");
		textObject.text = "The hallway ends in a dead end. In the corner you find a slice of cheese, and a sword.\n Grab the cheese (A) Grab the sword (D) Return to the fork (S)";
		if (Input.GetKeyDown(KeyCode.D)) {if (!HasSword) {HasSword = true; textEvent.text = "You pick up the sword";} else {textEvent.text = "you already have a sword";}}
		if (Input.GetKeyDown(KeyCode.S)) {CurState = States.HallWay;} 
		if (Input.GetKeyDown(KeyCode.A)) {if (!HasCheese) {HasCheese = true; textEvent.text="You pick up the cheese";} else {textEvent.text ="you already have a piece of cheese";}}

	}
	private void RightCor()
	{
		print ("There is a door at the end of this hallway.\n Try the handle (W) return to fork (S)");
		textObject.text = "There is a door at the end of this hallway.\n Try the handle (W) return to fork (S)";
		if (Input.GetKeyDown(KeyCode.W)) {if (!HasKey) { textEvent.text = "The door is locked, you must find a key";} else {textEvent.text = "You use they key you found under the bed, and the door swings open"; CurState = States.Courtyard;}}
		if (Input.GetKeyDown(KeyCode.S)) {CurState = States.HallWay;} 


	}
	private void Courtyard()
	{
		print ("You are in a large courtyard. It's mostly empty save a guard who is asleep. \n Tackle the guard (A) Walk past the guard (W) Go back into the hall (S)");
		textObject.text = "You are in a large courtyard. It's mostly empty save a guard who is asleep. \n Tackle the guard (A) Walk past the guard (W) Go back into the hall (S)";
		if (Input.GetKeyDown(KeyCode.A)) {if (HasSword) {textEvent.text= "While you sneak up on the guard, you drop your sword waking him up. You are returned to your cell"; Start ();} else {textEvent.text = "You sneak up to the guard and strangle him to death"; GuardDead=true;}}
		if (Input.GetKeyDown(KeyCode.S)) {CurState = States.RightCor;} 
		if (Input.GetKeyDown (KeyCode.W)) {
			if (!GuardDead) {textEvent.text = "The guard wakes up, and you are returned to your cell"; Start ();} else {CurState = States.Gate;}}

	}
	private void Gate()
	{
		print ("You reach the gate. There is a mechanism used to hoist the gate up to your left.  \n Climb the gate (W) Try the mechanism (A) Return to Courtyard (S)");
		textObject.text = "You reach the gate. There is a mechanism used to hoist the gate up to your left.  \n Climb the gate (W) Try the mechanism (A) Return to Courtyard (S)";
		if (Input.GetKeyDown(KeyCode.A)) {if (HasSword) { textEvent.text = "You wedge the sword in the mechanism and use it as a lever to open the gate. You are finally free."; Start ();} else {textEvent.text="You try to pull the mechanism, but it won't budge";}}
		if (Input.GetKeyDown(KeyCode.S)) {CurState = States.Courtyard;} 
		if (Input.GetKeyDown(KeyCode.W)) {textEvent.text="You climb up the gate and reach the top, but you startle a flock of birds, and as they fly away they wake up a nearby guard. You are returned to your cell"; Start ();}

	}
}
