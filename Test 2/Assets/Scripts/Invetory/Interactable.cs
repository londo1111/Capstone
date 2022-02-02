using System;

public class Interactable
{
    public override void Interact()
    {
        base.Interact();

        PickUp();
    }
    internal void Interact()
    {
        throw new NotImplementedException();
    }
}