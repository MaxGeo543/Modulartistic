using System;
using System.Collections.Generic;
using System.Text;

namespace MoreMath
{
    class RawNaturalNumber
    {
        private readonly bool _isZero;
        private readonly RawNaturalNumber _predecessor;
        public static readonly RawNaturalNumber ZERO = new RawNaturalNumber(true);
        public uint Value
        {
            get 
            {
                return Evaluate();
            }
        }

        private RawNaturalNumber(bool isZero)
        {
            this._isZero = isZero;
        }

        private RawNaturalNumber(RawNaturalNumber predecessor)
        {
            this._predecessor = predecessor;
        }

        public static RawNaturalNumber Succ(RawNaturalNumber n)
        {
            return new RawNaturalNumber(n);
        }

        public static RawNaturalNumber operator +(RawNaturalNumber a, RawNaturalNumber b)
        {
            if (b._isZero)
            {
                return a;
            }
            else
            {
                return RawNaturalNumber.Succ(a + b._predecessor);
            }
        }

        public static RawNaturalNumber operator *(RawNaturalNumber a, RawNaturalNumber b)
        {
            if (b._isZero)
            {
                return RawNaturalNumber.ZERO;
            }
            else
            {
                return (a * b._predecessor) + a;
            }
        }

        public static bool operator ==(RawNaturalNumber a, RawNaturalNumber b)
        {
            if (a._isZero && b._isZero)
            {
                return true;
            }
            else if (a._isZero || b._isZero)
            {
                return false;
            }
            return a._predecessor == b._predecessor;
        }

        public static bool operator !=(RawNaturalNumber a, RawNaturalNumber b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is RawNaturalNumber number)
            {
                RawNaturalNumber a = this;
                RawNaturalNumber b = number;
                
                if (a._isZero && b._isZero)
                {
                    return true;
                }
                else if (a._isZero || b._isZero)
                {
                    return false;
                }
                return a._predecessor == b._predecessor;
            }
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Value);
        }

        public uint Evaluate()
        {
            if (this._isZero)
                return 0;
            return this._predecessor.Evaluate() + 1;
        }

        public NaturalNumber ToNatural()
        {
            return new NaturalNumber(this);
        }
    }

    class NaturalNumber
    {
        private readonly bool _isZero;
        public static readonly NaturalNumber ZERO = new NaturalNumber(0);
        public uint Value { get; }

        public NaturalNumber(uint val)
        {
            Value = val;
            if (Value == 0) { _isZero = true; }
        }

        public NaturalNumber(RawNaturalNumber n)
        {
            Value = n.Value;
            if (Value == 0) { _isZero = true; }
        }

        public static NaturalNumber Succ(NaturalNumber n)
        {
            return new NaturalNumber(n.Value+1);
        }

        public static NaturalNumber operator +(NaturalNumber a, NaturalNumber b)
        {
            return new NaturalNumber(a.Value + b.Value);
        }

        public static NaturalNumber operator *(NaturalNumber a, NaturalNumber b)
        {
            return new NaturalNumber(a.Value * b.Value);
        }

        public static bool operator ==(NaturalNumber a, NaturalNumber b)
        {
            return a.Value == b.Value;
        }

        public static bool operator !=(NaturalNumber a, NaturalNumber b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj is NaturalNumber number)
            {
                NaturalNumber a = this;
                NaturalNumber b = number;
                return a.Value == b.Value;
            }
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Value);
        }
    }
}
