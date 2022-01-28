using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace RelayDriver
{
    /// <summary>
    /// Relay model implementing IRelay interface
    /// </summary>
    public class Relay : IRelay
    {
        private string relayAddress; // Address not used in simulator, but would be in real use case
        private const string version = "000021-07"; // Hardcoded version number
        private readonly string dirPath = Environment.CurrentDirectory; // Current working directory for log file
        private const string fileName = "RelayLog.txt"; // Log file name
        private Dictionary<int, byte> relayState = new Dictionary<int, byte>(); // Saves the state of all relays

        /// <summary>
        /// Relay constructor
        /// Set relay address and initialize relay states
        /// </summary>
        /// <param name="address"> Serial COM address of relay module </param>
        public Relay(string address)
        {
            relayAddress = address;
            InitializeStates();
        }

        /// <summary>
        /// Read the relay state value
        /// </summary>
        /// <param name="relayNum"> Relay number </param>
        /// <returns> relayState (0 or 1 for on and off) </returns>
        public byte Read(int relayNum)
        {
            Task asyncWrite = Write($"Relay Read {relayNum}");
            return relayState[relayNum];
        }

        /// <summary>
        /// Reads the specified ADC value
        /// </summary>
        /// <param name="inputNum"> ADC input </param>
        /// <returns> Random integer between 0 and 1023 to represent voltage </returns>
        public int ReadAdcValue(int inputNum)
        {
            Random rnd = new Random();
            Task asyncWrite = Write($"Adc Read {inputNum}");
            return rnd.Next(1024);
        }

        /// <summary>
        /// Gets the firmware version of the module
        /// </summary>
        /// <returns> Version number </returns>
        public string ReadFirmwareVersion()
        {
            Task asyncWrite = Write("Version");
            return version;
        }

        /// <summary>
        /// Sends a write command to set the state of the relay module
        /// </summary>
        /// <param name="relayNum"> Relay number</param>
        /// <param name="on"> Whether to turn relay on or off </param>
        public void SetRelayState(int relayNum, bool on)
        {
            relayState[relayNum] = Convert.ToByte(on);
            Task asyncWrite = Write($"Relay {(on ? "on" : "off")} {relayNum}");
        }

        /// <summary>
        /// Sends command to relay module
        /// Asynchronously writes command to log file instead of sending actual command
        /// </summary>
        /// <param name="writeCommand"></param>
        /// <returns></returns>
        private async Task Write(string writeCommand)
        {
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(dirPath, fileName)))
            {
                await outputFile.WriteAsync(writeCommand);
            }
        }

        /// <summary>
        /// Sets the initial relay states to off
        /// </summary>
        private void InitializeStates()
        {
            for (int i = 0; i < 4; i++)
            {
                relayState[i] = 0;
            }
        }
    }
}
