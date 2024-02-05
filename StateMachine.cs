using Godot;
using System;
using System.Collections.Generic;

public partial class StateMachine : Node
{

	private Dictionary<string, State> States = new();
	private State CurrentState;
	[Export]
	public State InitialState;

	public override void _Ready()
	{
		foreach(var child in GetChildren())
		{
			if(child is State state)
			{
				States[child.Name.ToString().ToLower()] = state;
				state.Connect(State.SignalName.Transitioned, new Callable(this, MethodName.OnChildTransition));
			}
		}

		if(InitialState != null)
		{
			InitialState.Enter();
			CurrentState = InitialState;
		}

	}

	public override void _Process(double delta)
	{
		if(CurrentState != null)
		{
			CurrentState.Update(delta);
		}
	}

    public override void _PhysicsProcess(double delta)
    {
		if(CurrentState != null)
		{
			CurrentState.PhysicsUpdate(delta);
		}
        base._PhysicsProcess(delta);
    }

	private void OnChildTransition(State state, string newStateName)
	{
		State newState = States[newStateName.ToLower()];
		if(state != CurrentState) return;
		if(newState == null) return;

		if(CurrentState != null)
		{
			CurrentState.Exit();
		}

		newState.Enter();
		CurrentState = newState;
		

	}

}
