using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Composite
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Employee hayrettin = new Employee() { Name = "hayrettin dal" };
            Employee zeynep = new Employee() { Name = "zeynep dal" };

            hayrettin.AddSubordinate(zeynep);

            Employee murat = new Employee() { Name = "murat dal" };
            hayrettin.AddSubordinate(murat);

            Employee ahmet = new Employee() { Name = "ahmet gül" };
            murat.AddSubordinate(ahmet);

            Contractor ali = new Contractor() { Name = "ali çantalı" };
            zeynep.AddSubordinate(ali);

            Console.WriteLine(hayrettin.Name);
            foreach (Employee manager in hayrettin)
            {
                Console.WriteLine(" {0}", manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("  {0}", employee.Name);
                }
            }
            Console.ReadLine();
        }
    }


    public interface IPerson
    {
        string Name { get; set; }
    }
    public class Contractor : IPerson
    {
        public string Name { get ; set; }
    }

    public class Employee : IPerson, IEnumerable<IPerson>
    {
        public string Name { get ; set ; }
        List<IPerson> _subordinates = new List<IPerson>();  

        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }
        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {

            return _subordinates[index];    
        }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (IPerson subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); 
        }
    }
}
