namespace VonNeumann.Computer
{
    public class ArithmeticLogicUnit
    {
        private byte _Accumulator;
        private byte _Register;

        public byte Accumulator => _Accumulator;
        public byte Register
        {
            set { _Register = value; }
        }

        public void Add()
        {
            _Accumulator += _Register;
        }

        public void Substract()
        {
            _Accumulator -= _Register;
        }

        public void Multiply()
        {
            _Accumulator *= _Register;
        }

        public void Power()
        {
            _Accumulator = (byte)Math.Pow(_Accumulator, _Register);
        }

        public void And()
        {
            _Accumulator &= _Register;
        }
            
        public void Or()
        {
            _Accumulator |= _Register;
        }       
    }
}
