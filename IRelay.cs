namespace RelayDriver
{
    /// <summary>
    /// Public interface for relay model
    /// </summary>
    public interface IRelay
    {
        byte Read(int relayNum);
        void SetRelayState(int relayNum, bool on);
        string ReadFirmwareVersion();
        int ReadAdcValue(int inputNum);
    }
}
