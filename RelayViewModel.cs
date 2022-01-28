using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace RelayDriver
{
    /// <summary>
    /// View model to connect the UI with the relay model
    /// </summary>
    public class RelayViewModel: INotifyPropertyChanged
    {
        #region Private Variables
        private IRelay relay;
        private ICommand relay0OnCommand;
        private ICommand relay0OffCommand;
        private ICommand relay1OnCommand;
        private ICommand relay1OffCommand;
        private ICommand relay2OnCommand;
        private ICommand relay2OffCommand;
        private ICommand relay3OnCommand;
        private ICommand relay3OffCommand;
        private ICommand readRelay0Command;
        private ICommand readRelay1Command;
        private ICommand readRelay2Command;
        private ICommand readRelay3Command;
        private ICommand readAdc0Command;
        private ICommand readAdc1Command;
        private ICommand readAdc2Command;
        private ICommand readAdc3Command;
        private ICommand checkFirmwareCommand;
        private string outputText;
        #endregion

        /// <summary>
        /// View model constructor
        /// Initializes relay object and connects all button commands
        /// </summary>
        public RelayViewModel()
        {
            relay = new Relay("");
            outputText = "";
            relay0OnCommand = new RelayCommand(o => RelayButtonClick(0, true));
            relay0OffCommand = new RelayCommand(o => RelayButtonClick(0, false));
            relay1OnCommand = new RelayCommand(o => RelayButtonClick(1, true));
            relay1OffCommand = new RelayCommand(o => RelayButtonClick(1, false));
            relay2OnCommand = new RelayCommand(o => RelayButtonClick(2, true));
            relay2OffCommand = new RelayCommand(o => RelayButtonClick(2, false));
            relay3OnCommand = new RelayCommand(o => RelayButtonClick(3, true));
            relay3OffCommand = new RelayCommand(o => RelayButtonClick(3, false));
            readRelay0Command = new RelayCommand(o => ReadRelayButtonClick(0));
            readRelay1Command = new RelayCommand(o => ReadRelayButtonClick(1));
            readRelay2Command = new RelayCommand(o => ReadRelayButtonClick(2));
            readRelay3Command = new RelayCommand(o => ReadRelayButtonClick(3));
            readAdc0Command = new RelayCommand(o => ReadAdcButtonClick(0));
            readAdc1Command = new RelayCommand(o => ReadAdcButtonClick(1));
            readAdc2Command = new RelayCommand(o => ReadAdcButtonClick(2));
            readAdc3Command = new RelayCommand(o => ReadAdcButtonClick(3));
            checkFirmwareCommand = new RelayCommand(o => CheckFirmwareButtonClick());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// All button command getter and setters
        /// </summary>
        #region Button Commands
        public ICommand Relay0OnCommand
        {
            get { return relay0OnCommand; }
            set
            {
                if (relay0OnCommand != value)
                {
                    relay0OnCommand = value;
                }
            }
        }

        public ICommand Relay0OffCommand
        {
            get { return relay0OffCommand; }
            set
            {
                if (relay0OffCommand != value)
                {
                    relay0OffCommand = value;
                }
            }
        }

        public ICommand Relay1OnCommand
        {
            get { return relay1OnCommand; }
            set
            {
                if (relay1OnCommand != value)
                {
                    relay1OnCommand = value;
                }
            }
        }

        public ICommand Relay1OffCommand
        {
            get { return relay1OffCommand; }
            set
            {
                if (relay1OffCommand != value)
                {
                    relay1OffCommand = value;
                }
            }
        }

        public ICommand Relay2OnCommand
        {
            get { return relay2OnCommand; }
            set
            {
                if (relay2OnCommand != value)
                {
                    relay2OnCommand = value;
                }
            }
        }

        public ICommand Relay2OffCommand
        {
            get { return relay2OffCommand; }
            set
            {
                if (relay2OffCommand != value)
                {
                    relay2OffCommand = value;
                }
            }
        }

        public ICommand Relay3OnCommand
        {
            get { return relay3OnCommand; }
            set
            {
                if (relay3OnCommand != value)
                {
                    relay3OnCommand = value;
                }
            }
        }

        public ICommand Relay3OffCommand
        {
            get { return relay3OffCommand; }
            set
            {
                if (relay3OffCommand != value)
                {
                    relay3OffCommand = value;
                }
            }
        }

        public ICommand ReadAdc0Command
        {
            get { return readAdc0Command; }
            set
            {
                if (readAdc0Command != value)
                {
                    readAdc0Command = value;
                }
            }
        }

        public ICommand ReadAdc1Command
        {
            get { return readAdc1Command; }
            set
            {
                if (readAdc1Command != value)
                {
                    readAdc1Command = value;
                }
            }
        }

        public ICommand ReadAdc2Command
        {
            get { return readAdc2Command; }
            set
            {
                if (readAdc2Command != value)
                {
                    readAdc2Command = value;
                }
            }
        }

        public ICommand ReadAdc3Command
        {
            get { return readAdc3Command; }
            set
            {
                if (readAdc3Command != value)
                {
                    readAdc3Command = value;
                }
            }
        }

        public ICommand CheckFirmwareCommand
        {
            get { return checkFirmwareCommand; }
            set
            {
                if (checkFirmwareCommand != value)
                {
                    checkFirmwareCommand = value;
                }
            }
        }

        public ICommand ReadRelay0Command
        {
            get { return readRelay0Command; }
            set
            {
                if (readRelay0Command != value)
                {
                    readRelay0Command = value;
                }
            }
        }
        public ICommand ReadRelay1Command
        {
            get { return readRelay1Command; }
            set
            {
                if (readRelay1Command != value)
                {
                    readRelay1Command = value;
                }
            }
        }
        public ICommand ReadRelay2Command
        {
            get { return readRelay2Command; }
            set
            {
                if (readRelay2Command != value)
                {
                    readRelay2Command = value;
                }
            }
        }

        public ICommand ReadRelay3Command
        {
            get { return readRelay3Command; }
            set
            {
                if (readRelay3Command != value)
                {
                    readRelay3Command = value;
                }
            }
        }
        #endregion

        /// <summary>
        /// UI console output text getter and setter
        /// </summary>
        public string OutputText
        {
            get { return outputText; }
            set
            {
                outputText = value;
                OnPropertyChanged();
            }
        }

        #region Button Clicks

        /// <summary>
        /// Click action for turning relays on and off
        /// </summary>
        /// <param name="relayNum"> Relay number </param>
        /// <param name="on"> Whether to turn relay on or off </param>
        private void RelayButtonClick(int relayNum, bool on)
        {
            relay.SetRelayState(relayNum, on);
            OutputText = $"Relay {relayNum} turned {(on ? "on" : "off")}";
        }

        /// <summary>
        /// Click action for reading the relay state
        /// </summary>
        /// <param name="relayNum"> Which relay to check state </param>
        private void ReadRelayButtonClick(int relayNum)
        {
            bool state = Convert.ToBoolean(relay.Read(relayNum));
            OutputText = $"Relay {relayNum} state: {(state ? "on" : "off")}";
        }

        /// <summary>
        /// Click action for reading the adc input voltage
        /// </summary>
        /// <param name="inputNum"> Which input to read voltage </param>
        private void ReadAdcButtonClick(int inputNum)
        {
            int value = relay.ReadAdcValue(inputNum);
            OutputText = $"Input {inputNum} voltage: 0.{value}V";
        }

        /// <summary>
        /// Click action for reading the firmware version
        /// </summary>
        private void CheckFirmwareButtonClick()
        {
            string version = relay.ReadFirmwareVersion();
            OutputText = $"Firmware Version: {version}";
        }
        #endregion

        /// <summary>
        /// Create the OnPropertyChanged method to raise the event
        /// The calling member's name will be used as the parameter.
        /// </summary>
        /// <param name="name"></param>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
