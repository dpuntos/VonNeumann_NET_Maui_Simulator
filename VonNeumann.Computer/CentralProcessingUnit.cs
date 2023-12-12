namespace VonNeumann.Computer
{
    public class CentralProcessingUnit
    {
        private ArithmeticLogicUnit _ALU = new ArithmeticLogicUnit();
        private MemoryUnit _Memory = new MemoryUnit(256);

        private byte _ProgramCounter;
        private byte _InstructionRegister;
        private string _OperationCode = string.Empty;

        public byte PC => _ProgramCounter;
        public byte IR => _InstructionRegister;
        public byte ACC => _ALU.Accumulator;
        public string OPC => _OperationCode;
        public byte[] MEM => _Memory.Memory;

        public void LoadProgram(byte[] program)
        {
            //Size the memory unit to the size of the program
            _Memory = new MemoryUnit(program.Length);
            for (int i = 0; i < program.Length; i++)
            {
                _Memory[i] = program[i];
            }
        }

        public void FetchInstruction()
        {
            //Fetch the instruction from memory
            _InstructionRegister = _Memory[_ProgramCounter];

            //Increment the program counter
            _ProgramCounter++;

            //Decode the instruction
            DecodeInstruction();
        }

        private void DecodeInstruction()
        {
            //AAAABBBB
            //AAAA = Instruction
            //BBBB = Operand           

            var instruction = _InstructionRegister >> 4;
            var operand = _InstructionRegister & 0x0F;

            switch (instruction)
            {
                case 0x00:
                    _OperationCode = "ADD";
                    _ALU.Register = _Memory[operand];
                    _ALU.Add();
                    break;
                case 0x01:
                    _OperationCode = "SUB";
                    _ALU.Register = _Memory[operand];
                    _ALU.Substract();
                    break;
                case 0x02:
                    _OperationCode = "MUL";
                    _ALU.Register = _Memory[operand];
                    _ALU.Multiply();
                    break;
                case 0x03:
                    _OperationCode = "POW";
                    _ALU.Register = _Memory[operand];
                    _ALU.Power();
                    break;
                case 0x04:
                    _OperationCode = "AND";
                    _ALU.Register = _Memory[operand];
                    _ALU.And();
                    break;
                case 0x05:
                    _OperationCode = "OR";
                    _ALU.Register = _Memory[operand];
                    _ALU.Or();
                    break;
                case 0x06:
                    _OperationCode = "MEM";
                    _Memory[operand] = _ALU.Accumulator;
                    break;
                case 0x07:
                    _OperationCode = "HALT";
                    break;
                default:
                    break;
            }
        }
    }
}
