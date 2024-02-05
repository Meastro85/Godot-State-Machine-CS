using Godot;
using System;

public partial class State : Node
{

	[Signal]
	public delegate void TransitionedEventHandler();

	public void Enter()
	{
		return;
	}

	public void Exit()
	{
		return;
	}

	public void Update(double delta)
	{
		return;
	}

	public void PhysicsUpdate(double delta)
	{
		return;
	}

}
