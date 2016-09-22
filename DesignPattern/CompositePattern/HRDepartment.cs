using System;

namespace DesignPattern.CompositePattern
{
    class HRDepartment : Company
    {
        public HRDepartment(string name) : base(name)
        {
        }

        public override void Add(Company c)
        {
        }

        public override void Remove(Company c)
        {
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new string('-', depth) + _name);
        }

        public override void LineOfDuty()
        {
            Console.WriteLine("{0} Ա����Ƹ��ѵ����", _name);
        }
    }
}