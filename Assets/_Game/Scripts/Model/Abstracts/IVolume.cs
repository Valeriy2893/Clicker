using R3;

public interface IVolume
{
    public ReadOnlyReactiveProperty<int> CurrentVolume { get; }
    public void VolumeControl();
}