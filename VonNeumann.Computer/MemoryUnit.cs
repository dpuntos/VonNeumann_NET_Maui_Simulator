namespace VonNeumann.Computer
{
    public class MemoryUnit
    {
        private byte[] _Memory;
        private int _MemorySize;

        public MemoryUnit(int memorySize)
        {
            _MemorySize = memorySize;
            _Memory = new byte[_MemorySize];
        }

        public byte[] Memory => _Memory;
        public int MemorySize => _MemorySize;        

        public byte this[int index]
        {
            get
            {
                return _Memory[index];
            }
            set
            {
                _Memory[index] = value;
            }
        }
    }
}
