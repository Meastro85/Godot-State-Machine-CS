using Godot;
using System;

public partial class EnemyFollow : State
{

	[Export]
	public RigidBody2D Enemy;
	[Export]
	public float MoveSpeed = 100.0f;
	private Area2D Player;

	public override void Enter()
	{
		Player = (Area2D)GetTree().GetFirstNodeInGroup("Player");
	}

	public override void Exit()
	{
		return;
	}

	public override void Update(double delta)
	{
		return;
	}

	public override void PhysicsUpdate(double delta)
	{
		Vector2 direction = Player.GlobalPosition - Enemy.GlobalPosition;
		Enemy.LinearVelocity = direction.Normalized() * MoveSpeed;

		if(direction.length() > 100)
		{
			Transitioned.emit(self, "New state name")
		}
		
	}
}
