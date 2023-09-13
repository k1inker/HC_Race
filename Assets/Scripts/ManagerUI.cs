using System;
public class ManagerUI : Singelton<ManagerUI>
{
    public Action<int> OnHorizontalMovement;
    public Action<int> OnVerticalMovement;
    public void SetVerticalMove(int direction)
    {
        OnVerticalMovement?.Invoke(direction);
    }
}