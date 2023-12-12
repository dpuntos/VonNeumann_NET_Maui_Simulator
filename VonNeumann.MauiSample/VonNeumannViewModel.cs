using System.ComponentModel;
using System.Windows.Input;

namespace VonNeumann.MauiSample
{
    internal class VonNeumannViewModel : INotifyPropertyChanged
    {
        public ICommand LoadInstructionsCommand { get; private set; }
        public ICommand FetchInstructionsCommand { get; private set; }

        private IDispatcherTimer aTimer;
        Computer.CentralProcessingUnit VN_CPU;

        public VonNeumannViewModel()
        {
            LoadInstructionsCommand = new Command(x => StartProgram());
            FetchInstructionsCommand = new Command(x => FetchInstruction());
        }

        private void StartProgram()
        {
            SetTimer();
        }

        private void FetchInstruction()
        {
            if (VN_CPU.OPC != "HALT")
            {
                VN_CPU.FetchInstruction();
                ProgramCounter = VN_CPU.PC;
                Accumulator = VN_CPU.ACC;
                InstructionRegister = VN_CPU.IR;
                OperationCode = VN_CPU.OPC;

                for (int i = 0; i < VN_CPU.MEM.Length; i++)
                {
                    Instructions[i].Code = VN_CPU.MEM[i];
                }
                RefreshListView();
            }
        }

        private void RefreshListView()
        {
            var insCopy = Instructions.Select(ints => new Instruction { Code = ints.Code, Current = false, Index = ints.Index }).ToList();
            insCopy[System.Convert.ToInt32(ProgramCounter)].Current = true;
            Instructions = insCopy;
            //TODO: yes I know, this is not the best way for refreshing the UI...
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = Dispatcher.GetForCurrentThread().CreateTimer();
            aTimer.Stop();
            aTimer.Interval = new TimeSpan(0, 0, 1);
            aTimer.Tick += ATimer_Tick;
            aTimer.Start();
        }

        private void ATimer_Tick(object? sender, EventArgs e)
        {
            FetchInstruction();
            if (VN_CPU.OPC == "HALT")
            {
                aTimer.Stop();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private string _instructionsFilePath = string.Empty;
        public string InstructionsFilePath
        {
            get => _instructionsFilePath;
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    _instructionsFilePath = value;

                    var instList = File.ReadAllLines(_instructionsFilePath);
                    var inttemp = new List<Instruction>();

                    for (int i = 0; i < instList.Count(); i++)
                    {
                        inttemp.Add(new Instruction() { Code = Convert.ToByte(instList.ElementAt(i), 2), Index = $"{i.ToString().PadLeft(2, '0')}" });
                    }
                    Instructions = inttemp;
                    VN_CPU = new Computer.CentralProcessingUnit();
                    ProgramCounter = 0x00;
                    Accumulator = 0x00;
                    InstructionRegister = 0x00;
                    OperationCode = string.Empty;
                    VN_CPU.LoadProgram(Instructions.Select(inst => inst.Code).ToArray());
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InstructionsFilePath)));
                }
            }
        }

        private List<Instruction> _instructions = new();
        public List<Instruction> Instructions
        {
            get => _instructions;
            set
            {
                if (_instructions != value)
                {
                    _instructions = value;
                    if (_instructions.All(inst => inst.Current == false))
                    {
                        _instructions[0].Current = true;
                    }
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Instructions)));
                }
            }
        }

        private byte _ProgramCounter = 0x00;
        public byte ProgramCounter
        {
            get => _ProgramCounter;
            set
            {
                if (_ProgramCounter != value)
                {
                    _ProgramCounter = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ProgramCounter)));
                }
            }
        }

        private byte _Accumulator = 0x00;
        public byte Accumulator
        {
            get => _Accumulator;
            set
            {
                if (_Accumulator != value)
                {
                    _Accumulator = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Accumulator)));
                }
            }
        }

        private byte _InstructionRegister = 0x00;
        public byte InstructionRegister
        {
            get => _InstructionRegister;
            set
            {
                if (_InstructionRegister != value)
                {
                    _InstructionRegister = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InstructionRegister)));
                }
            }
        }

        private string _OperationCode = string.Empty;
        public string OperationCode
        {
            get => _OperationCode;
            set
            {
                if (_OperationCode != value)
                {
                    _OperationCode = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OperationCode)));
                }
            }
        }
    }
}
