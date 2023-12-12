using static System.Console;

namespace VonNeumann.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Executing sample program...");

            string[] programInstructions = new string[]
            {
                "00000100", //ADD:  ACC = ACC + MEM[4]  --> ACC  = 7
                "00010101", //SUB:  ACC = ACC - MEM[5]  --> ACC  = 6
                "01100111", //MEM:  MEM[7] = ACC        --> MEM[7] = 6
                "01110000", //HALT
                "00000111",
                "00000001",
                "00000000",
                "00000000"
            };

            //Convert the program instructions to bytes
            byte[] program = new byte[programInstructions.Length];
            for (int i = 0; i < programInstructions.Length; i++)
            {
                program[i] = Convert.ToByte(programInstructions[i], 2);
            }

            //Create a new CPU and load the program
            var VN_CPU = new VonNeumann.Computer.CentralProcessingUnit();
            VN_CPU.LoadProgram(program);

            //Execute the program
            while (VN_CPU.IR != 0x07)
            {
                VN_CPU.FetchInstruction();
            }
        }
    }
}
