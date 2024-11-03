using R3;

public interface IButtonInfo
{
    public TypeButton TypeButton { get; }
    public ReadOnlyReactiveProperty<int> Value { get; }
    public ReadOnlyReactiveProperty<int> Price { get; }
    public void AddValue();
    public bool CanAddValue();
}