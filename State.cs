using Godot;
using System;

public abstract partial class State : Node
{

	[Signal]
	public delegate void TransitionedEventHandler();

	public abstract void Enter();

	public abstract void Exit();

	public abstract void Update(double delta);

	public abstract void PhysicsUpdate(double delta);

}
