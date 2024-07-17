using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float MAX_SPEED = 175.0f;
	public const float ACCELERATION = 13.0f;
	public const float FRICTION = 15.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		direction = direction.Normalized();

		if (direction != Vector2.Zero)
		{
			velocity = velocity.MoveToward(direction * MAX_SPEED, ACCELERATION);
		}
		else
		{
			velocity = velocity.MoveToward(Vector2.Zero, FRICTION);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
