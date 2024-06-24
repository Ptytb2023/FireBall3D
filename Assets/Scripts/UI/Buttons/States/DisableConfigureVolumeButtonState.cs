namespace UI.Buttons.States
{
    public class DisableConfigureVolumeButtonState : ConfigureVolumeButtonState
    {
        protected override float VolumeLevel => -80.0f;
    }
}
